using Brasserie.Model.Restaurant.Catering;
using Brasserie.Model.Restaurant.Design;
using Brasserie.Model.Restaurant.People;
using Brasserie.Utilities.DataAccess.Files;
using Brasserie.Utilities.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brasserie.Utilities.DataAccess
{
    public class DataAccessSqlFile : DataAccess, IDataAccess
    {
        public DataAccessSqlFile(DataFilesManager dfm, IAlertService alertService) : base(dfm, alertService)
        {
            try
            {
                AccessPath = DataFilesManager.DataFiles.GetValueByCodeFunction("CONNECTION_STRING");

                //const string CONN_STRING = @"Data Source=DESKTOP-2CMJL32\DELL5350_SQL;Initial Catalog=BrasserieDatabase;User Id = IRAM_USER; Password = 123456;Encrypt=true; TrustServerCertificate=true";

                SqlConnection = new SqlConnection(AccessPath);
                SqlConnection.Open();

            }
            catch (Exception ex)
            {

            }

        }

        /// <summary>
        /// Connection to the database
        /// </summary>
        public SqlConnection SqlConnection { get; set; }

        public override CustomersCollection GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public override ItemsCollection GetAllItems()
        {
            try
            {
                ItemsCollection items = new ItemsCollection();

                string sql = "SELECT * FROM dbo.Items ORDER BY Id";

                SqlCommand cmd = new SqlCommand(sql, SqlConnection);
                SqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Item item = GetItem(dataReader);

                    if (item != null)
                    {
                        items.AddItem(item);
                    }
                }

                dataReader.Close();

                return items;
            }
            catch (Exception ex)
            {
                alertService.ShowAlert("Database Request Error", ex.Message);
                return null;
            }
        }

        private static Item GetItem(SqlDataReader dr)
        {
            string type = dr["Type"].ToString();

            int id = Convert.ToInt32(dr["Id"]);
            string name = dr["Name"].ToString();
            string description = dr["Description"].ToString();
            double unitPrice = Convert.ToDouble(dr["UnitPrice"]);
            double vatRate = Convert.ToDouble(dr["VatRate"]);
            string pictureName = dr["PictureName"].ToString();

            switch (type.ToUpper())
            {
                case "DISH":
                    return new Dish(
                        id: id,
                        name: name,
                        description: description,
                        unitPrice: unitPrice,
                        vatRate: vatRate,
                        pictureName: pictureName
                    );

                case "SOFT":
                    return new Soft(
                        id: id,
                        name: name,
                        description: description,
                        unitPrice: unitPrice,
                        vatRate: vatRate,
                        pictureName: pictureName,
                        volume: Convert.ToDouble(dr["Volume"])
                    );

                case "APERITIF":
                    return new Aperitif(
                        id: id,
                        name: name,
                        description: description,
                        unitPrice: unitPrice,
                        vatRate: vatRate,
                        pictureName: pictureName,
                        volume: Convert.ToDouble(dr["Volume"]),
                        percentage: Convert.ToDouble(dr["Percentage"])
                    );

                case "BEER":
                    return new Beer(
                        id: id,
                        name: name,
                        description: description,
                        unitPrice: unitPrice,
                        vatRate: vatRate,
                        pictureName: pictureName,
                        volume: Convert.ToDouble(dr["Volume"]),
                        percentage: Convert.ToDouble(dr["Percentage"]),
                        isAbbeyBeer: Convert.ToBoolean(dr["IsAbbeyBeer"]),
                        isTrappistBeer: Convert.ToBoolean(dr["IsTrappistBeer"])
                    );

                default:
                    return null;
            }
        }

        /// <summary>
        /// Retrieve all staff members datas from database table StaffMembers
        /// </summary>
        /// <returns></returns>
        public override StaffMembersCollection GetAllStaffMembers()
        {
            try
            {
                StaffMembersCollection staffMembers = new StaffMembersCollection();

                string sql = "SELECT * FROM StaffMembers";

                SqlCommand cmd = new SqlCommand(sql, SqlConnection);
                SqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    StaffMember sm = GetStaffMember(dataReader);
                    if (sm != null)
                    {
                        staffMembers.Add(sm);
                    }
                }

                dataReader.Close();
                return staffMembers;
            }
            catch (Exception ex)
            {
                alertService.ShowAlert("Database Request Error", ex.Message);
                return null;
            }
        }//end GetAllStaffMembers()

        /// <summary>
        /// read datareader staffMember informations
        /// and create instance with each fields.
        /// </summary>
        /// <param name="SqlDataReader"> a line of the records"></param>
        /// <returns></returns>
        private static StaffMember GetStaffMember(SqlDataReader dr)
        {
            string type = dr.GetValue(1).ToString();

            switch (type)
            {
                case "StaffMember":
                    return new StaffMember(id: dr.GetInt32(0), lastName: dr.GetString(2), firstName: dr.GetString(3), gender: dr.GetBoolean(7), email: dr.GetString(6), phone: dr.GetString(5), bankAccount: dr.GetString(8), address: dr.GetString(4), salary: dr.GetDouble(9));

                case "Manager":
                    return new Manager(id: dr.GetInt32(0),
                        lastName: dr.GetString(2),
                        firstName: dr.GetString(3), gender: dr.GetBoolean(7), email: dr.GetString(6), phone:
                        dr.GetString(5), bankAccount: dr.GetString(8), address: dr.GetString(4), salary:
                        dr.GetDouble(9), login: dr.GetString(10), password: dr.GetString(11));

                default:
                    return null;
            }
        }

        public override TablesCollection GetTables()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// update StaffMembers database table from the staff members collection
        /// </summary>
        /// <param name="uc"></param>
        public override bool UpdateAllStaffMembers(StaffMembersCollection staffMembers)
        {
            string sql = string.Empty;
            try
            {
                foreach (StaffMember sm in staffMembers)
                {
                    //if id already in databse, update his values, insert in the other case
                    sql = IsInDb(sm.Id, "Id", "StaffMembers") ? GetSqlUpdateStaffMember(sm) : GetSqlInsertStaffMember(sm);

                    if (!string.IsNullOrEmpty(sql))
                    {
                        //Console.WriteLine(sql);
                        SqlCommand command = new SqlCommand(sql, SqlConnection);
                        //command.ExecuteNonQuery(); //common Execute without getting id value

                        //get id autocreated by the database (when update insertedId = 0)
                        int insertedId = Convert.ToInt32(command.ExecuteScalar());
                        if (insertedId > 0)
                        {
                            sm.Id = insertedId;
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                alertService.ShowAlert("Database Request Error", $"{ex.Message} \nSQL Query : {sql}");
                return false;
            }
        }

        /// <summary>

        /// <summary>
        /// create a sql request updating the staffMember function of his type and his
        /// internal properties values.
        /// </summary>
        /// <param name="u"></param>
        /// <returns>sql UPDATE request</returns>
        private string GetSqlUpdateStaffMember(StaffMember sm)
        {
            string[] strType = sm.GetType().ToString().Split('.');
            string type = strType[strType.Length - 1];
            switch (type)
            {
                case "StaffMember":

                    return $"UPDATE StaffMembers SET FirstName= '{sm.FirstName}'" +
                        $",LastName='{sm.LastName}', Address='{sm.Address}'" +
                        $",MobilePhone='{sm.MobilePhoneNumber}', EMail='{sm.Email}'" +
                        $",Gender={BoolSqlConvert(sm.Gender)}, BankAccount='{sm.BankAccount}' WHERE Id = {sm.Id};";

                case "Manager":
                    Manager m = (Manager)sm;
                    return $"UPDATE StaffMembers SET FirstName= '{sm.FirstName}'" +
                        $",LastName='{sm.LastName}', Address='{sm.Address}'" +
                        $",MobilePhone='{sm.MobilePhoneNumber}', EMail='{sm.Email}'" +
                        $",Gender={BoolSqlConvert(sm.Gender)}, BankAccount='{sm.BankAccount}', Login='{m.Login}' WHERE Id = {sm.Id};";

                default:
                    //MessageBox.Show($"Insert or update sql error, le type {type} n'est
                    // pas reconnu pour {u.FullName}", "Erreur de sauvegarde", MessageBoxButton.OK,
                    // MessageBoxImage.Warning);
                    return null;
            }
        }

        /// <summary>
        /// create a sql request. Insert the staffMember function of his type and his
        /// internal properties values.
        /// </summary>
        /// <param name="sm"></param>
        /// <returns>sql INSERT request</returns>
        private string GetSqlInsertStaffMember(StaffMember sm)
        {
            string[] strType = sm.GetType().ToString().Split('.');
            string type = strType[strType.Length - 1];
            switch (type)
            {
                case "StaffMember":

                    return $"INSERT INTO StaffMembers (Type, FirstName, LastName, Address, MobilePhone, EMail, Gender, BankAccount, Salary) " +
                        $"VALUES('{type}', '{sm.FirstName}', '{sm.LastName}', '{sm.Address}', '{sm.MobilePhoneNumber}', '{sm.Email}', {BoolSqlConvert(sm.Gender)}, '{sm.BankAccount}', {sm.GetSalary});SELECT SCOPE_IDENTITY();";

                case "Manager":
                    Manager m = (Manager)sm;
                    return $"INSERT INTO StaffMembers (Type, FirstName, LastName, Address, MobilePhone, EMail, Gender, BankAccount, Salary, Login) " +
                        $"VALUES('{type}', '{sm.FirstName}', '{sm.LastName}', '{sm.Address}', '{sm.MobilePhoneNumber}', '{sm.Email}', {BoolSqlConvert(sm.Gender)}, '{sm.BankAccount}', {sm.GetSalary}, '{m.Login}');SELECT SCOPE_IDENTITY();";
                default:

                    return null;
            }
        }

        /// <returns>true if id founded (already in database) </returns>
        private bool IsInDb(int idValue, string idColumnName, string tableName)
        {
            string sql = $"SELECT * FROM {tableName} WHERE {idColumnName} = {idValue}";
            SqlCommand cmd = new SqlCommand(sql, SqlConnection);
            SqlDataReader dataReader = cmd.ExecuteReader();
            bool inDb = dataReader.HasRows;

            dataReader.Close();
            return inDb;
        }

        /// <summary>
        /// change true, false to 1,0 for SQL requests
        /// </summary>
        /// <param name="b"></param>
        /// <returns>"0" or "1"</returns>
        private string BoolSqlConvert(bool b)
        {
            return b ? "1" : "0";
        }

        public override bool UpdateAllItems(ItemsCollection items)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteStaffMember(StaffMember staffMember)
        {
            throw new NotImplementedException();
        }
    }//end class
}


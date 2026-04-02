using Brasserie.Model;
using Brasserie.Model.Restaurant.Activity;
using Brasserie.Model.Restaurant.Catering;
using Brasserie.Model.Restaurant.Design;
using Brasserie.Model.Restaurant.People;
using Brasserie.Utilities.DataAccess;
using Brasserie.Utilities.DataAccess.Files;
using System.Collections.ObjectModel;
using static Brasserie.Model.Restaurant.People.Customer;

namespace Brasserie.View
{
    public partial class MainPage : ContentPage
    {
        
        private const string CONFIG_HOME_CSV = @"C:\Users\Max\Desktop\IRAM\INF\POO\Brasserie\Brasserie\Configuration\Datas\Config.txt";
        private const string CONFIG_PORT_CSV = @"C:\POO\Brasserie\Configuration\Datas\Config.txt";

        private const string CONFIG_HOME_JSON = @"C:\Users\Max\Desktop\IRAM\INF\POO\Brasserie\Brasserie\Configuration\Datas\ConfigJson.txt";
        private const string CONFIG_PORT_JSON = @"C:\POO\Brasserie\Configuration\Datas\ConfigJson.txt";

        Counter myCounter;

        public MainPage()
        {
            InitializeComponent();
            myCounter = new Counter();
        }

        //private void OnCounterClicked(object sender, EventArgs e)
        //{
        //    count++;

        //    if (count == 1)
        //        CounterBtn.Text = $"Clicked {count} time";
        //    else
        //        CounterBtn.Text = $"Clicked {count} times";

        //    EntryCount.Text = count.ToString();

        //    myCounter.IncrementCounter();

        //    if (myCounter.CounterValue == 1)
        //        CounterBtn.Text = $"Clicked {myCounter.CounterValue} time";
        //    else
        //        CounterBtn.Text = $"Clicked {myCounter.CounterValue} times";

        //    EntryCount.Text = myCounter.CounterValue.ToString();

        //    SemanticScreenReader.Announce(CounterBtn.Text);
        //}

        //private void buttonTestCreateFirstPersons_Clicked(object sender, EventArgs e)
        //{
        //    //Person firstPerson = new Person(id: 1, lastName: "Beumier", firstName: "Damien", gender: true, email: "dambeumier@gmail.com", mobilePhoneNumber: "0489142293");
        //    Person secondPerson = new Person(id: 2, lastName: "Deroisin", firstName: "Sophie", gender: false, email: "sophiederoisin@gmail.com", mobilePhoneNumber: "0473121314");
        //    Person ThirdPerson = new Person(3, "Jandrin", "Marc", true, "jandrinmarc@gmail.com", mobilePhoneNumber: "0485556678");
        //    Person FourthPerson = new Person(4, "Lupant", "Sebastien");
        //    Person FifthPerson = new Person();
        //    //Person TestPerson = new Person( lastName: "Lupant", firstName: "Sebastien");

        //    //Person p;

        //    //p = new Person(6, "Tardif", "Jean");

        //    //secondPerson._email = "04.be";
        //    //secondPerson._mobilePhoneNumber = "44719";

        //}

        //private void buttonTestEncapsulation_Clicked(object sender, EventArgs e)
        //{
        //    Person p = new Person(id: 2, lastName: "Deroisin", firstName: "Sophie", gender: false, email: "sophiederoisin@gmail.com", mobilePhoneNumber: "0473121314");
        //    p.FirstName = "Dark-Vador";
        //    lblDebug.Text = p.FirstName;
        //}

        //private void buttonTestCreateItem_Clicked(object sender, EventArgs e)
        //{
        //    Item item = new Item(id: 1, name: "Lasagne", description: "une grosse assiette de lasagne", unitPrice: 20.0, vatRate: 21.0, pictureName: "patebolo.jpg");
        //    lblItemDebug.Text = $"Id : {item.Id} Name : {item.Name} Description : {item.Description} UnitPrice : {item.UnitPrice} VatRate : {item.VatRate} PictureName : {item.PictureName}";
        //}

        private void buttonTestStatic_Clicked(object sender, EventArgs e)
        {
            string mail = "mon mail@gmail.com";
            bool testMail = Person.CheckEMail(mail);
            //lblDebug.Text = $"résultat du test de validité du mail {mail} : {testMail.ToString()}";
            lblDebug.Text = $"Nombre d'instances de classe Person : {Person.TotalPersons}";
        }

        private void buttonTestTable_Clicked(object sender, EventArgs e)
        {
            Table table = new Table(1, 4, true);
        }

        private void buttonTestInheritance_Clicked(object sender, EventArgs e)
        {
            Customer c = new Customer(7, "Maggi", "Francesca", false, "francesca190@gmail.com", "0475689034", CustomerType.New);
            StaffMember staffm = new StaffMember(8, "Dries", "François", true, "francoisdries@gmail.com", "0485113289", "BE83 2378 9876 2390", "4, rue du marais 7030 Ghlin", 3275.0);
            Manager m = new Manager(9, "Duchief", "Marc", true, "duchiefmarc@gmail.com", "0491203040", "BE84 1128 9836 3518", "2, rue du pont 7000 Mons", 5200.5, "Password01");
        }

        private void buttonTestDerivateItems_Clicked(object sender, EventArgs e)
        {
            //Item item = new Item(id: 1, name: "Lasagne", description: "une grosse assiette de lasagne", unitPrice: 20.0, vatRate: 21.0, pictureName: "lasagne.jpg");
            Drink drink = new Drink(id: 2, name: "Coca", description: "une canette de coca", unitPrice: 2.0, vatRate: 21.0, pictureName: "coca.jpg", 33.0);
            Dish dish = new Dish(id: 3, name: "Pizza", description: "une grosse pizza", unitPrice: 15.0, vatRate: 21.0, pictureName: "pizza.jpg");
            Soft soft = new Soft(id: 4, name: "Ice-Tea", description: "une canette d'ice tea", unitPrice: 2.5, vatRate: 21.0, pictureName: "icetea.jpg", volume: 33.0);
            Alcohol alcohol = new Alcohol(id: 5, name: "Leffe", description: "une bouteille de Leffe", unitPrice: 3.0, vatRate: 21.0, pictureName: "leffe.jpg", volume: 50.0, percentage: 6.6);
            Beer beer = new Beer(id: 6, name: "Jupiler", description: "une canette de Jupiler", unitPrice: 2.5, vatRate: 21.0, pictureName: "jupiler.jpg", volume: 33.0, percentage: 5.2, isAbbeyBeer: false, isTrappistBeer: false);
            Aperitif aperitif = new Aperitif(id: 7, name: "Campari", description: "un verre de Campari", unitPrice: 4.0, vatRate: 21.0, pictureName: "campari.jpg", volume: 5.0, percentage: 25.0);

        }

        private void buttonTestCollection_Clicked(object sender, EventArgs e)
        {
            StaffMember staffm1 = new StaffMember(10, "Vandenberg", "Caroline", true, "carovan@gmail.com", "0476893029", "BE81 7345 1290 1038", "10, rue de l'eglise 7030 Ghlin", 3050.0);
            StaffMember staffm2 = new StaffMember(11, "Dries", "Francois", true, "francoisdries@gmail.com","0485113289", "BE83 2378 9876 2390", "130, rue de binche 7030 Ghlin", 3275.0);
            Manager m = new Manager(12, "Legars", "Flavien", true, "legafla@gmail.com","0482426671", "BE83 4435 1893 1450", "5, rue de la cle 7000 Mons", 5500.0, "Password01");
            ObservableCollection<StaffMember> staffmCol = new ObservableCollection<StaffMember>();
            staffmCol.Add(staffm1);
            staffmCol.Add(staffm2);
            staffmCol.Add(m);

            string s = $"\nnombre d'éléments dans la collection : {staffmCol.Count}";
            foreach (StaffMember sm in staffmCol)
            {
                s += $"\n{sm.FirstName} {sm.LastName} : {sm.GetType().ToString()}";
            }
            lblDebug.Text = s;
        }

        private void buttonTestOrder_Clicked(object sender, EventArgs e)
        {
            Order ord = new Order();

            Soft coca = new Soft(1, name: "Coca cola", "", 3.30, 21.0, "coca.jpg",  25.0);
            Beer brassTemps = new Beer(2, name: "Coca cola", "", 3.30, 21.0, "biere.jpg",  25.0, 6.0, false, false);
            Dish spaghBolo = new Dish(3, "Spaghetti bolo", "", 15.30, 21.0, "bolo.jpg");
            Dish coteAlos = new Dish(4, "Côte à l'os", "", 25.0, 21.0, "cote.jpg");

            OrderItem ordItemCoca_1 = new OrderItem(coca, 1);
            OrderItem ordItemBrassTemps = new OrderItem(brassTemps, 1);
            OrderItem ordItemSpaghBolo = new OrderItem(spaghBolo, 2);
            OrderItem ordItemCoca_2 = new OrderItem(coca, 2);
            OrderItem ordItemCoteAlos = new OrderItem(coteAlos, 1);


            ord.AddUpdateOrderItem(ordItemCoca_1);
            ord.AddUpdateOrderItem(ordItemBrassTemps);
            ord.AddUpdateOrderItem(ordItemSpaghBolo);
            ord.AddUpdateOrderItem(ordItemCoca_2); //2 nouveaux cocas commandés plus tard
            ord.AddUpdateOrderItem(ordItemCoteAlos); //côte à l'os commandée plus tard

            string s = "";
            s = $"nombre d'orderItems : {ord.OrderItems.Count}";
            s += $"\nnombre de coca : {ord.OrderItems[0].Quantity} Prix : {ord.OrderItems[0].Price}";
            s += $"\nnombre de brasse temps : {ord.OrderItems[1].Quantity} Prix : {ord.OrderItems[1].Price}";
            s += $"\nnombre de spaghettis : {ord.OrderItems[2].Quantity} Prix : {ord.OrderItems[2].Price}";
            s += $"\nPrix total TVA : {ord.TotalVatCost}€";
            s += $"\nPrix total : {ord.TotalPrice}€";
            lblDebug.Text = s;
            
            
            

        }

        private void buttonTestLambdasOnCollection_Clicked(object sender, EventArgs e)
        {
            ObservableCollection<Drink> drinks = new ObservableCollection<Drink>();
            drinks.Add(new Soft(1, name: "Coca", "", 3.30, 21.0, "coca.jpg",  25));
            drinks.Add(new Soft(2, name: "Fanta", "", 3.30, 21.0, "fanta.jpg",  25));
            drinks.Add(new Soft(3, name: "Coca", "", 4.20, 21.0, "coca.jpg", 33));
            drinks.Add(new Soft(4, name: "Fanta", "", 4.20, 21.0, "fanta.jpg",  33));
            drinks.Add(new Soft(5, name: "Water", "", 3.10, 21.0, "water25.jpg",  25));
            drinks.Add(new Soft(6, name: "Water", "", 5.50, 21.0, "water.jpg",  50));
            drinks.Add(new Soft(7, name: "Water", "", 7.00, 21.0, "water.jpg", 100));
            drinks.Add(new Soft(8, name: "CocaZero", "", 3.50, 21.0, "coca.jpg",  25));
            drinks.Add(new Soft(9, name: "IceTeaZero", "", 3.50, 21.0, "coca.jpg",  25));
            drinks.Add(new Beer(10, name: "AmbrasseTemps", "", 4.20, 21.0, "amb25.jpg",  25, 6.00, false, false));
            drinks.Add(new Beer(11, name: "Troll", "", 4.20, 21.0, "troll25.jpg",  25, 5.50, false, false));
            // match Criteria ?;
            bool boolResult;
            boolResult = drinks.All(d => d.UnitPrice < 5.00);//all elements respect the criteria ?
            boolResult = drinks.Any(d => d.UnitPrice >= 6.00);//exist at least one element that respect the criteria
                                                              //sorted collections
            ObservableCollection<Drink> orderByNameDesc = new ObservableCollection<Drink>(drinks.OrderByDescending(d => d.PictureName));
            ObservableCollection<Drink> orderByUnitPriceAsc = new ObservableCollection<Drink>(drinks.OrderBy(d => d.UnitPrice));
            //collection with selection
            ObservableCollection<Drink> select25Cl = new ObservableCollection<Drink>(drinks.Where(d => d.Volume == 25.00));
            ObservableCollection<Drink> waters = new ObservableCollection<Drink>(drinks.Where(d => d.Name.Contains("Water")));
            ObservableCollection<Drink> beers = new ObservableCollection<Drink>(drinks.OfType<Beer>());
            //find element with one or more (logical expression) criteria
            Drink coca33 = drinks.First(d => d.Name.Contains("amb25"));
            Drink d = drinks.First(d => d.Volume > 25 && d.PictureName.EndsWith(".jpg"));
            //build new list from another collection
            List<string> s = drinks.Select(d => $"{d.Id};{d.Name};{d.Description};{d.UnitPrice};{d.Volume}").ToList();
            //compute
            double maxUnitPrice = drinks.Max(d => d.UnitPrice);
            double average = drinks.Average(d => d.UnitPrice);
            double sum = drinks.Sum(d => d.UnitPrice);
            //do something foreach element drinks.ForEach(d => d.VatRate = 22.0);
            //drinks.ForEach(d => d.VatRate = 22.0);
        }

        private void buttonExLambdaOnCollection_Clicked(object sender, EventArgs e)
        {
            ObservableCollection<StaffMember> staff = new ObservableCollection<StaffMember>();
            staff.Add(new StaffMember(1, "Dutrieu", "Pierre", true, "dutrieur@gmail.com", "0498345678", "BE45 6781 2345 2490", "4, rue de la coupe 7000 Mons", 34000));
            staff.Add(new StaffMember(2, "Lalande", "Vanessa", false, "", "0485667098", "BE80 6581 1145 3496", "16, rue de la loi 7080 Nivelles", 32500));
            staff.Add(new Manager(3, "Jenlain", "Fabienne", false, "jenfab23@gmail.com", "0478901322", "BE80 4394 7739 1234", "13, rue de Mons 6000 Beaumont", 59000, "Password01"));
            staff.Add(new StaffMember(4, "Baulieu", "Jean", true, "", "", "BE23 1189 1390 1193", "5, rue des tilleus 7030 Ghlin", 36500));
            staff.Add(new StaffMember(5, "Gerardin", "Isabelle", false, "", "0475671038", "BE80 1782 4490 9113", "120, rue des drapiers 7000 Mons", 41000));
            staff.Add(new Manager(6, "Balkan", "Fred", true, "balkan@gmail.com", "0479001280", "BE89 1190 1127 2280", "10, rue grande 6340 Nimy", 54000, "TrucMachin01"));
            staff.Add(new StaffMember(7, "Gutierez", "Manolo", true, "manolo140@gmail.com", "0498671011", "BE70 9012 1034 1931", "8, rue de la riviere 7000 Mons", 29800));

            //a
            int nbemployer = staff.Count;
            bool boolResult;
            //b
            boolResult = staff.All(s => !string.IsNullOrEmpty(s.MobilePhoneNumber));
            //c
            boolResult = staff.Any(s => string.IsNullOrEmpty(s.Email) && string.IsNullOrEmpty(s.MobilePhoneNumber));
            //d
            StaffMember membre1 = staff.First(s => string.IsNullOrEmpty(s.Email) && string.IsNullOrEmpty(s.MobilePhoneNumber));
            //e
            List<StaffMember> memberWithoutEmail = staff.Where(s => string.IsNullOrEmpty(s.Email)).ToList();
            //f
            List<StaffMember> femaleMember = staff.Where(s => !s.Gender).ToList();
            //g
            List<StaffMember> monsMember = staff.Where(s => s.Address.EndsWith("Mons")).ToList();
            //h
            List<Manager> managers = staff.OfType<Manager>().ToList();
            //i
            List<StaffMember> employeOderByName = staff.OrderBy(s => s.LastName).ToList();
            //j
            double malePercentageInStaff = (double)staff.Count(s => s.Gender) / staff.Count * 100;
            //k
            // List<StaffMember> employeOrderBySalary = staff.OrderBy(s => s.Salary).ToList(); pas possible car Salary est protected dans StaffMember et pas accessible dans MainPage

            //version prof : 
            //ObservableCollection<StaffMember> staff = new ObservableCollection<StaffMember>();

            //staff.Add(new StaffMember(1, "Dutrieu", "Pierre", true, "dutrieur@gmail.com", "0498345678", "BE45 6781 2345 2490", "4, rue de la coupe 7000 Mons", 34000));
            //staff.Add(new StaffMember(2, "Lalande", "Vanessa", false, "", "0485667098", "BE80 6581 1145 3496", "16, rue de la loi 7080 Nivelles", 32500));
            //staff.Add(new Manager(3, "Jenlain", "Fabienne", false, "jenfab23@gmail.com", "0478901322", "BE80 4394 7739 1234", "13, rue de Mons 6000 Beaumont", 59000, "Password01"));
            //staff.Add(new StaffMember(4, "Baulieu", "Jean", true, "", "", "BE23 1189 1390 1193", "5, rue des tilleus 7030 Ghlin", 36500));
            //staff.Add(new StaffMember(5, "Gerardin", "Isabelle", false, "", "0475671038", "BE80 1782 4490 9113", "120, rue des drapiers 7000 Mons", 41000));
            //staff.Add(new Manager(6, "Balkan", "Fred", true, "balkan@gmail.com", "0479001280", "BE89 1190 1127 2280", "10, rue grande 6340 Nimy", 54000, "TrucMachin01"));
            //staff.Add(new StaffMember(7, "Gutierez", "Manolo", true, "manolo140@gmail.com", "0498671011", "BE70 9012 1034 1931", "8, rue de la riviere 7000 Mons", 29800));

            //int staffCount = staff.Count;  //a)


            //int lastId = staff.Max(stMemb => stMemb.Id); //b)


            ////b Est-ce que tout le monde a bien un N° mobile renseigné ? donc  un N° de mobile pas égal à rien ou chaine vide.

            //bool allHavePhoneNumber = staff.All(stMemb => !string.IsNullOrEmpty(stMemb.MobilePhoneNumber));


            ////c) Est - ce qu’il y a un membre injoignable, qui n’a pas de N° de téléphone ni d’Email renseignés ? donc any au moins un qui a son mobile null ou vide ET son mail null ou vide

            //bool noEMailNoPhone = staff.Any(stMemb => string.IsNullOrEmpty(stMemb.MobilePhoneNumber) && string.IsNullOrEmpty(stMemb.Email));


            ////d) Le premier membre(celui du c)) (sa référence) qui n’a pas de N° de téléphone ni d’Email renseignés

            //StaffMember staffMemberWithNoEMailNoPhone = staff.First(stMemb => string.IsNullOrEmpty(stMemb.MobilePhoneNumber) && string.IsNullOrEmpty(stMemb.Email));


            ////e) La collection des employés n’ayant pas d’email renseigné : les membres pour lesquels la propriété Email est null ou vide

            //ObservableCollection<StaffMember> selectNoMail = new ObservableCollection<StaffMember>(staff.Where(stMemb => string.IsNullOrEmpty(stMemb.Email)));

            ////f)La collection des employées(de genre féminin). les membres pour lesquels la propriété Gender est à false

            //ObservableCollection<StaffMember> selectWomans = new ObservableCollection<StaffMember>(staff.Where(stMemb => !stMemb.Gender == false));

            ////g)La collection des employés résidant à Mons. Les membres dont pour lesquels la propriété Address n'est pas null (sinon ca plante) et dont l'adresse contient le cd postal 7000

            //ObservableCollection<StaffMember> montois = new ObservableCollection<StaffMember>(staff.Where(stMemb => stMemb.Address != null && stMemb.Address.Contains("7000")));

            ////h) La collection des managers. Les membres de type <Manager>

            //ObservableCollection<StaffMember> managers = new ObservableCollection<StaffMember>(staff.OfType<Manager>());

            ////i) La collection des employés triés par ordre alphabétique de nom de famille.

            //ObservableCollection<StaffMember> staffSortedAlphabetically = new ObservableCollection<StaffMember>(staff.OrderBy(stMemb => stMemb.LastName));

            ////j) Le pourcentage d’hommes dans le personnel(en une seule ligne de code).

            //double ManPercentage = 100 * (double)staff.Count(stMemb => stMemb.Gender == true) / staff.Count;

            ////k) pas possible  Salary n'est pas accessible!!! 

        }

        private void buttonTestItemsCollection_Clicked(object sender, EventArgs e)
        {
            Soft coca = new Soft(1, name: "Coca cola", "", 3.30, 21.0, "coca.jpg",  25);
            Soft fanta = new Soft(2, name: "Fanta", "", 3.30, 21.0, "fanta.jpg",  25);
            Beer brassTemps = new Beer(3, name: "Carapils", "", 3.30, 21.0, "biere.jpg", 25, 6.0, false, false);
            Dish spaghBolo = new Dish(4, "Spaghetti bolo", "", 15.30, 21.0, "bolo.jpg");
            Soft coca2 = new Soft(5, name: "Coca cola", "", 3.30, 21.0, "coca.jpg", 25);
            ItemsCollection itCol = new ItemsCollection();
            itCol.AddItem(coca);
            itCol.AddItem(fanta);
            itCol.AddItem(brassTemps);
            itCol.AddItem(spaghBolo);
            itCol.AddItem(coca2);//test to add an item who have the same name as another already in the list
            itCol.DeleteItem(brassTemps);//delete one item
            itCol.IndexPrices(5.00); //index 5% all prices fonction foreach plus fonctionnelle
        }

        private void buttonTestReadWriteTextFileWithList_Clicked(object sender, EventArgs e)
        {
            string csvFilePath = @"C:\Users\Max\Desktop\IRAM\INF\POO\Brasserie\Brasserie\Configuration\Datas\Csv\PersonsRewrite.csv";
            //ObservableCollection<string> personsList = new ObservableCollection<string>();//create empty collection of string
            ObservableCollection<string> personsList = new ObservableCollection<string>(File.ReadAllLines(csvFilePath)); // copy each line in the collection
            string s = "";
            foreach (string line in personsList)
            {
                s += $"\n{line}";
            }
            lblDebug.Text = s; //print collection's content
                               //Add persons to collection.
            personsList.Add("Customer;10;Maggi;Toni;true;maggiton@gmail.com;0491609830;Occasional");
            personsList.Add("Customer;11;Fernez;Jean;true;jeanfernez@gmail.com;0480458801;Regular");
            //write all lines in a new csv file.
            File.WriteAllLines(@"C:\POO\Brasserie\Configuration\Datas\Csv\PersonsRewrite.csv", personsList);
            // chemin pc portable : C:\POO\Brasserie\Configuration\Datas\Csv\  incorrect
            //chemin tour : C:\Users\Max\Desktop\IRAM\INF\POO\Brasserie\Brasserie\Configuration\Datas\Csv\PersonsRewrite.csv
        }

        private void buttonTestPolymorphism_Clicked(object sender, EventArgs e)
        {
            Beer brasseTemps = new Beer(id: 3, name: "Brasse Temps", description: "", unitPrice: 3.30, pictureName: "biere.jpg", vatRate: 21.0, volume: 25, percentage: 6.0, isTrappistBeer: false, isAbbeyBeer: false);
            Alcohol al = brasseTemps;
            Drink d = brasseTemps;
            Item it = brasseTemps;

            //brasseTemps = it;
            lblDebug.Text = it.GetType().ToString();

            Beer b = (Beer)it;
        }

        private void buttonTestInterfaceAndDataAccess_Clicked(object sender, EventArgs e)
        {
            string CONFIG_FILE = CONFIG_PORT_CSV;
            DataFilesManager dataFilesManager = new DataFilesManager(CONFIG_FILE);
            DataAccessCsvFile da = new DataAccessCsvFile(dataFilesManager);
            ItemsCollection items = da.GetAllItems();
            items.ToList().ForEach(it => lblDebug.Text += $"\n Item: {it.Name} - prix {it.UnitPrice.ToString()}€ - {it.AutoDescription()}");
            CustomersCollection customers = da.GetAllCustomers();
            customers.ToList().ForEach(c => lblDebug.Text += $"\n Client:{c.Id} {c.FirstName} {c.LastName}");

            //chemin pc portable C:\POO\Brasserie\Configuration\Datas\Config.txt
            //chemin tour  C:\Users\Max\Desktop\IRAM\INF\POO\Brasserie\Brasserie\Configuration\Datas\Config.txt
        }

        private void buttonTestStaffMembersAndManagers_Clicked(object sender, EventArgs e)
        {
            string CONFIG_FILE = CONFIG_PORT_CSV;
            DataFilesManager dataFilesManager = new DataFilesManager(CONFIG_FILE);
            DataAccessCsvFile da = new DataAccessCsvFile(dataFilesManager);
            StaffMembersCollection sm = da.GetAllStaffMembers();
            sm.ToList().ForEach(m => lblDebug.Text += $"\n Prenom : {m.FirstName} - Nom : {m.LastName}  - Adresse : {m.Address}  ");
        }

        private void buttonTestDataAccessJsonFile_Clicked(object sender, EventArgs e)
        {
            string CONFIG_FILE = CONFIG_PORT_JSON;
            DataFilesManager dataFilesManager = new DataFilesManager(CONFIG_FILE);
            DataAccessJsonFile da = new DataAccessJsonFile(dataFilesManager);
            ItemsCollection items = da.GetAllItems();
            items.ToList().ForEach(it => lblDebug.Text += $"\n Item: {it.Name} - prix {it.UnitPrice.ToString()}€ - {it.AutoDescription()}");
            items[0].Description = "on a change la description du 1er item";
            items[5].UnitPrice = 99.9; //changement du prix du 6ème item
                                       //sauvegarde des données
            da.UpdateAllItems(items);
            //items.AddItem(new Dish(id: 70, name: "Pizza Royale", description: "une pizza avec tout dessus", unitPrice: 25.0, vatRate: 21.0, pictureName: "pizza.jpg"));
            //items.DeleteItem(items[-2]);//suppression du 3ème item
            //items.ToList().ForEach(it => lblDebug.Text += $"\n Item: {it.Name} - prix {it.UnitPrice.ToString()}€ - {it.AutoDescription()}");
            //da.UpdateAllItems(items);//sauvegarde des données après ajout et suppression
            StaffMembersCollection sm = da.GetAllStaffMembers();
            sm.ToList().ForEach(m => lblDebug.Text += $"\n Prenom : {m.FirstName} - Nom : {m.LastName}  - Adresse : {m.Address}  ");
        }

        private void buttonTestCreateJsonFIleFromCsvSource_Clicked(object sender, EventArgs e)
        {
            string CONFIG_CSV_FILE = CONFIG_PORT_CSV;
            string CONFIG_FILE = CONFIG_PORT_JSON; //contain json paths
            DataFilesManager dfmCsv = new DataFilesManager(CONFIG_CSV_FILE);
            DataAccessCsvFile daCsv = new DataAccessCsvFile(dfmCsv);
            ItemsCollection ic = daCsv.GetAllItems(); //get ItemsCollection from csv source
            StaffMembersCollection smc = daCsv.GetAllStaffMembers(); //get StaffMembersCollection from csv source
            DataFilesManager dfmJson = new DataFilesManager(CONFIG_FILE);
            DataAccessJsonFile daJson = new DataAccessJsonFile(dfmJson);
            daJson.UpdateAllItems(ic); //create json file from ic ItemsCollection populated with csv datas
            daJson.UpdateAllStaffMembers(smc); //create json file from smc StaffMembersCollection populated with csv datas
        }
    }

}

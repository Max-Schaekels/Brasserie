using Brasserie.Model;
using Brasserie.Model.Restaurant.Catering;
using Brasserie.Model.Restaurant.Design;
using Brasserie.Model.Restaurant.People;
using static Brasserie.Model.Restaurant.People.Customer;

namespace Brasserie.View
{
    public partial class MainPage : ContentPage
    {
        //int count = 0;

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

        private void buttonTestCreateFirstPersons_Clicked(object sender, EventArgs e)
        {
            Person firstPerson = new Person(id: 1, lastName: "Beumier", firstName: "Damien", gender: true, email: "dambeumier@gmail.com", mobilePhoneNumber: "0489142293");
            Person secondPerson = new Person(id: 2, lastName: "Deroisin", firstName: "Sophie", gender: false, email: "sophiederoisin@gmail.com", mobilePhoneNumber: "0473121314");
            Person ThirdPerson = new Person(3, "Jandrin", "Marc", true, "jandrinmarc@gmail.com", mobilePhoneNumber: "0485556678");
            Person FourthPerson = new Person(4, "Lupant", "Sebastien");
            Person FifthPerson = new Person();
            //Person TestPerson = new Person( lastName: "Lupant", firstName: "Sebastien");

            Person p;

            p = new Person(6, "Tardif", "Jean");

            //secondPerson._email = "04.be";
            //secondPerson._mobilePhoneNumber = "44719";

        }

        private void buttonTestEncapsulation_Clicked(object sender, EventArgs e)
        {
            Person p = new Person(id: 2, lastName: "Deroisin", firstName: "Sophie", gender: false, email: "sophiederoisin@gmail.com", mobilePhoneNumber: "0473121314");
            p.FirstName = "Dark-Vador";
            lblDebug.Text = p.FirstName;
        }

        private void buttonTestCreateItem_Clicked(object sender, EventArgs e)
        {
            Item item = new Item(id : 1, name: "Lasagne", description: "une grosse assiette de lasagne",unitPrice: 20.0, vatRate: 21.0, pictureName: "patebolo.jpg" );
            lblItemDebug.Text = $"Id : {item.Id} Name : {item.Name} Description : {item.Description} UnitPrice : {item.UnitPrice} VatRate : {item.VatRate} PictureName : {item.PictureName}";
        }

        private void buttonTestStatic_Clicked(object sender, EventArgs e)
        {
            string mail = "mon mail@gmail.com";
            bool testMail = Person.CheckEMail(mail);
            //lblDebug.Text = $"résultat du test de validité du mail {mail} : {testMail.ToString()}";
            lblDebug.Text = $"Nombre d'instances de classe Person : {Person.TotalPersons}";
        }

        private void buttonTestTable_Clicked(object sender, EventArgs e)
        {
            Table table = new Table( 1, 4, true);
        }

        private void buttonTestInheritance_Clicked(object sender, EventArgs e)
        {
            Customer c = new Customer(7, "Maggi", "Francesca", false, "francesca190@gmail.com", "0475689034", CustomerType.New);
            StaffMember staffm = new StaffMember(8, "Dries", "François", true, "francoisdries@gmail.com", "0485113289", "BE83 2378 9876 2390", "4, rue du marais 7030 Ghlin", 3275.0);
            Manager m = new Manager(9, "Duchief", "Marc", true, "duchiefmarc@gmail.com", "0491203040", "BE84 1128 9836 3518", "2, rue du pont 7000 Mons", 5200.5, "Password01");
        }

        private void buttonTestDerivateItems_Clicked(object sender, EventArgs e)
        {
            Item item = new Item(id: 1, name: "Lasagne", description: "une grosse assiette de lasagne", unitPrice: 20.0, vatRate: 21.0, pictureName: "lasagne.jpg");
            Drink drink = new Drink(id: 2, name: "Coca", description: "une canette de coca", unitPrice: 2.0, vatRate: 21.0, pictureName: "coca.jpg", 33.0);
            Dish dish = new Dish(id: 3, name: "Pizza", description: "une grosse pizza", unitPrice: 15.0, vatRate: 21.0, pictureName: "pizza.jpg");
            Soft soft = new Soft(id: 4, name: "Ice-Tea", description: "une canette d'ice tea", unitPrice: 2.5, vatRate: 21.0, pictureName: "icetea.jpg", volume: 33.0);
            Alcohol alcohol = new Alcohol(id: 5, name: "Leffe", description: "une bouteille de Leffe", unitPrice: 3.0, vatRate: 21.0, pictureName: "leffe.jpg", volume: 50.0, percentage: 6.6);
            Beer beer = new Beer(id: 6, name: "Jupiler", description: "une canette de Jupiler", unitPrice: 2.5, vatRate: 21.0, pictureName: "jupiler.jpg", volume: 33.0, percentage: 5.2, isAbbeyBeer: false, isTrappistBeer : false);
            Aperitif aperitif = new Aperitif(id: 7, name: "Campari", description: "un verre de Campari", unitPrice: 4.0, vatRate: 21.0, pictureName: "campari.jpg", volume: 5.0, percentage: 25.0);

        }
    }

}

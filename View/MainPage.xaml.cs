using Brasserie.Model;
using Brasserie.Model.Restaurant.Catering;
using Brasserie.Model.Restaurant.People;

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


    }

}

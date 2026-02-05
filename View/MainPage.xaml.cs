using Brasserie.Model;
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
        }


    }

}

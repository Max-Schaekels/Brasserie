using Brasserie.Model;

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

        private void OnCounterClicked(object sender, EventArgs e)
        {
            //count++;

            //if (count == 1)
            //    CounterBtn.Text = $"Clicked {count} time";
            //else
            //    CounterBtn.Text = $"Clicked {count} times";

            //EntryCount.Text = count.ToString();

            myCounter.IncrementCounter();

            if (myCounter.CounterValue == 1)
                CounterBtn.Text = $"Clicked {myCounter.CounterValue} time";
            else
                CounterBtn.Text = $"Clicked {myCounter.CounterValue} times";

            EntryCount.Text = myCounter.CounterValue.ToString();

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        
    }

}

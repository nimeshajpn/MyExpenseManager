using MyExpenseManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;
[assembly: ExportFont("Poppins-Bold.ttf" , Alias = "Poppins-Bold")]
[assembly: ExportFont("Poppins-ExtraLight.ttf", Alias = "Poppins-ExtraLight")]
[assembly: ExportFont("Poppins-Light.ttf", Alias = "Poppins-Light")]
namespace MyExpenseManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainExpense : ContentPage
    {
        private double _Total;
        private double _Income;
        private double _Expense;
        private string _Date;


        public double Total
        {

            get => _Total;
            set
            {

                _Total = value;
                OnPropertyChanged();

            }


        }
        public double Income
        {

            get => _Income;
            set
            {

                _Income = value;
                OnPropertyChanged(nameof(Income));

            }


        }
        public double Expense
        {

            get => _Expense;
            set
            {

                _Expense = value;
                OnPropertyChanged();

            }


        }
        public string Date
        {

            get => _Date;
            set
            {

                _Date = value;
                OnPropertyChanged();

            }


        }



        public MainExpense()
        {
            InitializeComponent();
            BindingContext= this;

            Lord();
        }

        public async void Lord() {

            var item = new List<Emodel>();
              item   = await App.sql.ReadE();

            MyCollection.ItemsSource=  item;

            foreach (Emodel eitem in item)
            {
              
                    
                        if (eitem.Type == "InCome")
                        {

                            Income = Income + eitem.Amount;


                        }
                        else { 
                        
                            Expense= Expense+ eitem.Amount;
                        
                        }
                    
                    
                    
                
                
                
                


            }
            Total = Income - Expense;
            lbDate.Text = DateTime.Now.ToString();
            lbExpense.Text = Expense.ToString();
            lbIncome.Text = Income.ToString();
            lbTotal.Text = Total.ToString();
        }



       





           
        private void btn1Main(object sender, EventArgs e)
        {

           Navigation.PushAsync(new AddExpense());
        }

       async void Swipe(object sender, EventArgs k)
        {
             var item = sender as SwipeItem;
            var emp = item.CommandParameter as Emodel;
            await Navigation.PushAsync(new AddExpense(emp));

        }

        async void SwipeDelete(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var emp = item.CommandParameter as Emodel;
            var result = await DisplayAlert("Delete",$"Delete{emp.Name}","Yes","No");
            if (result) {


                await App.sql.DeleteE(emp);
                MyCollection.ItemsSource = await App.sql.ReadE();
            
            }
        }
    }
}
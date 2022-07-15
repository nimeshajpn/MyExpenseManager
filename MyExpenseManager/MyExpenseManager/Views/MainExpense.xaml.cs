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

        ObservableCollection<Emodel> e;
        public MainExpense()
        {
            InitializeComponent();



        }

        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                MyCollection.ItemsSource = await App.sql.ReadE();
            }

            catch (Exception)
            {


            }
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyExpenseManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddExpense : ContentPage
    {
        public AddExpense()
        {
            InitializeComponent();
        }







        Models.Emodel _emp;
        
        
        public AddExpense(Models.Emodel emp)
        {
            InitializeComponent();
            Title = "Update";
            _emp = emp;
            tb.Text=emp.Name;
            tb.Focus();



        }

        public async void btn2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tb.Text) )
            {
                await DisplayAlert("Error", "Invalid", "ok");

            }

            else if (_emp!=null) {

                editeemp();
            
            }
            else
            {
               
                addNew();
            }  
            

           async void addNew() {

               
                await App.sql.CreateE(new Models.Emodel
                {
                    Amount = double.Parse(tb.Text),
                    Category = pp.SelectedItem.ToString(),
                    Type = TypePicker.SelectedItem.ToString(),
                    Date = Datep.Date+ Timep.Time,
                }

                    );   
            
            await Navigation.PopAsync();
            
            }

          
            
            
            async void editeemp() {


                _emp.Name = tb.Text;

                await App.sql.UpdateE(_emp);
                await Navigation.PopAsync();
            }













        }
    }
}

using MyExpenseManager.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
   
namespace MyExpenseManager
{
    public partial class App : Application
    {

        private static SqlHelper db;

        public static SqlHelper sql {

            get
           {
                if (db == null) {

                    db = new SqlHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"MyStore.db3"));
                }

                return db;
            
            }
        
        
        
        
        }
        public App()
        {
            InitializeComponent();


            MainPage = new NavigationPage(new MainExpense());
        }
 
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
[assembly: ExportFont("Poppins-Bold.ttf")]
namespace MyExpenseManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainExpense : ContentPage
    {
        public MainExpense()
        {
            InitializeComponent();
        }
    }
}
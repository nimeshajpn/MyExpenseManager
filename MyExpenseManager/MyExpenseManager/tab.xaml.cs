using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyExpenseManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class tab : TabbedPage
    {
        public tab()
        {
            InitializeComponent();
        }
    }
}
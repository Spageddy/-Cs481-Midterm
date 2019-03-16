using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Midterm.Models;
using Xamarin.Forms;

namespace Midterm
{
    public partial class MainPage : TabbedPage
    {
        public ObservableCollection<TimeSeriesDaily> dailyList;

        public MainPage()
        {
            InitializeComponent();

            Children.Add(new Search() { Title="search"});


            Children.Add(new Chart() { Title = "Chart" });
         
            
        }

    }
}

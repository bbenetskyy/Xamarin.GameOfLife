using GameOfLie.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
    
namespace GameOfLie
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartupRoom : ContentPage
    {
        public StartupRoom()
        {
            InitializeComponent();
            BindingContext = new StartupRoomViewModel();
        }

        private void Handle_ItemTapped(object sender, Syncfusion.SfRadialMenu.XForms.ItemTappedEventArgs e)
        {
            Syncfusion.SfRadialMenu.XForms.SfRadialMenuItem item1 = sender as Syncfusion.SfRadialMenu.XForms.SfRadialMenuItem;
            //item1.BackgroundColor;
            teamUSARadialMenu.Close();
        }
    }
}
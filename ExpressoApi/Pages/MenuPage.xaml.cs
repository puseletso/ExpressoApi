using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressoApi.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Menu = ExpressoApi.Models.Menu;

namespace ExpressoApi.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {

        //contains the full list
        public ObservableCollection<Menu> Menus;

        public MenuPage()
        {
            InitializeComponent();
            Menus = new ObservableCollection<Menu>();

        }
        //function will return list of menu
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ApiServices apiServices = new ApiServices();
            var menus = await apiServices.GetMenu();

            //to show the full list one by one we use the foreach loop
            foreach (var menu in menus)
            {
                Menus.Add(menu);
                
            }

            LvMenu.ItemsSource = Menus;

        }
    }
}
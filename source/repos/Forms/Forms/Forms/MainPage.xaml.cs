using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Forms
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void OnRouteClick(object sender, EventArgs args)
        {
            String start = origin.Text.ToUpper();
            String end = destination.Text.ToUpper();
            end = Buildings(end);
            start = Buildings(start);
            route.Text = "";
            route.Text = String.Format("Routing from {0} to {1}.", start, end);
        }

        String Buildings (String buildingCode)
        {
            if (buildingCode == "MBH")
                return "BiHall";
            else if (buildingCode == "CHT")
                return "Chateau";
            else
                return "error";
        }

    }
}

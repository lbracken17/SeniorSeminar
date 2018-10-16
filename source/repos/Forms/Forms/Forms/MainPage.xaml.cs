using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin;
using Plugin.Geolocator;
using Xamarin.Forms.Maps;

namespace Forms
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var locator = CrossGeolocator.Current;
            //if (IsLocationAvailable())
              //  map.IsShowingUser = true;
            //map.IsShowingUser = true;
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(44.011, -73.18), Distance.FromMiles(1)));
        }

        public bool IsLocationAvailable()
        {
            if (!CrossGeolocator.IsSupported)
                return false;

            return CrossGeolocator.Current.IsGeolocationAvailable;
        }

        void OnRouteClick(object sender, EventArgs args)
        {
            
            String start = origin.Text.ToUpper();
            String end = destination.Text.ToUpper();
            end = Buildings(end);
            start = Buildings(start);
            route.Text = "";
            if (start == "ERROR.")
                route.Text = "Unfortunately, your start location is not recognized.";
            else if (end == "ERROR.")
                route.Text = "Unfortunately, your destination is not recognized.";
            else
                route.Text = String.Format("Routing from {0} to {1}.", start, end);
        }

        String Buildings (String buildingCode)
        {
            if (buildingCode == "MBH")
                return "BiHall";
            else if (buildingCode == "CHT")
                return "Chateau";
            else if (buildingCode == "ADK")
                return "Adirondack";
            else if (buildingCode == "ADK CLT")
                return "Adirondack Coltrane Lounge";
            else if (buildingCode == "ATA")
                return "Atwater A";
            else if (buildingCode == "ATD")
                return "Atwater Dining- Seminar Room";
            else if (buildingCode == "AXN")
                return "Axinn";
            else if (buildingCode == "AXT")
                return "Twilight";
            else if (buildingCode == "AXT AUD")
                return "Twilight Auditorium";
            else if (buildingCode == "CHL")
                return "Chellis";
            else if (buildingCode == "CHL SEM")
                return "Chellis Seminar Room";
            else if (buildingCode == "CRH")
                return "Carr Hall";
            else if (buildingCode == "FIC")
                return "Freeman International Center";
            else if (buildingCode == "FIC CK")
                return "Freeman- Cook Seminar Room";
            else if (buildingCode == "FIC FR")
                return "Freeman Seminar Room";
            else if (buildingCode == "FIC HAM")
                return "Freeman- Hamlin Seminar Room";
            else if (buildingCode == "GFD")
                return "Gifford";
            else if (buildingCode == "GFD LCT")
                return "Gifford Annex Classroom";
            else if (buildingCode == "HLD")
                return "Hillcrest";
            else if (buildingCode == "HPB")
                return "Hepburn";
            else if (buildingCode == "HPB SEM")
                return "Hepburn Seminar Room";
            else if (buildingCode == "JHN")
                return "Johnson";
            else if (buildingCode == "KYN")
                return "Kenyon Classroom";
            else if (buildingCode == "KYN NAT")
                return "Natatorium";
            else if (buildingCode == "LAF")
                return "Laforce Hall";
            else if (buildingCode == "LIB")
                return "Davis Library";
            else if (buildingCode == "MCA")
                return "Mahaney Center for the Arts";
            else if (buildingCode == "MCA MUS")
                return "Mahaney- Museum of Art";
            else if (buildingCode == "MCA THE")
                return "Mahaney- Seeler Studio Theater";
            else if (buildingCode == "MDC" || buildingCode == "MDC CHAPEL")
                return "Mead Chapel";
            else if (buildingCode == "MFH")
                return "Memorial Field House";
            else if (buildingCode == "MFH CLM")
                return "Field House- Climbing Wall";
            else if (buildingCode == "MFH FIT")
                return "Field House- Fitness Center";
            else if (buildingCode == "MFH MUS")
                return "Field House- Multi-Use Area";
            else if (buildingCode == "MFH NEL")
                return "Field House- Nelson Rec Center";
            else if (buildingCode == "MFH PEP")
                return "Field House- Pepin Gym";
            else if (buildingCode == "MNR")
                return "Munroe";
            else if (buildingCode == "OCH")
                return "Old Chapel";
            else if (buildingCode == "PRS")
                return "Pearsons";
            else if (buildingCode == "PRS KAD")
                return "Pearsons Kade Room";
            else if (buildingCode == "PST")
                return "Prescott House";
            else if (buildingCode == "PST BMT")
                return "Prescott House Basement";
            else if (buildingCode == "RAJ" || buildingCode == "RAJ CON")
                return "Rohatyn (Robert A Jones Conference Room)";
            else if (buildingCode == "RCD B11")
                return "Ross Seminar Room B11";
            else if (buildingCode == "SDL")
                return "Sunderland";
            else if (buildingCode == "SDL DNA")
                return "Dana Auditorium (in Sunderland)";
            else if (buildingCode == "SDL LAN")
                return "Sunderland Language Lab";
            else if (buildingCode == "WNS")
                return "Warner";
            else if (buildingCode == "WNS HEM")
                return "Warner Hemicycle";
            else if (buildingCode == "WTH")
                return "Wright";
            else if (buildingCode == "WTH SEM")
                return "Wright Seminar Room";
            else if (buildingCode == "WTH THE")
                return "Wright Theater";
            else
                return "ERROR.";



        }

    }
}

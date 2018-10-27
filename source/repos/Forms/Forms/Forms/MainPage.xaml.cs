using System;
using Xamarin.Forms;
using Plugin.Geolocator;
using Xamarin.Forms.Maps;
using Android.Gms.Maps.Model;
using System.Collections.Generic;

namespace Forms
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var locator = CrossGeolocator.Current;
            var position = locator.GetPositionAsync(TimeSpan.FromSeconds(10));
            //if (IsLocationAvailable())
            //  map.IsShowingUser = true;
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(44.011, -73.18), Distance.FromMiles(0.5)));

        }


        
        


        public bool IsLocationAvailable()
        {
            if (!CrossGeolocator.IsSupported)
                return false;

            return CrossGeolocator.Current.IsGeolocationAvailable;
        }

        protected async override void OnAppearing()
        {

            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var position = await locator.GetPositionAsync();
            var testPosition = new Position(position.Longitude, position.Latitude);
            Pin pin = new Pin()
            {
                Position = new Position(44.011, -73.18),
                Label = "Test 1"

            };

            

            //map.Pins.Add(pin);
        }

        void OnRouteClick(object sender, EventArgs args)
        {
            IDictionary<string, (double, double)> latAndLng = new Dictionary<string, (double, double)>() {
                {"MBH", (44.013613, -73.181267) },
                {"CHT", (44.012532, -73.177956) },
                {"ADK", (44.010270, -73.180055) },
                {"ADK CLT", (44.010693, -73.180226) },
                {"ATA", (44.013476, -73.178599) },
                {"ATD", (44.013271, -73.177286) },
                {"AXN", (44.008015, -73.176100) },
                {"AXT", (44.010899, -73.172218) },
                {"AXT AUD", (44.010899, -73.172218) },
                {"CHL", (44.009364, -73.180513) },
                {"CHL SEM", (44.009364, -73.180513) },
                {"CRH", (44.010622, -73.178376) },
                {"FIC", (44.013886, -73.180320) },
                {"FIC CK", (44.013886, -73.180320) },
                {"FIC FR", (44.013886, -73.180320) },
                {"FIC HAM", (44.013886, -73.180320) },
                {"GFD", (44.009738, -73.178995) },
                {"GFD LCT", (44.009731, -73.179271) },
                {"HLD", (44.009857, -73.179857) },
                {"HPB", (44.008547, -73.178795) },
                {"HPB SEM", (44.008547, -73.178795) },
                {"JHN", (44.011480, -73.176649) },
                {"KYN", (44.003571, -73.178356) },
                {"KYN NAT", (44.003571, -73.178356) },
                {"LAF", (44.010428, -73.180779) },
                {"LIB", (44.009501, -73.174642) },
                {"MCA", (44.005193, -73.176151) },
                {"MCA MUS", (44.005193, -73.176151) },
                {"MCA THE", (44.005193, -73.176151) },
                {"MDC", (44.009126, -73.179034) },
                {"MDC CHAPEL", (44.009126, -73.179034) },
                {"MFH", (44.004447, -73.177367) },
                {"MFH CLM", (44.004447, -73.177367) },
                {"MFH FIT", (44.004447, -73.177367) },
                {"MFH MUS", (44.004447, -73.177367) },
                {"MFH NEL", (44.004447, -73.177367) },
                {"MFH PEP", (44.004447, -73.177367) },
                {"MNR", (44.010019, -73.177901) },
                {"OCH", (44.009098, -73.176071) },
                {"PRS", (44.011120, -73.180297) },
                {"PRS KAD", (44.011120, -73.180297) },
                {"PST", (44.008156, -73.182779) },
                {"PST BMT", (44.008156, -73.182779) },
                {"RAJ", (44.008068, -73.180575) },
                {"RAJ CON", (44.008068, -73.180575) },
                {"RCD", (44.010677, -73.181064) },
                {"RCD B11", (44.010677, -73.181064) },
                {"SDL", (44.010786, -73.176506) },
                {"SDL DNA", (44.010842, -73.176310) },
                {"SDL LAN", (44.010786, -73.176506) },
                {"WNS", (44.010169, -73.175476) },
                {"WNS HEM", (44.010266, -73.175409) },
                {"WTH", (44.011988, -73.177090) },
                {"WTH SEM", (44.011988, -73.177090) },
                {"WTH THE", (44.011988, -73.177090) }

            };
        String start = origin.Text.ToUpper();
            String end = destination.Text.ToUpper();
            if (latAndLng.ContainsKey(end))
            {
                var coordinatesLat = latAndLng[end].Item1;
                var coordinatesLong = latAndLng[end].Item2;

                Pin pinDest = new Pin()
                {
                    Position = new Position(coordinatesLat, coordinatesLong),
                    Label = "Test 1"

                };
                map.Pins.Add(pinDest);
            }
            end = Buildings(end);
            start = Buildings(start);
            route.Text = "";
            if (start == "ERROR." && end == "ERROR.")
                route.Text = "Neither origin nor destination are recognized. Please enter building codes (e.g. MBH).";
            else if (start == "ERROR.")
                route.Text = "Unfortunately, your start location is not recognized. Please enter a building code (e.g. MBH).";
            else if (end == "ERROR.")
                route.Text = "Unfortunately, your destination is not recognized. Please enter a building code (e.g. MBH).";
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
                return "Chromatic";
            else if (buildingCode == "PST BMT")
                return "Chromatic Basement";
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

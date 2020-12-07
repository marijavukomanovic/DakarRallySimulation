using Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

using System.Threading;
using System.Threading.Tasks;
using System.Windows;


namespace WPF__Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {/// <summary>
    /// SAMO SLUZI ZA TEST
    /// </summary>
        public string[] cmb1 { get; set; }
        public string[] cmb2 { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            cmb1 = new string []{ "Car", "Truck", "Motorcycle" };
            cmb2 = new string[] { "pending", "running", "finished" };
            DataContext = this;
            filterTimName.Text = " ";
            filterModel.Text = " ";
            filterDate.Text = "  ";

        }


        private async void GetVehicleByID_Click(object sender, RoutedEventArgs e)
        {
            
            var retVal = await HelperForApiGet.Get("Vehicles", "GetVehicle", Convert.ToInt32(tbGetVehicleByID.Text));
            lbGetAllhicle.Items.Clear();
            //HelperForApi.RedableJson(retVal.ToString());
            lbGetAllhicle.Items.Add(retVal);
        }

        private async void AddRace_Click(object sender, RoutedEventArgs e)//addRace(salje se godina odrzavanja trke)
        {
            string ret = await HelperForApiPost.Post("races","AddRace",Convert.ToInt32(RaceId.Text));
            MessageBox.Show(HelperForApi.RedableJson(ret));
        }

        private async void btGetAllRaces_Click(object sender, RoutedEventArgs e)//vracaju se sve trke
        {
            lbGetAllhicle.Items.Clear();
            var retVal = await (HelperForApiGet.GetAll("races", "GetAllRace"));
            lbGetAllRaces.Items.Add(HelperForApi.RedableJson(retVal.ToString()));

        }

        private async void btAddVehicle_Click(object sender, RoutedEventArgs e)//dodaj vozilo
        {
            string ret = await HelperForApiPost.Post(tbTeamName.Text, tbVeicleModel.Text, tbVeicleDate.Text);//ovo ispravi
            MessageBox.Show(ret);
        }

        private async void btUpdateVehicle_Click(object sender, RoutedEventArgs e)//update vozila
        {
            string ret = await HelperForApi.Put(Convert.ToInt32(tbVeicleId.Text), tbTeamName.Text, tbVeicleModel.Text, tbVeicleDate.Text);
            MessageBox.Show(HelperForApi.RedableJson(ret));
        }

        private async void btGetAllVehicles_Click(object sender, RoutedEventArgs e)
        {
            
           var retVl= await HelperForApiGet.GetAll("Vehicles", "GetVehicles");
            lbGetAllhicle.Items.Clear();
            HelperForApi.RedableJson(retVl);
            lbGetAllhicle.Items.Add(retVl);
        }

        private async  void btGetStatistic_Click(object sender, RoutedEventArgs e)
        {
           
            var retVal = await HelperForApiGet.Get("Vehicles", "GetVehicleStatistic", Convert.ToInt32(tbGetStatistic.Text));
            lbGetAllhicle.Items.Clear();
            lbGetAllhicle.Items.Add(retVal);
          
        }

        private async void btGetRaceStatus_Click(object sender, RoutedEventArgs e)
        {
            
            string retVal = await HelperForApiGet.Get("Races", "GetRaceStatus", Convert.ToInt32(tbGetRaceStatus.Text));
            lbGetAllhicle.Items.Clear();
            lbGetAllRaces.Items.Add(HelperForApi.RedableJson(retVal));
        }

        private async void btAddVehicleToRace_Click(object sender, RoutedEventArgs e)
        {

            string ret = await HelperForApiPost.Post("vehicleraces", "AddVehicleToRace", Convert.ToInt32(tbAddVEhicelToRace.Text));
            MessageBox.Show(HelperForApi.RedableJson(ret));
        }

        private async void btFilterType_Click(object sender, RoutedEventArgs e)
        {
           
            string retVal = await HelperForApiGet.Get("Vehicles", "GetAllVehiclesByType", cmb1[cmbDeviceDefinitionId.SelectedIndex]);
            lbGetAllhicle.Items.Clear();
            lbGetAllRaces.Items.Add(HelperForApi.RedableJson(retVal));
        }

        private async void StartRace_Click(object sender, RoutedEventArgs e)
        {
            string retVal = await HelperForApiGet.Get("races", "StartRace", Convert.ToInt32(tbStartRace.Text));
            lbGetAllhicle.Items.Clear();
            lbGetAllhicle.Items.Add("Ok");
           
        }

        private async void btfindBy_Click(object sender, RoutedEventArgs e)
        {
            
            string retVal = await HelperForApiGet.Get("Vehicles", "FindVehicle", filterTimName.Text, filterModel.Text, filterDate.Text, cmb2[cmbId.SelectedIndex],cbDistance.IsChecked.HasValue);
            lbGetAllhicle.Items.Clear();
            lbGetAllhicle.Items.Add("Ok");
        }
    }
}

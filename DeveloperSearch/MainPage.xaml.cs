using Com.OneSignal.Abstractions;
using DeveloperSearch.Model;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Push;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using RestSharp;
using Xamarin.Forms;

namespace DeveloperSearch
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer

    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        HttpClient client = new HttpClient();
        DevelopersList developers = new DevelopersList();
        //List<DevelopersDetails> developersDetails = new List<DevelopersDetails>();

        //Uri uri = new Uri("https://api.github.com/search/users?q=language:java%20location:lagos");
        //private string url = "https://api.github.com/search/users?q=language:java%20location:lagos";

        public MainPage()
        {
            InitializeComponent();

            GetDevelopers();
        }


        public async void GetDevelopers()
        {
            //RestSharp Code Snippet
            var client = new RestClient("https://api.github.com/search/users?q=language:java%20location:lagos");
            var request = new RestRequest(Method.GET);

            var response = await client.ExecuteAsync(request);
            var content = response.Content;

            developers = JsonConvert.DeserializeObject<DevelopersList>(content);
            listView.ItemsSource = developers.DevelopersDetails;
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new DeveloperPage(listView.SelectedItem));
        }
    }
}

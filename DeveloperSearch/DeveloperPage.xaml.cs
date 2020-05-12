using DeveloperSearch.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeveloperSearch
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeveloperPage : ContentPage
    {
        //List<DevelopersDetails> developers = new List<DevelopersDetails>();
        DevelopersDetails developersDetails = new DevelopersDetails();
        private object Name;

        public DeveloperPage(object selectedItem)
        {
            InitializeComponent();
            Name = selectedItem;
            GetDevelopers();

            imageButton.Source = ImageSource.FromResource("DeveloperSearch.Images.share-button.png");
            
        }

        public void GetDevelopers()
        {
                developersDetails = (DevelopersDetails)Name;

                image.Source = developersDetails.Avatar_url;
                name.Text = developersDetails.Login;
                profileLink.Text = developersDetails.Html_url;       
        }

        private void imageButton_Clicked(object sender, EventArgs e)
        {
            string text = "Hi there!" + "\n" + "" + "Check out this awesome developer through this link:" + "\n" + "";

            ShareTextAndUri(text, developersDetails.Html_url);
        }

        public async void ShareTextAndUri(string text, string uri)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = text,
                Uri = uri
            });
        }

       
    }
}
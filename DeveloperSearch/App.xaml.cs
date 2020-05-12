using System;
using System.Collections.Generic;
using Com.OneSignal;
using Com.OneSignal.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeveloperSearch
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
            OneSignal.Current.StartInit("0d764c95-67c2-48fa-9ef5-4ca2d76ee6e6")
                .HandleNotificationOpened(HandleNotificationOpened)
                  .EndInit();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        //More details: https://documentation.onesignal.com/docs/xamarin-sdk#section--notificationopened-
        private static void HandleNotificationOpened(OSNotificationOpenedResult result)
        {
            OSNotificationPayload payload = result.notification.payload;
            Dictionary<string, object> additionalData = payload.additionalData;
            string message = payload.body;
            string actionID = result.action.actionID;

            Console.WriteLine("GameControllerExample:HandleNotificationOpened: " + message);
            string extraMessage = "Notification opened with text: " + message;

            if (additionalData != null)
            {
                if (additionalData.ContainsKey("discount"))
                {
                    extraMessage = (string)additionalData["discount"];
                    // Take user to your store.
                }
            }
            if (actionID != null)
            {
                // actionSelected equals the id on the button the user pressed.
                // actionSelected will equal "__DEFAULT__" when the notification itself was tapped when buttons were present.
                extraMessage = "Pressed ButtonId: " + actionID;
            }
        }
    }
}

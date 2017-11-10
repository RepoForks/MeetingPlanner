using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Graph;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Leaver.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MeetingList : ContentPage
    {
        public MeetingList()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            WelcomeText.Text = $"Welcome {((User)App.Me).DisplayName}, your latest meetings:";
            var client = new GraphServiceClient("https://graph.microsoft.com/v1.0",
                new DelegateAuthenticationProvider(
                    async (requestMessage) =>
                    {
                        var tokenRequest = await App.IdentityClientApp.AcquireTokenSilentAsync(App.Scopes, App.IdentityClientApp.Users.FirstOrDefault());
                        requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", tokenRequest.AccessToken);
                    }));
            var events = await client.Me.Events.Request().GetAsync();
            var list = events.ToList<Event>();
            MeetingsListView.ItemsSource = list.Take(5);
        }
    }
}
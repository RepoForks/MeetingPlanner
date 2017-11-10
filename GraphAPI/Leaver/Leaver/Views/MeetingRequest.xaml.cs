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
    public partial class MeetingRequest : ContentPage
    {
        public MeetingRequest()
        {
            InitializeComponent();
        }

        private async void MenuItem_OnClicked(object sender, EventArgs e)
        {
            var calEvent = new Event
            {
                Subject = Subject.Text,
                Start = new DateTimeTimeZone
                {
                    DateTime = StartDate.Date.Add(StartTime.Time).ToString("yyyy-MM-ddTHH:mm:ss"),
                    TimeZone = "Asia/Kolkata"
                },
                End = new DateTimeTimeZone()
                {
                    DateTime = EndDate.Date.Add(EndTime.Time).ToString("yyyy-MM-ddTHH:mm:ss"),
                    TimeZone = "Asia/Kolkata"
                },
                Location = new Location() {DisplayName = Location.Text},
                Attendees = new List<Attendee>
                {
                    new Attendee() {EmailAddress = new EmailAddress() {Address = Attendee.Text}},
                }
            };

            var client = new GraphServiceClient("https://graph.microsoft.com/v1.0",
                new DelegateAuthenticationProvider(
                    async (requestMessage) =>
                    {
                        var tokenRequest = await App.IdentityClientApp.AcquireTokenSilentAsync(App.Scopes, App.IdentityClientApp.Users.FirstOrDefault());
                        requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", tokenRequest.AccessToken);
                    }));

            await client.Me.Events.Request().AddAsync(calEvent);

            await DisplayAlert("Event added", "Calendar invite added and sent to attendees", "Ok");

        }
    }
}
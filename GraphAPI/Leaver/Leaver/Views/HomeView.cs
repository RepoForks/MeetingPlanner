using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Leaver.Views
{
    class HomeView : TabbedPage
    {
        public HomeView()
        {
            this.Children.Add(new MeetingList());
            this.Children.Add(new MeetingRequest());
        }
    }
}

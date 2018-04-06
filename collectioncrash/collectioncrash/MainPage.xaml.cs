using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace collectioncrash
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		    TestingList.ItemsSource = App.Testing;
		    TestingList.BindingContext = App.Testing;

		    TestingList.RefreshCommand = new Command(async () =>
		    {
		        TestingList.IsRefreshing = true;
		        App.ResetList();
		        TestingList.IsRefreshing = false;

		    });
        }
	}
}

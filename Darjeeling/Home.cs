
using System;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Darjeeling
{
	[Activity (Label = "PreFloat", MainLauncher=true, Icon="@drawable/icon")]			
	public class Home : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Home);
			// Create your application here
		}
	}
}


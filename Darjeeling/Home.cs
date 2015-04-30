
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
			View view = new View(this);
			Button StartChecking = FindViewById<Button>(Resource.Id.btnStartChecking);
			StartChecking.Click += delegate {
				onClickStartChecking (view);
			};

			Button History = FindViewById<Button> (Resource.Id.btnHistory);
			History.Click += delegate(object sender, EventArgs e) {
				onClickHistory (view);
			};

			Button ManageLists = FindViewById<Button> (Resource.Id.btnManageLists);
			ManageLists.Click += delegate(object sender, EventArgs e) {
				onClickManageLists(view);
			};
		}
		public void onClickStartChecking (View view){

			Intent intent = new Intent(this, typeof(StartChecking));
			StartActivity(intent);
		}

		public void onClickManageLists (View view){
			Intent intent = new Intent (this, typeof(ManageLists));
			StartActivity (intent);
		}

		public void onClickHistory (View view){
			Intent intent = new Intent (this, typeof(History));
			StartActivity (intent);

		}
	}
}


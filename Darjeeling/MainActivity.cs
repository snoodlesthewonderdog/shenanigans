using System;

using Android.App;
using Android.Content;
using Android.Database;
using Android.Database.Sqlite;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Darjeeling
{
	[Activity (Label = "Darjeeling", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			// Create or open database
			Android.Database.Sqlite.SQLiteDatabase db = OpenOrCreateDatabase ("darjeeling", FileCreationMode.Private, null);
			db.ExecSQL ("create table if not exists checkLists(checkListID integer, checkListName varchar, checkListDesc varchar);");

			db.ExecSQL ("insert into checkLists values (0, 'Widgeon','Widgeon Daysailer');");
			db.ExecSQL ("insert into checkLists values (1, 'Bowrider', 'Mo Motor, Mo Fun');");

			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			Button myBtn = new Button (this);
			myBtn.Text = "hi there";

			LinearLayout ll = (LinearLayout)FindViewById (Resource.Id.linearLayout1);
			LinearLayout.LayoutParams lp = new LinearLayout.LayoutParams (LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.MatchParent);
			ll.AddView (myBtn, lp);



			/*
			LinearLayout ll = (LinearLayout)FindViewById (Resource.Id.linearLayout1);
			LinearLayout.LayoutParams lp = new LinearLayout.LayoutParams (LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.MatchParent);

			Button btn = new Button (this);
			TextView txt = new TextView (this);
			txt.Text = "sup?";
			txt.SetBackgroundColor = Android.Graphics.Color.AntiqueWhite;
			btn.Text = "hello world";	
			btn.SetBackgroundColor(Android.Graphics.Color.AliceBlue);
			//this.AddContentView (ll, lp);

			ll.AddView (txt, lp);
			txt.Visibility = ViewStates.Visible;

			// Get textview to display one of the checklist names
			TextView tv1 = FindViewById<TextView> (Resource.Id.textView1);
			

			Android.Database.ICursor c = db.RawQuery ("select * from checkLists where checkListName = 'Widgeon'", null);
			if (c.MoveToFirst ()) {
				tv1.Text = c.GetString (1).ToString ();
			}

			tv1.Text = "hi there";
			*/


			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {
				button.Text = string.Format ("{0} clicks!", count++);
			};






		}
	}
}


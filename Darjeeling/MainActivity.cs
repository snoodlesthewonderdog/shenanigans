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
	public class MainActivity : ListActivity
	{
		int count = 1;
		string[] items;
		protected override void OnCreate (Bundle bundle)
		{
			// Create or open database
			Android.Database.Sqlite.SQLiteDatabase db = OpenOrCreateDatabase ("darjeeling", FileCreationMode.Private, null);

			// Create checkListTypes table
			db.ExecSQL ("create table if not exists checkListType(checkListTypeID integer, checkListType varchar);");
			// Add values to checkListType table
			db.ExecSQL ("insert into checkListType values(0, 'Driveway');");
			db.ExecSQL ("insert into checkListType values(1, 'Pre-Float');");

			// Create checkLists table
			db.ExecSQL ("create table if not exists checkLists(checkListID integer, checkListType integer, checkListName varchar, checkListDesc varchar);");
			//  Add values to checkLists table
			db.ExecSQL ("insert into checkLists values (0, 0, 'Widgeon','Widgeon Daysailer');");
			db.ExecSQL ("insert into checkLists values (1, 1, 'Widgeon','Widgeon Daysailer');");
			db.ExecSQL ("insert into checkLists values (2, 0, 'Bowrider', 'Mo Motor, Mo Fun');");
			db.ExecSQL ("insert into checkLists values (3, 1, 'Bowrider', 'Mo Motor, Mo Fun');");
			db.ExecSQL ("insert into checkLists values (4, 0, 'HobieCat','Hang yer ass out fun');");
			db.ExecSQL ("insert into checkLists values (5, 1, 'HobieCat','Hang yer ass out fun');");

			base.OnCreate (bundle);

			items = new string[]{ "Fruits", "Vegetables","Flower Buds","Legumes","Bulbs","Tubers"};
			//ListAdapter = new ArrayAdapter<String> (this, Android.Resource.Layout.SimpleListItemMultipleChoice, items);


			Android.Database.ICursor c = db.RawQuery ("select checkListName from checkLists", null); // where checkListName = 'Widgeon'", null);

			StartManagingCursor (c);

			TextView tv1 = new TextView (this);
			if (c.MoveToFirst ()) {
				tv1.Text = c.GetString(0).ToString ();  //c.GetString (1).ToString ();
			}

			Android.Widget.Toast.MakeText (this, tv1.Text.ToString(), Android.Widget.ToastLength.Long).Show (); //  (this, t + " " + position, Android.Widget.ToastLength.Short).Show ();
			/*
			string[] fromColumns = new string[]{ "checkListName" }; //{ "checkListID, checkListType, checkListName, checkListDesc" };
			int[] toControlIDs = new int[] { Android.Resource.Id.Text1 };

			//ListView lv = new ListView (this);

			//ListAdapter = new SimpleCursorAdapter(this, Android.Resource.Layout.SimpleListItemMultipleChoice, c, fromColumns, toControlIDs);
			*/
			StopManagingCursor (c);
			c.Close ();




			// Set our view from the "main" layout resource

			//SetContentView (Resource.Layout.Main);

			/*
			Button myBtn = new Button (this);
			myBtn.Text = "hi there";

			LinearLayout ll = (LinearLayout)FindViewById (Resource.Id.linearLayout1);
			LinearLayout.LayoutParams lp = new LinearLayout.LayoutParams (LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.MatchParent);
			ll.AddView (myBtn, lp);
			*/


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
			/*
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {
				button.Text = string.Format ("{0} clicks!", count++);
			};
			*/

		}
		//  End onCreate method

		protected override void OnListItemClick (ListView l, View v, int position, long id)
		{
			base.OnListItemClick (l, v, position, id);
			var t = items [position];
			l.ChoiceMode = ChoiceMode.Multiple;

			//if (l.IsItemChecked(position) == true)
			//	l.SetItemChecked (0, false);
			//else
			l.SetItemChecked (5, true);
			Android.Widget.Toast.MakeText (this, t + " " + position, Android.Widget.ToastLength.Short).Show ();

		}





	}
}


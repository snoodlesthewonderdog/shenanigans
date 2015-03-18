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
		string[] items;
		ListView listView;
		Darjeeling.VegetableDatabase vdb;
		ICursor c;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			listView = FindViewById<ListView> (Resource.Id.listView1);
			vdb = new VegetableDatabase (this);
			c = vdb.ReadableDatabase.RawQuery ("select * from vegetables", null);

			// Create or open database
			Android.Database.Sqlite.SQLiteDatabase db = OpenOrCreateDatabase ("darjeeling", FileCreationMode.Private, null);

			// Create checkListTypes table
			db.ExecSQL ("create table if not exists checkListType(checkListTypeID integer, checkListType varchar);");
			// Add values to checkListType table
			db.ExecSQL ("insert into checkListType values(0, 'Driveway');");
			db.ExecSQL ("insert into checkListType values(1, 'Pre-Float');");

			// Create checkLists table
			db.ExecSQL ("create table if not exists checkLists([_id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE, checkListID integer, checkListType integer, checkListName text, checkListDesc text);");
			//  Add values to checkLists table
			db.ExecSQL ("insert into checkLists values (0, 0, 'Widgeon','Widgeon Daysailer');");
			db.ExecSQL ("insert into checkLists values (1, 1, 'Widgeon','Widgeon Daysailer');");
			db.ExecSQL ("insert into checkLists values (2, 0, 'Bowrider', 'Mo Motor, Mo Fun');");
			db.ExecSQL ("insert into checkLists values (3, 1, 'Bowrider', 'Mo Motor, Mo Fun');");
			db.ExecSQL ("insert into checkLists values (4, 0, 'HobieCat','Hang yer ass out fun');");
			db.ExecSQL ("insert into checkLists values (5, 1, 'HobieCat','Hang yer ass out fun');");



			items = new string[]{ "Fruits", "Vegetables","Flower Buds","Legumes","Bulbs","Tubers"};
			//ListAdapter = new ArrayAdapter<String> (this, Android.Resource.Layout.SimpleListItemMultipleChoice, items);
			//listView.Adapter = new ArrayAdapter<String> (this, Android.Resource.Layout.SimpleListItemMultipleChoice, items);

			//c = db.RawQuery ("select * from checkLists", null); // where checkListName = 'Widgeon'", null);

			StartManagingCursor (c);

			//c.MoveToFirst ();
			//Android.Widget.Toast.MakeText (this, tv1.Text.ToString(), Android.Widget.ToastLength.Long).Show (); //  (this, t + " " + position, Android.Widget.ToastLength.Short).Show ();

			string[] fromColumns = new string[]{ "name" }; //{ "checkListID, checkListType, checkListName, checkListDesc" };
			int[] toControlIDs = new int[] { Android.Resource.Id.Text1 };
			try{
			listView.Adapter = new SimpleCursorAdapter(this, Android.Resource.Layout.SimpleListItem1, c, fromColumns, toControlIDs, 0);
			}
			catch(SQLiteException e){
				Console.WriteLine ("whoops, " + e.Message.ToString ());
			}

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
		/*
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
		*/
		protected void OnListItemClick(object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
		{
			var obj = listView.Adapter.GetItem(e.Position);
			var curs = (ICursor)obj;
			var text = curs.GetString(1); // 'name' is column 1
			Android.Widget.Toast.MakeText(this, text, Android.Widget.ToastLength.Short).Show();
			System.Console.WriteLine("Clicked on " + text);
		}

		protected override void OnDestroy()
		{
			StopManagingCursor(c);
			c.Close ();

			base.OnDestroy();
		}





	}
}



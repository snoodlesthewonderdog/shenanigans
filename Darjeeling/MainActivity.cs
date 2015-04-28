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
		string[] items;
		ListView listView;
		Darjeeling.PreFloatDatabase pdb;
		ICursor c;
		ICursor a;
		ContentValues cv;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			//SetContentView (Resource.Layout.Main);
			SetContentView (Resource.Layout.Main);
			listView = FindViewById<ListView> (Resource.Id.listView1);
			pdb = new PreFloatDatabase (this);

			cv = new ContentValues ();

			cv.Put ("checkListType", 0);
			cv.Put ("checkListName", "Bertram");
			cv.Put ("checkListDesc", "Big Luxury");

			pdb.ReadableDatabase.Insert ("checkLists", null, cv);

			c = pdb.ReadableDatabase.RawQuery ("select * from checkLists", null);
			StartManagingCursor (c);
			listView.Adapter = (IListAdapter)new HomeScreenCursorAdapter (this,c);

			//items = new string[]{ "Fruits", "Vegetables","Flower Buds","Legumes","Bulbs","Tubers"};
			//ListAdapter = new ArrayAdapter<String> (this, Android.Resource.Layout.SimpleListItemMultipleChoice, items);
			//listView.Adapter = new ArrayAdapter<String> (this, Android.Resource.Layout.SimpleListItemMultipleChoice, items);

			/*string[] fromColumns = new string[]{ "checkListName" }; //{ "checkListID, checkListType, checkListName, checkListDesc" };
			int[] toControlIDs = new int[] {Android.Resource.Id.Text1};
			//SimpleCursorAdapter myAdapter = new SimpleCursorAdapter (this, Android.Resource.Layout.SimpleListItem1, c, fromColumns, toControlIDs);
			try{
				listView.Adapter = new SimpleCursorAdapter(this,Android.Resource.Layout.SimpleListItem1 , c, fromColumns, toControlIDs, 0);			
			}
			catch(SQLiteException e){
				Console.WriteLine ("whoops, " + e.Message.ToString ());
			}*/
		}
		//  End onCreate method

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

		public class HomeScreenCursorAdapter : CursorAdapter {
			Activity context;
			public HomeScreenCursorAdapter(Activity context, ICursor c)
				: base (context, c)
			{
				this.context = context;
			}

			public override void BindView(View view, Context context, ICursor cursor)
			{
				var txtCheckListName = view.FindViewById<TextView> (Resource.Id.txtCheckListName); //(Android.Resource.Id.Text1);
				var txtCheckListDesc = view.FindViewById<TextView> (Resource.Id.txtCheckListDesc); //(Android.Resource.Id.Text2); 
				txtCheckListName.Text = cursor.GetString (3);
				txtCheckListDesc.Text = cursor.GetString (4);
			}

			public override View NewView(Context context, ICursor cursor, ViewGroup parent)
			{
				return this.context.LayoutInflater.Inflate (Resource.Layout.myList, parent, false);
			}
		}
	}
}


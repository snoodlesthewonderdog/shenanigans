
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.Database.Sqlite;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Darjeeling
{	
	[Activity (Label = "PreFloat - Start Checking")]			
	public class Checklists : Activity
	{
		Darjeeling.PreFloatDatabase pdb;
		ICursor c;
		ListView lv;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView(Resource.Layout.Checklists);
			ListView lv = FindViewById<ListView> (Resource.Id.lvChecklists);
			pdb = new PreFloatDatabase (this);

			c = pdb.ReadableDatabase.RawQuery ("select * from checkLists", null);
			StartManagingCursor (c);
			lv.Adapter = (IListAdapter)new CheckList (this, c);
			lv.ItemClick += itemClicked; 

				//+= delegate(object sender, AdapterView.ItemClickEventArgs e) {
				//var listview = sender as ListView;
				//var t = c.MoveToPosition (e.Position);
				//Android.Widget.Toast.MakeText(this, "Hello World", Android.Widget.ToastLength.Short).Show();
			//}; 				
		}

		protected void itemClicked(object sender, AdapterView.ItemClickEventArgs e){
			var listview = sender as ListView;
			var t = c.MoveToPosition (e.Position);
			Android.Widget.Toast.MakeText(this, "Hello World", Android.Widget.ToastLength.Short).Show();
		}

		protected override void OnDestroy()
		{
			StopManagingCursor(c);
			c.Close ();
			base.OnDestroy();
		}
	}

		public class CheckList : CursorAdapter 
		{
			Activity context;
			public CheckList(Activity context, ICursor c)
				: base (context, c)
			{
				this.context = context;
			}

			public override void BindView(View view, Context context, ICursor cursor)
			{
				var btnCheckListName = view.FindViewById<Button> (Resource.Id.btnChecklist);	
				btnCheckListName.Text = Cursor.GetString (3);
				

				//btnCheckListName.Click += delegate(object sender, EventArgs e) {
					//onClickDisplayList(context);
					//Intent intent = new Intent (context, typeof(SelectedList));
				//};

				//txtCheckListName.Text = cursor.GetString (3);
				//txtCheckListDesc.Text = cursor.GetString (4);
			}

			public override View NewView(Context context, ICursor cursor, ViewGroup parent)
			{
				return this.context.LayoutInflater.Inflate (Resource.Layout.Checklists, parent, false);
			}

			public static void onClickDisplayList(Context context){
				Intent intent = new Intent (context, typeof(SelectedList));
				//StartActivity (intent);
			}
		}	
}


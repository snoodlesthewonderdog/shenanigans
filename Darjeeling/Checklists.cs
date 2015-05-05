﻿
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
			pdb = new PreFloatDatabase (this);

			c = pdb.ReadableDatabase.RawQuery ("select * from checkLists", null);
			StartManagingCursor (c);


			int x;
			for (x = 0; x < 10; x++) {
				Console.WriteLine ("Hello World");
			}

		}
	}

	public class CheckLists : CursorAdapter {
		Activity context;
		public CheckLists(Activity context, ICursor c)
			: base (context, c)
		{
			this.context = context;
		}

		public override void BindView(View view, Context context, ICursor cursor)
		{
			var btnCheckListName = view.FindViewById<Button> (Resource.Id.btnChecklist);	
			btnCheckListName.Text = Cursor.GetString (3);

			//txtCheckListName.Text = cursor.GetString (3);
			//txtCheckListDesc.Text = cursor.GetString (4);
		}

		public override View NewView(Context context, ICursor cursor, ViewGroup parent)
		{
			return this.context.LayoutInflater.Inflate (Resource.Layout.Checklists, parent, false);
		}
	}
}


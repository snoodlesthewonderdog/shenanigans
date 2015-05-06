using System;
using Android.Database.Sqlite;
using Android.Content;

namespace Darjeeling {
	class PreFloatDatabase : SQLiteOpenHelper {
		public static readonly string create_checkLists_table = "create table if not exists checkLists([_id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE, checkListID INTEGER, checkListType INTEGER, checkListName TEXT, checkListDesc TEXT);";
		public static readonly string create_checkList_table = "create table is not exists checkList([_id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE, checkListID INTEGER, checkListItem TEXT);";
		public static readonly string DatabaseName = "prefloat.db";
		public static readonly int DatabaseVersion = 1;
		public PreFloatDatabase (Context context) : base (context, DatabaseName, null, DatabaseVersion){		}

		public override void OnCreate(SQLiteDatabase db){
			//  fire the statement that creates the checkLists table
			try{
			db.ExecSQL (create_checkLists_table);			
			//  Now pre-fill the checkLists table
				db.ExecSQL ("insert into checkLists (checkListID, checkListType, checkListName, checkListDesc) values (0, 0, 'Widgeon','Widgeon Daysailer');");
				db.ExecSQL ("insert into checkLists (checkListID, checkListType, checkListName, checkListDesc) values (1, 1, 'Widgeon','Widgeon Daysailer');");
				db.ExecSQL ("insert into checkLists (checkListID, checkListType, checkListName, checkListDesc) values (2, 0, 'Bowrider', 'Mo Motor, Mo Fun');");
				db.ExecSQL ("insert into checkLists (checkListID, checkListType, checkListName, checkListDesc) values (3, 1, 'Bowrider', 'Mo Motor, Mo Fun');");
				db.ExecSQL ("insert into checkLists (checkListID, checkListType, checkListName, checkListDesc) values (4, 0, 'HobieCat','Hang yer ass out fun');");
				db.ExecSQL ("insert into checkLists (checkListID, checkListType, checkListName, checkListDesc) values (5, 1, 'HobieCat','Hang yer ass out fun');");
			}
			catch(SQLiteException e){
				Console.WriteLine ("Problem with the database " + e.Message.ToString ());
			}

			//  make another table called checkList 
			try{
				db.ExecSQL(create_checkList_table);
				// Now pre-fill the checkList table
				//db.ExecSQL("insert into checkList (
			}
			catch(SQLiteException e){
				Console.Write ("Problem with the database " + e.Message.ToString ());
			}

		}// End for OnCreate

	

		public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion){
			throw new NotImplementedException ();
		}

	} // matches with class PreFloatDatabase
} // matches with namespace Darjeeling


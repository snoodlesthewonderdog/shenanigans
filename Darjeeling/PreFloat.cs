using System;
using Android.Database.Sqlite;
using Android.Content;

namespace Darjeeling {
	class PreFloatDatabase : SQLiteOpenHelper {
		public static readonly string create_checkLists_table = "create table if not exists checkLists([_id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE, checkListID INTEGER, checkListType INTEGER, checkListName TEXT, checkListDesc TEXT);";
		public static readonly string create_checkList_table = "create table if not exists checkList([_id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE, checkListID INTEGER, checkListItem TEXT);";
		public static readonly string create_checkListTypes_table = "create table if not exists checkListTypes([_id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE, checkListTypeID INTEGER, checkListType);";
		public static readonly string DatabaseName = "prefloat.db";
		public static readonly int DatabaseVersion = 1;
		public PreFloatDatabase (Context context) : base (context, DatabaseName, null, DatabaseVersion){		}

		public override void OnCreate(SQLiteDatabase db){

			//  Create and pre-fill checListTypes table
			try{
				db.ExecSQL(create_checkListTypes_table);
				db.ExecSQL("insert into checkListTypes (checkListTypeID, checkListType) values (0, 'Driveway Checklist');");
				db.ExecSQL("insert into checkListTypes (checkListTypeID, checkListType) values (0, 'Dock Checklist');");
			}
			catch (SQLiteException e){
				Console.Write (e.Message.ToString ());
			}
			//  fire the statement that creates the checkLists table
			try{
			db.ExecSQL (create_checkLists_table);			
			//  Now pre-fill the checkLists table
				db.ExecSQL ("insert into checkLists (checkListID, checkListType, checkListName, checkListDesc) values (0, 0, 'Widgeon - Pre-Departure','Widgeon Daysailer');");
				db.ExecSQL ("insert into checkLists (checkListID, checkListType, checkListName, checkListDesc) values (1, 1, 'Widgeon - Pre-Float','Widgeon Daysailer');");
				db.ExecSQL ("insert into checkLists (checkListID, checkListType, checkListName, checkListDesc) values (2, 0, 'Bowrider - Pre-Departure', 'Mo Motor, Mo Fun');");
				db.ExecSQL ("insert into checkLists (checkListID, checkListType, checkListName, checkListDesc) values (3, 1, 'Bowrider - Pre-Float', 'Mo Motor, Mo Fun');");
				db.ExecSQL ("insert into checkLists (checkListID, checkListType, checkListName, checkListDesc) values (4, 0, 'HobieCat - Pre-Departure','Hang yer ass out fun');");
				db.ExecSQL ("insert into checkLists (checkListID, checkListType, checkListName, checkListDesc) values (5, 1, 'HobieCat - Pre-Float','Hang yer ass out fun');");
			}
			catch(SQLiteException e){
				Console.WriteLine ("Problem with the database " + e.Message.ToString ());
			}

			//  make another table called checkList 
			try{
				db.ExecSQL(create_checkList_table);
				// Now pre-fill the checkList table
				db.ExecSQL("insert into checkList (checkListID, checkListItem) values (0, 'PFD/'s');");
				db.ExecSQL("insert into checkList (checkListID, checkListItem) values (0, 'Mast');");
				db.ExecSQL("insert into checkList (checkListID, checkListItem) values (0, 'Boom');");
				db.ExecSQL("insert into checkList (checkListID, checkListItem) values (0, 'Rudder');");
				db.ExecSQL("insert into checkList (checkListID, checkListItem) values (0, 'Distress Flag');");
				db.ExecSQL("insert into checkList (checkListID, checkListItem) values (0, 'Air Horn');");
				db.ExecSQL("insert into checkList (checkListID, checkListItem) values (0, 'Fenders');");
				db.ExecSQL("insert into checkList (checkListID, checkListItem) values (0, 'Padlock Keys');");
				db.ExecSQL("insert into checkList (checkListID, checkListItem) values (0, 'Sails (main/jib/etc)');");
				db.ExecSQL("insert into checkList (checkListID, checkListItem) values (0, 'Anchor');");
				db.ExecSQL("insert into checkList (checkListID, checkListItem) values (0, 'Tool Box');");
				db.ExecSQL("insert into checkList (checkListID, checkListItem) values (0, 'Dock Line');");
				db.ExecSQL("insert into checkList (checkListID, checkListItem) values (0, 'Fire Extinquisher');");
				db.ExecSQL("insert into checkList (checkListID, checkListItem) values (0, 'VHF Radio');");
				db.ExecSQL("insert into checkList (checkListID, checkListItem) values (0, 'Water');");
				db.ExecSQL("insert into checkList (checkListID, checkListItem) values (0, 'Sunscreen');");
				db.ExecSQL("insert into checkList (checkListID, checkListItem) values (0, 'Waterproof Bag');");
				db.ExecSQL("insert into checkList (checkListID, checkListItem) values (0, 'Motor');");
				db.ExecSQL("insert into checkList (checkListID, checkListItem) values (0, 'Gas Can');");
				db.ExecSQL("insert into checkList (checkListID, checkListItem) values (0, 'Paddle');");
				db.ExecSQL("insert into checkList (checkListID, checkListItem) values (0, 'Bailer');");
				db.ExecSQL("insert into checkList (checkListID, checkListItem) values (0, 'Pocketknife / multi-tool');");
				db.ExecSQL("insert into checkList (checkListID, checkListItem) values (0, 'Boat Registration');");
				db.ExecSQL("insert into checkList (checkListID, checkListItem) values (0, 'Trailer Registration');");
				db.ExecSQL("insert into checkList (checkListID, checkListItem) values (0, 'Boating License');");
				db.ExecSQL("insert into checkList (checkListID, checkListItem) values (0, 'Sunglasses / Hat');");
				db.ExecSQL("insert into checkList (checkListID, checkListItem) values (0, 'Duct Tape');");
				db.ExecSQL("insert into checkList (checkListID, checkListItem) values (0, 'Change of Clothes');");
				db.ExecSQL("insert into checkList (checkListID, checkListItem) values (0, 'Charts/Maps');");
				db.ExecSQL("insert into checkList (checkListID, checkListItem) values (0, 'Float Plan');");

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


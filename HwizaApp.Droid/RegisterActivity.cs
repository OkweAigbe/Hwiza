using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Support.V7.App;
using Android.Widget;

using Android.Support.Design.Widget;
using Android.Gms.Tasks;
using Java.Lang;

using HwizaApp.Droid;
using HwizaApp.Droid.Helper;
using Android.Database.Sqlite;
using Android.Database;
using System.IO;
using SQLite;

namespace SQLiteDB
{
	[Activity(Label = "RegisterActivity")]
	public class RegisterActivity : Activity 

	{
		EditText emailEditText, passwordEditText, confirmPasswordEditText;
		Button registerButton;
		TextView fromRegisterLogin;
		CoordinatorLayout rootView;
		

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here
			SetContentView(Resource.Layout.Register);
						
			ConnectControl();	
			

		}

		

		void ConnectControl()
		{
			emailEditText = FindViewById<EditText>(Resource.Id.registerEmailEditText);
			passwordEditText = FindViewById<EditText>(Resource.Id.registerPasswordEditText);
			confirmPasswordEditText = FindViewById<EditText>(Resource.Id.confirmPasswordEditText);
			fromRegisterLogin = FindViewById<TextView>(Resource.Id.fromRegisterLogin);
			rootView = (CoordinatorLayout)FindViewById(Resource.Id.rootView);
			registerButton = FindViewById<Button>(Resource.Id.registerUserButton);

			registerButton.Click += delegate
			{
				//path string for the databas file
				string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Hwiza.db");

				//setup the db connection
				var db = new SQLiteConnection(dbPath);

				//setup a table
				db.CreateTable<User>();

				//store the object into table

				User tbl = new User();
				tbl.Email = emailEditText.Text;
				tbl.Password = passwordEditText.Text;
				db.Insert(tbl);
				db.Close();
				clear();
				Toast.MakeText(this, "Data Store Successfully...,", ToastLength.Short).Show();

				
			};

			fromRegisterLogin.Click += FromRegisterLogin_Click;

			string email = Intent.GetStringExtra("email");
			emailEditText.Text = email;

		}

		private void clear()
		{
			emailEditText.Text = " ";
			passwordEditText.Text = "";
			confirmPasswordEditText.Text = "";
		}

		

		private void FromRegisterLogin_Click(object sender, EventArgs e)
		{
			StartActivity(typeof(MainActivity));
		}

	}
}
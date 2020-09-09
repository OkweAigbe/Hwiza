using System;
using Android.App;
using Android.Content;
using Android.Views;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.IO;
using SQLite;
using HwizaApp.Droid.Helper;

namespace HwizaApp.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]

    public class MainActivity : AppCompatActivity
    {
		
		EditText emailEditText, passwordEditText;
		Button signinButton, registerButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

			emailEditText = FindViewById<EditText>(Resource.Id.EmailEditText);
			passwordEditText = FindViewById<EditText>(Resource.Id.PasswordEditText);
			signinButton = FindViewById<Button>(Resource.Id.signinButton);
			registerButton = FindViewById<Button>(Resource.Id.registerButton);

			signinButton.Click += SigninButton_Click;
			registerButton.Click += RegisterButton_Click;

			
        }

		private void RegisterButton_Click(object sender, System.EventArgs e)
		{
			var intent = new Intent(this, typeof(SQLiteDB.RegisterActivity));
			intent.PutExtra("email", emailEditText.Text);
			StartActivity(intent);
		}

		private void SigninButton_Click(object sender, System.EventArgs e)
		{
			try
			{
				//path string for the databas file
				string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Hwiza.db");  

				//setup the db connection
				var db = new SQLiteConnection(dbPath);

				//Call Table 
				var data = db.Table<User>();

				//Linq Query
				var login = data.Where(x => x.Email == emailEditText.Text && x.Password == passwordEditText.Text).FirstOrDefault();   

				if (login != null)
				{
					Toast.MakeText(this, "Login Success", ToastLength.Short).Show();
					StartActivity(typeof(Home));
					Finish();
				}
				else
				{
					Toast.MakeText(this, "Username or Password invalid", ToastLength.Short).Show();
				}
				//}
			}
			catch (Exception ex)
			{
				Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
			}

			
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase;
using Firebase.Auth;
using Firebase.Database;

namespace HwizaApp.Droid
{
	[Activity(Label = "RegisterActivity")]
	public class RegisterActivity : Activity

	{
		EditText emailEditText, passwordEditText, confirmPasswordEditText;
		Button registerButton;

		FirebaseAuth mAuth;
		FirebaseDatabase database;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here
			SetContentView(Resource.Layout.Register);

			emailEditText = FindViewById<EditText>(Resource.Id.registerEmailEditText);
			passwordEditText = FindViewById<EditText>(Resource.Id.registerPasswordEditText);
			confirmPasswordEditText = FindViewById<EditText>(Resource.Id.confirmPasswordEditText);
			registerButton = FindViewById<Button>(Resource.Id.registerUserButton);

			registerButton.Click += RegisterButton_Click;

			string email = Intent.GetStringExtra("email");
			emailEditText.Text = email;

			InitializeFirebase();
			mAuth = FirebaseAuth.Instance;
		}

		void InitializeFirebase()
		{
			var app = FirebaseApp.InitializeApp(this);

			if (app == null)
			{
				var options = new FirebaseOptions.Builder()

					.SetApplicationId("hwiza-6419a")
					.SetApiKey("AIzaSyAK8awtUG2Cy5kIq3w4Y5gNNS8oHvhJZ1k")
					.SetDatabaseUrl("https://hwiza-6419a.firebaseio.com")
					.SetStorageBucket("hwiza-6419a.appspot.com")
					.Build();

				app = FirebaseApp.InitializeApp(this, options);
				database = FirebaseDatabase.GetInstance(app);
			}
			else
			{
				database = FirebaseDatabase.GetInstance(app);
			}


		}

		private void RegisterButton_Click(object sender, EventArgs e)
		{
			mAuth.CreateUserWithEmailAndPassword(emailEditText.Text, passwordEditText.Text);
		}

		
	}
}
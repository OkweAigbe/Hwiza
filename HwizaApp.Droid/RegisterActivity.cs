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
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Android.Support.Design.Widget;
using Android.Gms.Tasks;
using Java.Lang;
using HwizaApp.Droid.EventListener;

namespace HwizaApp.Droid
{
	[Activity(Label = "RegisterActivity")]
	public class RegisterActivity : Activity 

	{
		EditText emailEditText, passwordEditText, confirmPasswordEditText;
		Button registerButton;
		CoordinatorLayout rootView;

		FirebaseAuth mAuth;
		FirebaseDatabase database;

		TaskCompletionListener TaskCompletionListener = new TaskCompletionListener();

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here
			SetContentView(Resource.Layout.Register);

			InitializeFirebase();
			mAuth = FirebaseAuth.Instance;
			ConnectControl();
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

		void ConnectControl()
		{
			emailEditText = FindViewById<EditText>(Resource.Id.registerEmailEditText);
			passwordEditText = FindViewById<EditText>(Resource.Id.registerPasswordEditText);
			confirmPasswordEditText = FindViewById<EditText>(Resource.Id.confirmPasswordEditText);
			rootView = (CoordinatorLayout)FindViewById(Resource.Id.rootView);
			registerButton = FindViewById<Button>(Resource.Id.registerUserButton);

			registerButton.Click += RegisterButton_Click;

			string email = Intent.GetStringExtra("email");
			emailEditText.Text = email;

		}


		private void RegisterButton_Click(object sender, EventArgs e)
		{
			string email, password;

			email = emailEditText.Text;
			password = passwordEditText.Text;

			if (!email.Contains("@"))
			{
				Snackbar.Make(rootView, "Please enter a valid email", Snackbar.LengthShort).Show();
				return;
			}
			else if (password.Length < 5)
			{
				Snackbar.Make(rootView, "Password should be up to 5 characters", Snackbar.LengthShort).Show();
				return;
			}

			RegisterUser(email, password);
		}

		void RegisterUser(string email, string password)
		{
			TaskCompletionListener.Success += TaskCompletionListener_Success;
			TaskCompletionListener.Failure += TaskCompletionListener_Failure;
			mAuth.CreateUserWithEmailAndPassword(email, password)
				.AddOnSuccessListener(this, TaskCompletionListener)
				.AddOnFailureListener(this, TaskCompletionListener);

		}

		private void TaskCompletionListener_Success(object sender, EventArgs e)
		{
			Snackbar.Make(rootView, "User Registration was Successful", Snackbar.LengthShort).Show();
		}

		private void TaskCompletionListener_Failure(object sender, EventArgs e)
		{
			Snackbar.Make(rootView, "User Registration Failed", Snackbar.LengthShort).Show();
		}





	}
}
using System;
using Android.App;
using Android.Content;
using Android.Views;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

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
			var intent = new Intent(this, typeof(RegisterActivity));
			intent.PutExtra("email", emailEditText.Text);
			StartActivity(intent);
		}

		private void SigninButton_Click(object sender, System.EventArgs e)
		{
			
		}
	}
}
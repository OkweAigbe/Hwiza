using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Support.V7.App;
//using Android.Support.V7.AppCompat;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;


namespace HwizaApp.Droid
{
	[Activity(Label = "Home", Theme = "@style/AppTheme")]
	public class Home : AppCompatActivity
	{
		
		LinearLayout monitorLayout;
		LinearLayout respondLayout;
		LinearLayout analysisLayout;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here
			SetContentView(Resource.Layout.Home);

			monitorLayout = (LinearLayout)FindViewById(Resource.Id.monitorLayout);
			respondLayout = (LinearLayout)FindViewById(Resource.Id.respondLayout);
			analysisLayout = (LinearLayout)FindViewById(Resource.Id.analysisLayout);
			

			monitorLayout.Click += MonitorLayout_Click;
			respondLayout.Click += RespondLayout_Click;
			analysisLayout.Click += AnalysisLayout_Click;

			//SetSupportActionBar(homeToolbar);
			//SupportActionBar.Title = "Home";
			//Android.Support.V7.App.ActionBar actionBar = SupportActionBar;
			//actionBar.SetDisplayHomeAsUpEnabled(true);
		}

		private void AnalysisLayout_Click(object sender, EventArgs e)
		{
			StartActivity(typeof(Analysis));
		}

		private void RespondLayout_Click(object sender, EventArgs e)
		{
			StartActivity(typeof(Map));
		}

		private void MonitorLayout_Click(object sender, EventArgs e)
		{
			StartActivity(typeof(ListOfInsects));
		}
	}
}
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

namespace HwizaApp.Droid
{
	[Activity(Label = "Home")]
	public class Home : Activity
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
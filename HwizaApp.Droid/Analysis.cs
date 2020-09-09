using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace HwizaApp.Droid
{
	[Activity(Label = "Analysis", Theme = "@style/AppTheme")]
	public class Analysis : AppCompatActivity
	{
		Android.Support.V7.Widget.Toolbar analysisToolbar;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here
			SetContentView(Resource.Layout.Analysis);

			analysisToolbar = (Android.Support.V7.Widget.Toolbar)FindViewById(Resource.Id.analysisToolbar);

			//SetSupportActionBar(analysisToolbar);
			//SupportActionBar.Title = "Analysis";
			//Android.Support.V7.App.ActionBar actionBar = SupportActionBar;
			//actionBar.SetDisplayHomeAsUpEnabled(true);

		}
	}
}
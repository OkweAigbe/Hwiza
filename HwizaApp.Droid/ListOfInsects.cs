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
	[Activity(Label = "ListOfInsects", Theme = "@style/AppTheme")]
	public class ListOfInsects : AppCompatActivity
	{
		Android.Support.V7.Widget.Toolbar listToolbar;
		LinearLayout waspLayout;
		LinearLayout antsLayout;
		LinearLayout weaverLayout;
		LinearLayout armyLayout;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here

			SetContentView(Resource.Layout.ListOfInsects);

			waspLayout = (LinearLayout)FindViewById(Resource.Id.waspLayout);
			antsLayout = (LinearLayout)FindViewById(Resource.Id.antsLayout);
			weaverLayout = (LinearLayout)FindViewById(Resource.Id.weaverLayout);
			armyLayout = (LinearLayout)FindViewById(Resource.Id.armyLayout);
			listToolbar = (Android.Support.V7.Widget.Toolbar)FindViewById(Resource.Id.listToolbar);

			waspLayout.Click += WaspLayout_Click;
			antsLayout.Click += AntsLayout_Click;
			weaverLayout.Click += WeaverLayout_Click;
			armyLayout.Click += ArmyLayout_Click;

			//SetSupportActionBar(listToolbar);
			//SupportActionBar.Title = "List Of Insects";
			//Android.Support.V7.App.ActionBar actionBar = SupportActionBar;
			//actionBar.SetDisplayHomeAsUpEnabled(true);
		}

		private void ArmyLayout_Click(object sender, EventArgs e)
		{
			
		}

		private void WeaverLayout_Click(object sender, EventArgs e)
		{
			
		}

		private void AntsLayout_Click(object sender, EventArgs e)
		{
			
		}

		private void WaspLayout_Click(object sender, EventArgs e)
		{
			StartActivity(typeof(WaspPostActivity));
		}
	}
}
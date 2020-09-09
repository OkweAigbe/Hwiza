using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Xamarin.Essentials;



namespace HwizaApp.Droid
{
	[Activity(Label = "Map", Theme = "@style/AppTheme")]

	public class Map : AppCompatActivity, IOnMapReadyCallback
	{
		private GoogleMap myMap;

		readonly string[] permissionGroup =
		{
			Manifest.Permission.ReadExternalStorage,
			Manifest.Permission.WriteExternalStorage,
			Manifest.Permission.AccessNetworkState,
			Manifest.Permission.AccessFineLocation,
			Manifest.Permission.AccessCoarseLocation


		};

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			//Xamarin.Essentials.Platform.Init(this, savedInstanceState);

			// Create your application here
			//super.onCreate(savedInstanceState);
			SetContentView(Resource.Layout.Map);

			RequestPermissions(permissionGroup, 0);

			SetUpMap();

			//var mapFragment = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.map);
			//mapFragment.GetMapAsync(this);

			//SupportMapFragment mapFragment = (SupportMapFragment)SupportFragmentManager.FindFragmentById(Resource.Id.map);
			//mapFragment.GetMapAsync(this);

			//SupportMapFragment _mapFragment = (SupportMapFragment)SupportFragmentManager.FindFragmentByTag("map");
			//if (_mapFragment == null)
			//{
			//	GoogleMapOptions mapOptions = new GoogleMapOptions()
			//		.InvokeRotateGesturesEnabled(true)
			//		.InvokeScrollGesturesEnabled(true)
			//		.InvokeCompassEnabled(true)
			//		.InvokeAmbientEnabled(true)
			//		.InvokeMapType(GoogleMap.MapTypeNormal)
			//		.InvokeZoomControlsEnabled(true)
			//		.InvokeCompassEnabled(true);

			//	_mapFragment = SupportMapFragment.NewInstance(mapOptions);

			//	Android.Support.V4.App.FragmentTransaction fragTx = SupportFragmentManager.BeginTransaction();
			//	fragTx.Add(Resource.Id.map, _mapFragment, "map");
			//	fragTx.Commit();

			//	_mapFragment.GetMapAsync(this); }

			}


			private void SetUpMap()
			{
				if (myMap == null)
				{
					SupportMapFragment mapFragment = (SupportMapFragment)SupportFragmentManager.FindFragmentById(Resource.Id.map);
					mapFragment.GetMapAsync(this);
				}
			}

			public override void OnRequestPermissionsResult(int requestCode, string[] permissions,
				[GeneratedEnum] Android.Content.PM.Permission[] grantResults)
		{
			Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
			base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		}

		public void OnMapReady(GoogleMap googleMap)
		{
			myMap = googleMap;
		}
	}
}
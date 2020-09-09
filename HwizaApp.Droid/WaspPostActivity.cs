using System;
using Android;
using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Widget;
using HwizaApp.Droid.Helper;
using Android.Graphics;
using Plugin.Media;
using Android.Gms.Location;
using Android.Support.V4.App;


namespace HwizaApp.Droid
{
	[Activity(Label = "WaspPostActivity")]
	public class WaspPostActivity : AppCompatActivity, IOnMapReadyCallback
	{
		
		ImageView postImage;
		Button waspSubmitBtn;
		SupportMapFragment mapFragment;
		double latitude, longitude;
		LocationManager locationManager;
		GoogleMap myMap;

		

		TaskCompletionListeners taskCompletionListeners = new TaskCompletionListeners();
		TaskCompletionListeners downloadUrlListener = new TaskCompletionListeners();

		readonly string[] permissionGroup =
		{
			Manifest.Permission.ReadExternalStorage,
			Manifest.Permission.WriteExternalStorage,
			Manifest.Permission.Camera,
			Manifest.Permission.AccessFineLocation,
			Manifest.Permission.AccessCoarseLocation


		};
		const int requestLocationId = 0;

		LocationRequest mLocationRequest;
		FusedLocationProviderClient locationClient;
		Android.Locations.Location mLastLocation;
		LocationCallbackHelper mLocationCallback;

		static int UPDATE_INTERVAL = 5; //5 SECONDS
		static int FASTEST_INTERVAL = 5;
		static int DISPLACEMENT = 3; //meters

		public void OnLocationChanged(Location location)
		{
			latitude = location.Latitude;
			longitude = location.Longitude;
			
		}

		public void OnMapReady(GoogleMap googleMap)
		{
			
			myMap = googleMap;
			MarkerOptions marker = new MarkerOptions();
			marker.SetPosition(new LatLng(latitude, longitude));
			marker.SetTitle("Your Location");

			googleMap.AddMarker(marker);

			googleMap.UiSettings.ZoomControlsEnabled = true;
			googleMap.UiSettings.CompassEnabled = true;

			googleMap.MoveCamera(CameraUpdateFactory.NewLatLngZoom(new LatLng(latitude, longitude), 10));
			
		}

		public void OnProviderDisabled(string provider)
		{

		}

		public void OnProviderEnabled(string provider)
		{

		}

		public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
		{

		}

		byte[] fileBytes;
		ProgressDialogueFragment progressDialogue;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here
			
			SetContentView(Resource.Layout.WaspPost);

			RequestPermissions(permissionGroup, 0);

			waspSubmitBtn = (Button)FindViewById(Resource.Id.waspSubmitButton);


			SupportMapFragment mapFragment = (SupportMapFragment)SupportFragmentManager.FindFragmentById(Resource.Id.mapFragment);
			mapFragment.GetMapAsync(this);

			CreateLocationRequest();
			GetMyLocation();
			StartLocationUpdates();

			postImage = (ImageView)FindViewById(Resource.Id.newWaspPostImage);
			postImage.Click += PostImage_Click;
		}

		

		bool CheckLocationPermission()
		{
			bool permissionGranted = false;

			if (ActivityCompat.CheckSelfPermission(this, Manifest.Permission.AccessFineLocation) != Android.Content.PM.Permission.Granted &&
				ActivityCompat.CheckSelfPermission(this, Manifest.Permission.AccessCoarseLocation) != Android.Content.PM.Permission.Granted)
			{
				permissionGranted = false;
				RequestPermissions(permissionGroup, requestLocationId);
			}
			else
			{
				permissionGranted = true;
			}

			return permissionGranted;
		}

		void CreateLocationRequest()
		{
			mLocationRequest = new LocationRequest();
			mLocationRequest.SetInterval(UPDATE_INTERVAL);
			mLocationRequest.SetFastestInterval(FASTEST_INTERVAL);
			mLocationRequest.SetPriority(LocationRequest.PriorityHighAccuracy);
			mLocationRequest.SetSmallestDisplacement(DISPLACEMENT);
			locationClient = LocationServices.GetFusedLocationProviderClient(this);
			mLocationCallback = new LocationCallbackHelper();
			mLocationCallback.MyLocation += MLocationCallback_MyLocation;

		}

		void MLocationCallback_MyLocation(object sender, LocationCallbackHelper.OnLocationCapturedEventArgs e)
		{
			mLastLocation = e.Location;
			LatLng myposition = new LatLng(mLastLocation.Latitude, mLastLocation.Longitude);
			myMap.AnimateCamera(CameraUpdateFactory.NewLatLngZoom(myposition, 12));
		}

		void StartLocationUpdates()
		{
			if (CheckLocationPermission())
			{
				locationClient.RequestLocationUpdates(mLocationRequest, mLocationCallback, null);
			}
		}

		void StopLocationUpdates()
		{
			if (locationClient != null && mLocationCallback != null)
			{
				locationClient.RemoveLocationUpdates(mLocationCallback);
			}
		}

		async void GetMyLocation()
		{
			if (!CheckLocationPermission())
			{
				return;
			}

			mLastLocation = await locationClient.GetLastLocationAsync();
			if (mLastLocation != null)
			{
				LatLng myposition = new LatLng(mLastLocation.Latitude, mLastLocation.Longitude);
				myMap.MoveCamera(CameraUpdateFactory.NewLatLngZoom(myposition, 17));
			}

			MarkerOptions marker = new MarkerOptions();
			marker.SetPosition(new LatLng(latitude, longitude));
			marker.SetTitle("Your Location");
		}

		private void PostImage_Click(object sender, EventArgs e)
		{
			Android.Support.V7.App.AlertDialog.Builder photoAlert = new Android.Support.V7.App.AlertDialog.Builder(this);
			//photoAlert.SetMessage("Change Photo");

			photoAlert.SetNegativeButton("Take Photo", (thisalert, args) =>
			{
				// Capture Image
				TakePhoto();
			});

			photoAlert.Show();
		}

		async void TakePhoto()
		{
			await CrossMedia.Current.Initialize();
			var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
			{
				PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
				CompressionQuality = 20,
				Directory = "Sample",
				Name = GenerateRandomString(6) + "wasp.jpg"

			});

			if(file == null)
			{
				return;
			}

			//Converts file.path to byte array and set the resulting bitmap to imageview
			byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
			fileBytes = imageArray;

			Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
			postImage.SetImageBitmap(bitmap);

		}

		void ShowProgressDialogue(string status)
		{
			progressDialogue = new ProgressDialogueFragment(status);
			var trans = SupportFragmentManager.BeginTransaction();
			progressDialogue.Cancelable = false;
			progressDialogue.Show(trans, "Progress");
		}

		void CloseProgressDialogue()
		{
			if (progressDialogue != null)
			{
				progressDialogue.Dismiss();
				progressDialogue = null;
			}
		}

		string GenerateRandomString(int lenght)
		{
			System.Random rand = new System.Random();
			char[] allowchars = "ABCDEFGHIJKLOMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
			string sResult = "";
			for (int i = 0; i <= lenght; i++)
			{
				sResult += allowchars[rand.Next(0, allowchars.Length)];
			}

			return sResult;
		}

		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
		{
		
			Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		}

		
	}
}
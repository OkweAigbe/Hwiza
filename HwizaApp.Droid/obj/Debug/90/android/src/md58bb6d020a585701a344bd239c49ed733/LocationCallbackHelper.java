package md58bb6d020a585701a344bd239c49ed733;


public class LocationCallbackHelper
	extends md57dae306e9c511046bb3e5da82eb8f47a.LocationCallback
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onLocationAvailability:(Lcom/google/android/gms/location/LocationAvailability;)V:GetOnLocationAvailability_Lcom_google_android_gms_location_LocationAvailability_Handler\n" +
			"n_onLocationResult:(Lcom/google/android/gms/location/LocationResult;)V:GetOnLocationResult_Lcom_google_android_gms_location_LocationResult_Handler\n" +
			"";
		mono.android.Runtime.register ("HwizaApp.Droid.Helper.LocationCallbackHelper, HwizaApp.Droid", LocationCallbackHelper.class, __md_methods);
	}


	public LocationCallbackHelper ()
	{
		super ();
		if (getClass () == LocationCallbackHelper.class)
			mono.android.TypeManager.Activate ("HwizaApp.Droid.Helper.LocationCallbackHelper, HwizaApp.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onLocationAvailability (com.google.android.gms.location.LocationAvailability p0)
	{
		n_onLocationAvailability (p0);
	}

	private native void n_onLocationAvailability (com.google.android.gms.location.LocationAvailability p0);


	public void onLocationResult (com.google.android.gms.location.LocationResult p0)
	{
		n_onLocationResult (p0);
	}

	private native void n_onLocationResult (com.google.android.gms.location.LocationResult p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}

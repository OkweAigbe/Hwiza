package md58bb6d020a585701a344bd239c49ed733;


public class ProgressDialogueFragment
	extends android.support.v4.app.DialogFragment
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("HwizaApp.Droid.Helper.ProgressDialogueFragment, HwizaApp.Droid", ProgressDialogueFragment.class, __md_methods);
	}


	public ProgressDialogueFragment ()
	{
		super ();
		if (getClass () == ProgressDialogueFragment.class)
			mono.android.TypeManager.Activate ("HwizaApp.Droid.Helper.ProgressDialogueFragment, HwizaApp.Droid", "", this, new java.lang.Object[] {  });
	}

	public ProgressDialogueFragment (java.lang.String p0)
	{
		super ();
		if (getClass () == ProgressDialogueFragment.class)
			mono.android.TypeManager.Activate ("HwizaApp.Droid.Helper.ProgressDialogueFragment, HwizaApp.Droid", "System.String, mscorlib", this, new java.lang.Object[] { p0 });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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

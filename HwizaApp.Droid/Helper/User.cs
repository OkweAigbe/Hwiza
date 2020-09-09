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
using SQLite;

namespace HwizaApp.Droid.Helper
{
	public class User
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }

		public override string ToString()
		{
			return Email + " " + "is registered.";
		}
	}

}
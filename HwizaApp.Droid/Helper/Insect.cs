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
	class Insect
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string Name { get; set; }
		public double OriginalLatitude { get; set; }
		public double OriginalLongitude { get; set; }
		public string Img { get; set; }
	}
}
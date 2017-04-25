using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OSFOLCrossPlatform;
using Xamarin.Forms;
using OSFOLCrossPlatform.Droid;
using System.IO;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

[assembly: Dependency(typeof(csvSave))]
namespace OSFOLCrossPlatform.Droid
{
    public class csvSave : ISaveAndLoad
    {
        public void SaveText(string filename, string text)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            System.IO.File.WriteAllText(filePath, text);
        }
    }
}
using System.IO;
using System;

namespace TaskManager.TaskTrackingApp.UI.Helper
{
    public static class HelperMethods
    {
        public static string CreateGuidWithExtension(string filename)
        {
            var ext = Path.GetExtension(filename);
            
            var filePath = Guid.NewGuid().ToString(); 

            return filePath + ext;
        }
    }
}

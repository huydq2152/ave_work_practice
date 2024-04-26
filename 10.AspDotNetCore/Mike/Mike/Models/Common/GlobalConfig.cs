using Microsoft.AspNetCore.Hosting;

namespace Mike.Models.Common
{
    public class GlobalConfig
    {
        public static string CurrentHost { get; set; }

        #region Upload

        public static string AppPhysPath { get; set; } 

        public static string UploadPath { get; set; } 

        #endregion

        #region FileUrl

        public static string DefaultImageUrl { get; set; }

        public static string ImageFolderUrl { get; set; } 

        #endregion
    }
}

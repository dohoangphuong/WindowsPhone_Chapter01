using Chapter04_Save_Open_file_Image_Uri_to_Web.Resources;

namespace Chapter04_Save_Open_file_Image_Uri_to_Web
{
    /// <summary>
    /// Provides access to string resources.
    /// </summary>
    public class LocalizedStrings
    {
        private static AppResources _localizedResources = new AppResources();

        public AppResources LocalizedResources { get { return _localizedResources; } }
    }
}
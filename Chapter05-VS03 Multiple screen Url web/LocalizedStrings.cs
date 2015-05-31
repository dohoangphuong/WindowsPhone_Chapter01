using Chapter05_VS03_Multiple_screen_Url_web.Resources;

namespace Chapter05_VS03_Multiple_screen_Url_web
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
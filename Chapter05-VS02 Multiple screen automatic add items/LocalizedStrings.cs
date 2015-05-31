using Chapter05_VS02_Multiple_screen_automatic_add_items.Resources;

namespace Chapter05_VS02_Multiple_screen_automatic_add_items
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
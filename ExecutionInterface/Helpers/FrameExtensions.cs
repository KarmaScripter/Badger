namespace System.Windows.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public static class FrameExtensions
    {
        /// <summary>
        /// Cleans the navigation.
        /// </summary>
        /// <param name="frame">The frame.</param>
        public static void CleanNavigation( this Frame frame )
        {
            while( frame.CanGoBack )
            {
                frame.RemoveBackEntry();
            }
        }
    }
}
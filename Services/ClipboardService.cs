using System.Windows;

namespace ButtonPanelManager.Services
{
    public class ClipboardService
    {
        public static void CopyToClipboard(string text)
        {
            try
            {
                Clipboard.SetText(text);
            }
            catch
            {
                // Clipboard operation might fail in some environments
            }
        }

        public static string? GetFromClipboard()
        {
            try
            {
                return Clipboard.GetText();
            }
            catch
            {
                return null;
            }
        }
    }
}
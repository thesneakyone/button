using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Generic;

namespace ButtonPanelManager.Utils
{
    public static class WindowHelper
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("user32.dll")]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr parameter);

        public static string GetForegroundWindowTitle()
        {
            IntPtr foregroundWindowPtr = GetForegroundWindow();
            if (foregroundWindowPtr == IntPtr.Zero)
                return "";

            return GetWindowTitle(foregroundWindowPtr);
        }

        public static string GetWindowTitle(IntPtr hWnd)
        {
            int size = GetWindowTextLength(hWnd);
            if (size == 0)
                return "";

            StringBuilder text = new StringBuilder(size + 1);
            GetWindowText(hWnd, text, text.Capacity);
            return text.ToString();
        }

        public static string GetProcessName(IntPtr hWnd)
        {
            GetWindowThreadProcessId(hWnd, out uint processId);
            try
            {
                var process = Process.GetProcessById((int)processId);
                return process.ProcessName;
            }
            catch
            {
                return "";
            }
        }

        public static List<(IntPtr Handle, string Title, string ProcessName)> GetAllVisibleWindows()
        {
            var windows = new List<(IntPtr, string, string)>();

            EnumWindows((hWnd, lParam) =>
            {
                if (IsWindowVisible(hWnd))
                {
                    string title = GetWindowTitle(hWnd);
                    if (!string.IsNullOrEmpty(title))
                    {
                        string processName = GetProcessName(hWnd);
                        windows.Add((hWnd, title, processName));
                    }
                }
                return true;
            }, IntPtr.Zero);

            return windows;
        }

        public static bool SetActiveWindow(IntPtr hWnd)
        {
            return SetForegroundWindow(hWnd);
        }

        public static IntPtr FindWindowByTitle(string windowTitle)
        {
            return FindWindow(null, windowTitle);
        }
    }
}
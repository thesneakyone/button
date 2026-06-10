using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ButtonPanelManager.Models
{
    public class AppConfiguration : ObservableObject
    {
        private string _theme = "Light";
        private string _viewMode = "Grid";
        private string _currentProfileId = "";
        private int _windowWidth = 1000;
        private int _windowHeight = 600;
        private bool _autoSave = true;

        public string Theme
        {
            get => _theme;
            set => SetProperty(ref _theme, value);
        }

        public string ViewMode
        {
            get => _viewMode;
            set => SetProperty(ref _viewMode, value);
        }

        public string CurrentProfileId
        {
            get => _currentProfileId;
            set => SetProperty(ref _currentProfileId, value);
        }

        public int WindowWidth
        {
            get => _windowWidth;
            set => SetProperty(ref _windowWidth, value);
        }

        public int WindowHeight
        {
            get => _windowHeight;
            set => SetProperty(ref _windowHeight, value);
        }

        public bool AutoSave
        {
            get => _autoSave;
            set => SetProperty(ref _autoSave, value);
        }

        public ObservableCollection<Profile> Profiles { get; } = new();
    }
}
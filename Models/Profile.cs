using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ButtonPanelManager.Models
{
    public class Profile : ObservableObject
    {
        private string _name = "Default Profile";
        private string _windowTitle = "";
        private string _processName = "";

        public string Id { get; } = Guid.NewGuid().ToString();
        public DateTime CreatedAt { get; } = DateTime.Now;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string WindowTitle
        {
            get => _windowTitle;
            set => SetProperty(ref _windowTitle, value);
        }

        public string ProcessName
        {
            get => _processName;
            set => SetProperty(ref _processName, value);
        }

        public ObservableCollection<ButtonItem> Buttons { get; } = new();

        public Profile Clone()
        {
            var newProfile = new Profile
            {
                Name = $"{this.Name} (kopie)",
                WindowTitle = this.WindowTitle,
                ProcessName = this.ProcessName
            };

            foreach (var button in this.Buttons)
            {
                newProfile.Buttons.Add(button.Clone());
            }

            return newProfile;
        }
    }
}
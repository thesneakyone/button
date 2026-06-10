using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ButtonPanelManager.Models
{
    public class ButtonItem : ObservableObject
    {
        private string _displayName = "Nieuwe Knop";
        private string _content = "";
        private string _icon = "";
        private string _color = "#007ACC";
        private string _shortcut = "";
        private bool _isEnabled = true;
        private string _category = "Algemeen";

        public string Id { get; } = Guid.NewGuid().ToString();
        public DateTime CreatedAt { get; } = DateTime.Now;

        public string DisplayName
        {
            get => _displayName;
            set => SetProperty(ref _displayName, value);
        }

        public string Content
        {
            get => _content;
            set => SetProperty(ref _content, value);
        }

        public string Icon
        {
            get => _icon;
            set => SetProperty(ref _icon, value);
        }

        public string Color
        {
            get => _color;
            set => SetProperty(ref _color, value);
        }

        public string Shortcut
        {
            get => _shortcut;
            set => SetProperty(ref _shortcut, value);
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        public string Category
        {
            get => _category;
            set => SetProperty(ref _category, value);
        }

        public ButtonItem Clone()
        {
            return new ButtonItem
            {
                DisplayName = this.DisplayName,
                Content = this.Content,
                Icon = this.Icon,
                Color = this.Color,
                Shortcut = this.Shortcut,
                IsEnabled = this.IsEnabled,
                Category = this.Category
            };
        }
    }
}
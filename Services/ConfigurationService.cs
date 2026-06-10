using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ButtonPanelManager.Models;

namespace ButtonPanelManager.Services
{
    public class ConfigurationService
    {
        private readonly string _appDataPath;
        private readonly string _configFilePath;
        private const string CONFIG_FILENAME = "config.json";

        public ConfigurationService()
        {
            _appDataPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "ButtonPanelManager"
            );

            _configFilePath = Path.Combine(_appDataPath, CONFIG_FILENAME);

            if (!Directory.Exists(_appDataPath))
            {
                Directory.CreateDirectory(_appDataPath);
            }
        }

        public async Task<AppConfiguration> LoadConfigurationAsync()
        {
            try
            {
                if (!File.Exists(_configFilePath))
                {
                    return CreateDefaultConfiguration();
                }

                string json = await File.ReadAllTextAsync(_configFilePath);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true
                };

                var config = JsonSerializer.Deserialize<AppConfiguration>(json, options);
                return config ?? CreateDefaultConfiguration();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading configuration: {ex.Message}");
                return CreateDefaultConfiguration();
            }
        }

        public async Task SaveConfigurationAsync(AppConfiguration config)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                };

                string json = JsonSerializer.Serialize(config, options);
                await File.WriteAllTextAsync(_configFilePath, json);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error saving configuration: {ex.Message}");
            }
        }

        public async Task ExportProfileAsync(Profile profile, string filePath)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                };

                string json = JsonSerializer.Serialize(profile, options);
                await File.WriteAllTextAsync(filePath, json);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error exporting profile: {ex.Message}");
                throw;
            }
        }

        public async Task<Profile?> ImportProfileAsync(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException($"File not found: {filePath}");
                }

                string json = await File.ReadAllTextAsync(filePath);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var profile = JsonSerializer.Deserialize<Profile>(json, options);
                return profile;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error importing profile: {ex.Message}");
                throw;
            }
        }

        private AppConfiguration CreateDefaultConfiguration()
        {
            var config = new AppConfiguration();
            var defaultProfile = CreateDefaultProfile();
            config.Profiles.Add(defaultProfile);
            config.CurrentProfileId = defaultProfile.Id;

            return config;
        }

        private Profile CreateDefaultProfile()
        {
            var profile = new Profile
            {
                Name = "Standaard Profiel"
            };

            // Add default buttons
            var defaultButtons = new[]
            {
                new ButtonItem { DisplayName = "Slayora", Content = ";;slayora", Category = "Voorbeelden", Color = "#FF6B6B" },
                new ButtonItem { DisplayName = "DZD", Content = ";;dzd", Category = "Voorbeelden", Color = "#4ECDC4" },
                new ButtonItem { DisplayName = "VB", Content = ";;vb", Category = "Voorbeelden", Color = "#45B7D1" },
                new ButtonItem { DisplayName = "GB", Content = ";;gb", Category = "Voorbeelden", Color = "#FFA07A" },
                new ButtonItem { DisplayName = "Trinity", Content = ";;trinity", Category = "Voorbeelden", Color = "#98D8C8" },
                new ButtonItem { DisplayName = "Home", Content = ";;home", Category = "Voorbeelden", Color = "#F7DC6F" },
                new ButtonItem { DisplayName = "DZ", Content = ";;dz", Category = "Voorbeelden", Color = "#BB8FCE" }
            };

            foreach (var button in defaultButtons)
            {
                profile.Buttons.Add(button);
            }

            return profile;
        }
    }
}
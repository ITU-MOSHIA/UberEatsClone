
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Maui.Media;

namespace MauiProfileApp.Views
{
    public partial class ProfilePage : ContentPage
    {
        private const string ProfileFileName = "profile.json"; // File name for storing profile data

        public ProfilePage()
        {
            InitializeComponent();
            LoadProfile();  // Load saved profile on page initialization
        }

        // Load Profile Data from JSON file if available
        private async void LoadProfile()
        {
            string filePath = Path.Combine(FileSystem.AppDataDirectory, ProfileFileName);

            if (File.Exists(filePath))
            {
                string json = await File.ReadAllTextAsync(filePath);  // Read JSON data
                var profile = JsonConvert.DeserializeObject<Profile>(json);  // Deserialize JSON to Profile object

                if (profile != null)
                {
                    // Populate the fields with saved profile data
                    NameEntry.Text = profile.Name;
                    SurnameEntry.Text = profile.Surname;
                    EmailEntry.Text = profile.Email;
                    BioEditor.Text = profile.Bio;

                    // Handle the Profile Picture
                    if (!string.IsNullOrEmpty(profile.ProfilePicture))
                    {
                        ProfileImage.Source = profile.ProfilePicture;  // Set image source from saved data
                    }
                }
            }
        }

        // Save Profile Data to JSON file when the "Save" button is clicked
        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var profile = new Profile
            {
                Name = NameEntry.Text,          // Get name from entry field
                Surname = SurnameEntry.Text,    // Get surname from entry field
                Email = EmailEntry.Text,        // Get email from entry field
                Bio = BioEditor.Text,           // Get bio from editor field
                ProfilePicture = ProfileImage.Source?.ToString()  // Get profile picture URL
            };

            string json = JsonConvert.SerializeObject(profile);  // Serialize Profile object to JSON
            string filePath = Path.Combine(FileSystem.AppDataDirectory, ProfileFileName);

            // Write the JSON string to the file
            await File.WriteAllTextAsync(filePath, json);

            await DisplayAlert("Success", "Profile saved successfully!", "OK");  // Show success message
        }

        // Open file picker to select a profile picture
        private async void OnChoosePictureClicked(object sender, EventArgs e)
        {
            try
            {
                var result = await FilePicker.PickAsync(new PickOptions
                {
                    PickerTitle = "Select a Profile Picture",
                    FileTypes = FilePickerFileType.Images  // Only allow image files
                });

                if (result != null)
                {
                    ProfileImage.Source = result.FullPath;  // Set the profile image source to the chosen image
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");  // Show error if any
            }
        }
    }

    // Profile model to hold profile information
    public class Profile
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public string ProfilePicture { get; set; }
    }
}

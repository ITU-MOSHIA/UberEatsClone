using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace UberEatsClone.Views
{
    public partial class BrowsePage : ContentPage
    {
        public List<Restaurant> Restaurants { get; set; }

        public BrowsePage()
        {
            InitializeComponent();

            Restaurants = new List<Restaurant>
            {
                new Restaurant { Name = "Restaurant A", Description = "Italian Cuisine", Image = "restaurant1.png" },
                new Restaurant { Name = "Restaurant B", Description = "Chinese Cuisine", Image = "restaurant2.png" },
                new Restaurant { Name = "Restaurant C", Description = "Mexican Cuisine", Image = "restaurant3.png" }
            };

            BindingContext = this;
        }
    }

    public class Restaurant
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}

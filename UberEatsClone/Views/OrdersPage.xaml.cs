using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace UberEatsClone.Views
{
    public partial class OrdersPage : ContentPage
    {
        public List<Order> Orders { get; set; }

        public OrdersPage()
        {
            InitializeComponent();

            Orders = new List<Order>
            {
                new Order { OrderName = "Pizza", Status = "Delivered" },
                new Order { OrderName = "Sushi", Status = "In Progress" },
                new Order { OrderName = "Burger", Status = "Canceled" }
            };

            BindingContext = this;
        }
    }

    public class Order
    {
        public string OrderName { get; set; }
        public string Status { get; set; }
    }
}

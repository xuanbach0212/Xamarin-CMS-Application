using System;
using System.Collections.Generic;
using System.Text;

namespace final_project.Model
{
    public class Category_Order
    {
        public string name { get; set; }
    }

    public class Datum_Order
    {
        public string address { get; set; }
        public string date { get; set; }
        public string id { get; set; }
        public List<OrderItem_Order> order_items { get; set; }
        public string status { get; set; }
        public int total_price { get; set; }
        public User_Order user { get; set; }
    }

    public class OrderItem_Order
    {
        public Product_Order product { get; set; }
        public int quantity { get; set; }
    }

    public class Product_Order
    {
        public string brand { get; set; }
        public Category_Order category { get; set; }
        public string name { get; set; }
        public int price { get; set; }
    }

    public class Order_Model
    {
        public List<Datum_Order> data { get; set; }
        public string msg { get; set; }
        public int status { get; set; }
    }

    public class Cur_Order_Model
    {
        public Datum_Order data { get; set; }
        public string msg { get; set; }
        public int status { get; set; }
    }

    public class User_Order
    {
        public string email { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
    }
}

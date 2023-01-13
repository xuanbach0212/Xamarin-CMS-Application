using System;
using System.Collections.Generic;
using System.Text;

namespace final_project.Model
{
    public class Category_Product
    {
        public string name { get; set; }
    }

    public class Product_Datum
    {
        public string brand { get; set; }
        public Category_Product category { get; set; }
        public string date { get; set; }
        public string describe { get; set; }
        public string detail { get; set; }
        public string id { get; set; }
        public string img { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public string status { get; set; }
        public int stock { get; set; }
    }


    public class Product_Model
    {
        public List<Product_Datum> data { get; set; }
        public string msg { get; set; }
        public int status { get; set; }
    }

    public class Cur_Product_Model
    {
        public Product_Datum data { get; set; }
        public string msg { get; set; }
        public int status { get; set; }
    }
}

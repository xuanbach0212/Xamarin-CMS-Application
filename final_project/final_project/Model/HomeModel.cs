using System;
using System.Collections.Generic;
using System.Text;

namespace final_project.Model
{
    public class HomeData
    {
        public int category_count { get; set; }
        public int order_count { get; set; }
        public int product_count { get; set; }
        public int user_count { get; set; }
    }

    public class HomeModel
    {
        public HomeData data { get; set; }
        public string msg { get; set; }
        public int status { get; set; }
    }
}

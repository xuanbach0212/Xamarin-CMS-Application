using System;
using System.Collections.Generic;
using System.Text;

namespace final_project.Model
{
    public class Category_Datum
    {
        public string color { get; set; }
        public string date { get; set; }
        public string icon { get; set; }
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Category_Model
    {
        public List<Category_Datum> data { get; set; }
        public string msg { get; set; }
        public int status { get; set; }
    }


}

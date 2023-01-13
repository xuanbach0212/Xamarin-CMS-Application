using System;
using System.Collections.Generic;
using System.Text;

namespace final_project.Model
{
    class Status
    {
        public string status { get; set; }
        public string color { get; set; }

        public static List<Status> CreateStatus()
        {
            List<Status> status_product;
            status_product = new List<Status>();
            status_product.Add(new Status()
            {
                status = "Pending",
                color = "#03a9f4"
            });
            status_product.Add(new Status()
            {
                status = "Paid",
                color = "#CF202A"
            });
            status_product.Add(new Status()
            {
                status = "Delivered",
                color = "#FF9900"
            });
            status_product.Add(new Status()
            {
                status = "Shipping",
                color = "#FFD700"
            });
            status_product.Add(new Status()
            {
                status = "Refund",
                color = "#CF202A"
            });
            return status_product;
        }
    }
}

using final_project.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace final_project.Views.OrderView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderDetailPage : ContentPage
    {
        bool flag = false;
        string nstatus;
        string url = "http://192.168.1.2:5000/v1/api/admin/order";
        string url_status = "http://192.168.1.2:5000/v1/api/admin/order";
        HttpClient httpClient = new HttpClient();
        string nid;
        public OrderDetailPage(string id)
        {
            nid = id;
            httpClient.DefaultRequestHeaders.Add("Connection", "close");
            httpClient.DefaultRequestHeaders.ConnectionClose = true;
            InitializeComponent();
            Get_order_by_id(id);

            picker_Status.ItemsSource = Model.Status.CreateStatus();
        }

        private async void Get_order_by_id(string id)
        {
            var result = await httpClient.GetStringAsync(url + "/" + id);
            httpClient.DefaultRequestHeaders.Add("Connection", "close");
            httpClient.DefaultRequestHeaders.ConnectionClose = true;
            var cur_order = JsonConvert.DeserializeObject<Cur_Order_Model>(result).data;

            lbl_id.Text = "Order Id: #" + cur_order.id;
            lbl_date.Text = "Order Date: " + cur_order.date.Substring(0, 16);
            lst_order_item.ItemsSource = cur_order.order_items;
            lbl_username.Text = "Customer Name: " + cur_order.user.name;
            lbl_userphone.Text = "Phone: " + cur_order.user.phone;
            lbl_address.Text = "Address: " + cur_order.address;
            lbl_total.Text = "Total price after calculated: $ " + cur_order.total_price.ToString();
            //lbl_name.Text = cur_product.name;
            //lbl_price.Text = "$ " + cur_product.price.ToString();
            //lbl_brand.Text = cur_product.brand;
            //lbl_category.Text = cur_product.category.name;
            //lbl_des.Text = cur_product.describe;
            //lbl_date.Text = cur_product.date.Substring(0, 16);
            //lbl_stock.Text = cur_product.stock.ToString();

            //for (User_Datum cu in cur_user.data)
            //{
            //    lbl_username.Text = cu.name;
            //    lbl_email.Text = cu.email;
            //    lbl_phone.Text = cu.phone;
            //}
        }

        private async void Change_Status()
        {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Add("Connection", "close");
            var new_status = new Datum_Order { status = nstatus };
            var json = JsonConvert.SerializeObject(new_status);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(url_status + "/" + nid, data);
            var result = await response.Content.ReadAsStringAsync();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (flag == true)
            {
                Change_Status();
            }
            Navigation.PopAsync();
        }

        private void picker_Status_SelectedIndexChanged(object sender, EventArgs e)
        {
            var statusList = Model.Status.CreateStatus();
            var selectedStatus = picker_Status.SelectedIndex;
            frame_status.BackgroundColor = Color.FromHex(statusList[selectedStatus].color);
            lbl_Status.Text = statusList[selectedStatus].status;
            nstatus = statusList[selectedStatus].status;
            flag = true;
        }
    }
}
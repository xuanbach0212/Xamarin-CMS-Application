using System;
using System.Collections.Generic;
using System.Text;

namespace final_project.Model
{
    public class User_Datum
    {
        public string email { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string avatar { get; set; }
    }

    public class Auth
    {
        public string email { get; set; }
        public string password { get; set; }
    }
    public class User_Model
    {
        public List<User_Datum> data { get; set; }
        public string msg { get; set; }
        public int status { get; set; }
    }

    public class Cur_User_Model
    {
        public User_Datum data { get; set; }
        public string msg { get; set; }
        public int status { get; set; }
    }

    public class Auth_Data
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
    }

    public class Auth_Model
    {
        public Auth_Data data { get; set; }
        public string msg { get; set; }
        public int status { get; set; }
    }


    public class Avatar_Model
    {
        public string avatar { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string phone { get; set; }

        //public static List<Avatar_Model> CreateAvatar()
        //{
        //    List<Avatar_Model> avatar;
        //    avatar = new List<Avatar_Model>();
        //    avatar.Add(new Avatar_Model()
        //    {
        //        avatar = "user1_icon",
        //        email ="xuanbachdao0212@gmail.com",
        //        phone = "03632327047",
        //    });
        //    avatar.Add(new Avatar_Model()
        //    {
        //        avatar = "user2_icon"
        //    });
        //    avatar.Add(new Avatar_Model()
        //    {
        //        avatar = "user3_icon"
        //    });
        //    avatar.Add(new Avatar_Model()
        //    {
        //        avatar = "user4_icon"
        //    });
        //    avatar.Add(new Avatar_Model()
        //    {
        //        avatar = "user5_icon"
        //    });
        //    avatar.Add(new Avatar_Model()
        //    {
        //        avatar = "user6_icon"
        //    });
        //    return avatar;
        //}
    }

}

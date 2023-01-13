using System;
using System.Collections.Generic;
using System.Text;

namespace final_project.Model
{
    public class Icon
    {
        public string icon { get; set; }
        public string name { get; set; }

        public static List<Icon> CreateIcon()
        {
            List<Icon> icon;
            icon = new List<Icon>();
            icon.Add(new Icon()
            {
                name = "drill icon",
                icon = "drill_icon"
            });
            icon.Add(new Icon()
            {
                name = "light icon",
                icon = "light_icon"
            });
            icon.Add(new Icon()
            {
                name = "celling light icon",
                icon = "celling_light_icon"
            });
            icon.Add(new Icon()
            {
                name = "capacitor icon",
                icon = "capacitor_icon"
            });
            icon.Add(new Icon()
            {
                name = "cord icon",
                icon = "cord_icon"
            });
            icon.Add(new Icon()
            {
                name = "fluorescent icon",
                icon = "fluorescent_icon"
            });
            icon.Add(new Icon()
            {
                name = "screwdriver icon",
                icon = "screwdriver_icon"
            });
            icon.Add(new Icon()
            {
                name = "pipe icon",
                icon = "pipe_icon"
            });
            return icon;
        }
    }
}

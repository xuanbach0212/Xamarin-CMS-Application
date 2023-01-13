using System;
using System.Collections.Generic;
using System.Text;

namespace final_project.Model
{
    public class ColorModel
    {
        public string color { get; set; }
        public string name { get; set; }

        public static List<ColorModel> CreateColor()
        {
            List<ColorModel> color;
            color = new List<ColorModel>();
            color.Add(new ColorModel()
            {
                name = "Coral Red",
                color = "#f44336"
            });
            color.Add(new ColorModel()
            {
                name = "Dark Orchid",
                color = "#9c27b0"
            });
            color.Add(new ColorModel()
            {
                name = "Banana Yellow",
                color = "#ffeb3b"
            });
            color.Add(new ColorModel()
            {
                name = "Dollar Bill",
                color = "#8BC34A"
            });
            color.Add(new ColorModel()
            {
                name = "Vivid Cerulean",
                color = "#03A9F4"
            });
            color.Add(new ColorModel()
            {
                name = "Dark Cyan",
                color = "#009688"
            });
            color.Add(new ColorModel()
            {
                name = "Steel Teal",
                color = "#607d8b"
            });
            color.Add(new ColorModel()
            {
                name = "Plump Purple",
                color = "#673ab7"
            });

            return color;
        }
    }
}

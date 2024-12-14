using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp.Components
{
    public class Resource
    {
        public static string Bus1Path = PWD(Resource2.bus1_gif);
        public static string Bus2Path = PWD(Resource2.bus2_gif);
        public static string Bus3Path = PWD(Resource2.bus3_gif);
        public static string Bus4Path = PWD(Resource2.bus4_gif);
        public static string Bus5Path = PWD(Resource2.bus5_gif);
        public static string Bus6Path = PWD(Resource2.bus6_gif);
        public static string Home_LeftSide_Bar2= PWD(Resource2.Home_LeftSideBar2_png);
        public static string Pupils_Facilities_Background_jpg = PWD(Resource2.Pupils_Facilities_Background_jpg);
        public static string Student_Facilities_Background_jpg = PWD(Resource2.Student_Facilities_Background_jpg);
        public static string tram4_gif = PWD(Resource2.tram4_gif);

        public static string Road_jpg = PWD(Resource3.Road_jpg);
        public static string logoSTB_png = PWD(Resource3.logoSTB_png);
        public static string Pupils_Facilities = PWD(Resource2.Pupils_Facilities_Background_jpg);
        public static string Student_Facilities = PWD(Resource2.Student_Facilities_Background_jpg);

        // for Search.xaml and Search.xaml.cs
        public static string simple_map = PWD(Resource3.simple_map_png);
        public static string tram_video = PWD(Resource3.tram_video_mp4);
        public static string bus_video = PWD(Resource3.bus_video_mp4);
        public static string metro_video = PWD(Resource3.metro_video_mp4);
        public static string autouz101 = PWD(Resource4.autobuz101_png);
        public static string autobuz102 = PWD(Resource4.autobuz102_png);
        public static string autobuz103 = PWD(Resource4.autobuz103_png);
        public static string default_map_new = PWD(Resource4.default_map_new_png);
        public static string metrou1 = PWD(Resource4.metrou1_png);
        public static string tramvai10 = PWD(Resource4.tramvai10_png);
        public static string tramvai11 = PWD(Resource4.tramvai11_png);
        public static string tramvai12 = PWD(Resource4.tramvai12_png);

        public static string PWD(string path)
        {
            string basePath = AppContext.BaseDirectory;
            basePath = Directory.GetParent(basePath).Parent.Parent.FullName;
            string fullPath = System.IO.Path.Combine(basePath, path);
            return fullPath;
        }

    }
}

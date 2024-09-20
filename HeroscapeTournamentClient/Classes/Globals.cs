using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroscapeTournamentClient.Classes
{
    public static class Globals
    {
        public enum PageLabel { 
            PageLogin = 0,
            PageSignup = 1,
            PageMain = 2,
            PageBrowse = 3,
            PageBuild = 4,
            PageBattle = 5
        }
        public static string[] MonthNames =
        {
            "None",
            "Jan",
            "Feb",
            "Mar",
            "Apr",
            "May",
            "Jun",
            "Jul",
            "Aug",
            "Sep",
            "Oct",
            "Nov",
            "Dec"
        };
        public static string[] FormatNames =
        {
            "Standard Singles",
            "Heroes Only Singles",
            "Standard Doubles"
        };
    }
}

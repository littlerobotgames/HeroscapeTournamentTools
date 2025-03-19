using HeroscapeTournamentClient.Buttons;
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
            PageBattle = 5,
            PageBuildMenu = 6,
            PageBattleArmy = 7
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
            "Standard Doubles",
            "The Gauntlet of Valhalla"
        };
        public static Color GetGeneralColorBase(string _general)
        {
            switch (_general)
            {
                case "Jandar":
                    return Color.LightBlue;
                case "Ullar":
                    return Color.LightGreen;
                case "Vydar":
                    return Color.LightGray;
                case "Einar":
                    return Color.Tan;
                case "Utgar":
                    return Color.PaleVioletRed;
                case "Aquilla":
                    return Color.DarkBlue;
                case "Valkrill":
                    return Color.Yellow;
                case "Marvel":
                    return Color.Purple;
                case "Revna":
                    return Color.LightGray;
                default:
                    return Color.Gray;
            }
        }
        public static Color GetGeneralColorAccent(string _general)
        {
            switch (_general)
            {
                case "Aquilla":
                    return Color.White;
                case "Marvel":
                    return Color.White;
                default:
                    return Color.Black;
            }
        }
    }
}

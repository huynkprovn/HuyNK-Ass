using System;
using LeagueSharp.Common;

namespace HuyNKSeries
{
    class ultils:Menus
    {
        public static bool getm_bool(String menu)
        {
            bool result;
            result = Menus.menu.Item(menu).GetValue<bool>();
            return result;
        }
        public static int getm_value(String menu)
        {
            int result;
            result = Menus.menu.Item(menu).GetValue<Slider>().Value;
            return result;
        }
    }
}

using System;
using LeagueSharp.Common;
namespace HuyNKSeriesV2
{
    class Tienich : Caidat
    {
        public static bool kich_hoat(String menu)
        {
            bool ketqua;
            ketqua = Caidat.menu.Item(menu).GetValue<bool>();
            return ketqua;
        }
        public static int gia_tri(String menu)
        {
            int ketqua;
            ketqua = Caidat.menu.Item(menu).GetValue<Slider>().Value;
            return ketqua;
        }
    }
}

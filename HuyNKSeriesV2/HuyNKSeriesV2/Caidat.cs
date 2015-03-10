using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LeagueSharp;
using LeagueSharp.Common;

using SharpDX;

using Color = System.Drawing.Color;

namespace HuyNKSeriesV2
{
    class Caidat
    {
#region KHAI BAO THADIEU
        public static Orbwalking.Orbwalker Orbwalker;

        public static Menu menu;
        public static Menu orbwalkerMenu = new Menu("Thả diều", "Orbwalker");

        public static Obj_AI_Hero player = ObjectManager.Player;
        public static string TenTuong = player.ChampionName;
#endregion
#region CAI DAT MENU
        public static void SetuptMenu()
        {
            Game.PrintChat("|===================================|");
            Game.PrintChat("|   <font color = \"#FFB6C1\">HuyNK Serier</font> by <font color = \"#00FFFF\">HuyNK</font> |");
            Game.PrintChat("|===================================|");
            Game.PrintChat("|<font color = \"#87CEEB\">Feel free to donate via Paypal to:</font> <font color = \"#FFFF00\">khachuyvk@gmail.com</font>|");
            Game.PrintChat("|===================================|");



            Caidat.menu = new Menu("【HuyNK Series】 " + Caidat.TenTuong, "huynks" + Caidat.TenTuong, true);

            //Info
            menu.AddSubMenu(new Menu("Thông Tin", "Info"));
            menu.SubMenu("Info").AddItem(new MenuItem("[Author]", "[Tác giả: HuyNK]"));
            menu.SubMenu("Info").AddItem(new MenuItem("[Paypal]", "[Ngân Lượng: khachuyvk@gmail.com]"));
            menu.SubMenu("Info").AddItem(new MenuItem("[Paypal0]", "[Danh sách hỗ trợ]"));
            menu.SubMenu("Info").AddItem(new MenuItem("[Paypal1]", "[Ezreal]"));
            menu.SubMenu("Info").AddItem(new MenuItem("[Paypal2]", "[Jinx]"));
            menu.SubMenu("Info").AddItem(new MenuItem("[Paypal3]", "[Kalista]"));
            menu.SubMenu("Info").AddItem(new MenuItem("[Paypal4]", "[Teemo]"));
            menu.SubMenu("Info").AddItem(new MenuItem("[Paypal5]", "[Orbwalker tất cả các tướng]"));

            //Target selector
            var targetSelectorMenu = new Menu("Chọn mục tiêu", "Target Selector");
            TargetSelector.AddToMenu(targetSelectorMenu);
            menu.AddSubMenu(targetSelectorMenu);
            //Orbwalker
            orbwalkerMenu.AddItem(new MenuItem("Orbwalker_Mode", "Thay đổi Orbwalker").SetValue(false));
            menu.AddSubMenu(orbwalkerMenu);
            ChonOrbwalker(menu.Item("Orbwalker_Mode").GetValue<bool>());
         


            //Packet Menu
            menu.AddSubMenu(new Menu("Sử dụng Packets", "Packets"));
            menu.SubMenu("Packets").AddItem(new MenuItem("packet", "Dùng Packets").SetValue(false));
           
            menu.AddToMainMenu();

            try
            {
                if (Activator.CreateInstance(null, "HuyNKSeriesV2.ListTuong." + player.ChampionName) != null)
                {
                    Game.PrintChat("<font color = \"#FFB6C1\">HUYNK Series " + player.ChampionName + " Loaded!</font>");
                }
            }
            catch
            {
                Game.PrintChat("HuyNK Series => {0} Khong Ho Tro !", player.ChampionName);
            }
        }

        public static void ChonOrbwalker(bool mode)
        {
            if (mode)
            {
                // Nếu bật sẽ chọn kiếu trong lib Common
                Orbwalker = new Orbwalking.Orbwalker(orbwalkerMenu);
                

            }
            else
            {
                //Kiểu của LX Orb
                HuyNKOrbwalker.AddToMenu(orbwalkerMenu);
            }
        }
#endregion
    }

}

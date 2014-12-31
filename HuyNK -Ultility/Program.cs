using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Common;

namespace SAwareness
{
    internal static class Menu
    {
        public static MenuItemSettings ItemPanel = new MenuItemSettings();
        public static MenuItemSettings AutoLevler = new MenuItemSettings(typeof (AutoLevler)); //Only priority works

        public static MenuItemSettings UiTracker = new MenuItemSettings(typeof (UiTracker));
            //Works but need many improvements

        public static MenuItemSettings UimTracker = new MenuItemSettings(typeof (UimTracker));
            //Works but need many improvements

        public static MenuItemSettings SsCaller = new MenuItemSettings(typeof (SsCaller)); //Works
        public static MenuItemSettings Tracker = new MenuItemSettings();
        public static MenuItemSettings WaypointTracker = new MenuItemSettings(typeof (WaypointTracker)); //Works
        public static MenuItemSettings CloneTracker = new MenuItemSettings(typeof (CloneTracker)); //Works
        public static MenuItemSettings Timers = new MenuItemSettings(typeof (Timers));
        public static MenuItemSettings JungleTimer = new MenuItemSettings(); //Works
        public static MenuItemSettings RelictTimer = new MenuItemSettings(); //Works
        public static MenuItemSettings HealthTimer = new MenuItemSettings(); //Works
        public static MenuItemSettings InhibitorTimer = new MenuItemSettings(); //Works
        public static MenuItemSettings SummonerTimer = new MenuItemSettings(); //Works
        public static MenuItemSettings Health = new MenuItemSettings(typeof (Health));
        public static MenuItemSettings TowerHealth = new MenuItemSettings(); //Missing HPBarPos
        public static MenuItemSettings InhibitorHealth = new MenuItemSettings(); //Works

        public static MenuItemSettings DestinationTracker = new MenuItemSettings(typeof (DestinationTracker));
            //Work & Needs testing

        public static MenuItemSettings Detector = new MenuItemSettings();

        public static MenuItemSettings VisionDetector = new MenuItemSettings(typeof (HiddenObject));
            //Works - OnProcessSpell bugged

        public static MenuItemSettings RecallDetector = new MenuItemSettings(typeof (RecallDetector)); //Works

        public static MenuItemSettings Range = new MenuItemSettings(typeof (Ranges));
            //Many ranges are bugged. Waiting for SpellLib

        public static MenuItemSettings TowerRange = new MenuItemSettings();
        public static MenuItemSettings ShopRange = new MenuItemSettings();
        public static MenuItemSettings VisionRange = new MenuItemSettings();
        public static MenuItemSettings ExperienceRange = new MenuItemSettings();
        public static MenuItemSettings AttackRange = new MenuItemSettings();
        public static MenuItemSettings SpellQRange = new MenuItemSettings();
        public static MenuItemSettings SpellWRange = new MenuItemSettings();
        public static MenuItemSettings SpellERange = new MenuItemSettings();
        public static MenuItemSettings SpellRRange = new MenuItemSettings();
        public static MenuItemSettings ImmuneTimer = new MenuItemSettings(typeof (ImmuneTimer)); //Works
        public static MenuItemSettings Ganks = new MenuItemSettings();
        public static MenuItemSettings GankTracker = new MenuItemSettings(typeof (GankPotentialTracker)); //Works
        public static MenuItemSettings GankDetector = new MenuItemSettings(typeof (GankDetector)); //Works
        public static MenuItemSettings AltarTimer = new MenuItemSettings();
        public static MenuItemSettings Wards = new MenuItemSettings();
        public static MenuItemSettings WardCorrector = new MenuItemSettings(typeof (WardCorrector)); //Works
        public static MenuItemSettings BushRevealer = new MenuItemSettings(typeof (BushRevealer)); //Works        
        public static MenuItemSettings InvisibleRevealer = new MenuItemSettings(typeof (InvisibleRevealer)); //Works   
        public static MenuItemSettings SkinChanger = new MenuItemSettings(typeof (SkinChanger)); //Works
        public static MenuItemSettings AutoSmite = new MenuItemSettings(typeof (AutoSmite)); //Works
        public static MenuItemSettings AutoPot = new MenuItemSettings(typeof (AutoPot));
        public static MenuItemSettings SafeMovement = new MenuItemSettings(typeof (SafeMovement));
        public static MenuItemSettings AutoShield = new MenuItemSettings(typeof (AutoShield));
        public static MenuItemSettings AutoShieldBlockableSpells = new MenuItemSettings();
        public static MenuItemSettings Misc = new MenuItemSettings();
        public static MenuItemSettings MoveToMouse = new MenuItemSettings(typeof (MoveToMouse));
        public static MenuItemSettings SurrenderVote = new MenuItemSettings(typeof (SurrenderVote));
        public static MenuItemSettings AutoLatern = new MenuItemSettings(typeof (AutoLatern));
        public static MenuItemSettings DisconnectDetector = new MenuItemSettings(typeof (DisconnectDetector));
        public static MenuItemSettings AutoJump = new MenuItemSettings(typeof (AutoJump));
        public static MenuItemSettings TurnAround = new MenuItemSettings(typeof (TurnAround));
        public static MenuItemSettings MinionBars = new MenuItemSettings(typeof(MinionBars));
        public static MenuItemSettings MinionLocation = new MenuItemSettings(typeof(MinionLocation));
        public static MenuItemSettings FlashJuke = new MenuItemSettings(typeof(FlashJuke));
        public static MenuItemSettings Activator = new MenuItemSettings(typeof (Activator));
        public static MenuItemSettings ActivatorAutoSummonerSpell = new MenuItemSettings();
        public static MenuItemSettings ActivatorAutoSummonerSpellIgnite = new MenuItemSettings();
        public static MenuItemSettings ActivatorAutoSummonerSpellHeal = new MenuItemSettings();
        public static MenuItemSettings ActivatorAutoSummonerSpellBarrier = new MenuItemSettings();
        public static MenuItemSettings ActivatorAutoSummonerSpellExhaust = new MenuItemSettings();
        public static MenuItemSettings ActivatorAutoSummonerSpellCleanse = new MenuItemSettings();
        public static MenuItemSettings ActivatorOffensive = new MenuItemSettings();
        public static MenuItemSettings ActivatorOffensiveAd = new MenuItemSettings();
        public static MenuItemSettings ActivatorOffensiveAp = new MenuItemSettings();
        public static MenuItemSettings ActivatorDefensive = new MenuItemSettings();
        public static MenuItemSettings ActivatorDefensiveCleanseConfig = new MenuItemSettings();
        public static MenuItemSettings ActivatorDefensiveSelfShield = new MenuItemSettings();
        public static MenuItemSettings ActivatorDefensiveWoogletZhonya = new MenuItemSettings();
        public static MenuItemSettings ActivatorDefensiveDebuffSlow = new MenuItemSettings();
        public static MenuItemSettings ActivatorDefensiveCleanseSelf = new MenuItemSettings();
        public static MenuItemSettings ActivatorDefensiveShieldBoost = new MenuItemSettings();
        public static MenuItemSettings ActivatorDefensiveMikaelCleanse = new MenuItemSettings();
        public static MenuItemSettings ActivatorMisc = new MenuItemSettings();
        public static MenuItemSettings ActivatorAutoHeal = new MenuItemSettings(typeof(AutoHeal));
        public static MenuItemSettings ActivatorAutoUlt = new MenuItemSettings(typeof(AutoUlt));
        public static MenuItemSettings ActivatorAutoQss = new MenuItemSettings(typeof(AutoQSS));
        public static MenuItemSettings ActivatorAutoQssConfig = new MenuItemSettings(typeof(AutoQSS));
        public static MenuItemSettings Killable = new MenuItemSettings(typeof (Killable));
        public static MenuItemSettings EasyRangedJungle = new MenuItemSettings(typeof(EasyRangedJungle));
        public static MenuItemSettings FowWardPlacement = new MenuItemSettings(typeof(FowWardPlacement));
        public static MenuItemSettings RealTime = new MenuItemSettings(typeof(RealTime));
        public static MenuItemSettings ShowPing = new MenuItemSettings(typeof(ShowPing));
        public static MenuItemSettings PingerName = new MenuItemSettings(typeof(PingerName));
        public static MenuItemSettings AntiVisualScreenStealth = new MenuItemSettings(typeof(AntiVisualScreenStealth));
        public static MenuItemSettings EloDisplayer = new MenuItemSettings(typeof(EloDisplayer));

        public static MenuItemSettings GlobalSettings = new MenuItemSettings();

        public class MenuItemSettings
        {
            public bool ForceDisable;
            public dynamic Item;
            public LeagueSharp.Common.Menu Menu;
            public List<MenuItem> MenuItems = new List<MenuItem>();
            public String Name;
            public List<MenuItemSettings> SubMenus = new List<MenuItemSettings>();
            public Type Type;

            public MenuItemSettings(Type type, dynamic item)
            {
                Type = type;
                Item = item;
            }

            public MenuItemSettings(dynamic item)
            {
                Item = item;
            }

            public MenuItemSettings(Type type)
            {
                Type = type;
            }

            public MenuItemSettings(String name)
            {
                Name = name;
            }

            public MenuItemSettings()
            {
            }

            public MenuItemSettings AddMenuItemSettings(String displayName, String name)
            {
                SubMenus.Add(new MenuItemSettings(name));
                MenuItemSettings tempSettings = GetMenuSettings(name);
                if (tempSettings == null)
                {
                    throw new NullReferenceException(name + " not found");
                }
                tempSettings.Menu = Menu.AddSubMenu(new LeagueSharp.Common.Menu(displayName, name));
                return tempSettings;
            }

            public bool GetActive()
            {
                if (Menu == null)
                    return false;
                foreach (MenuItem item in Menu.Items)
                {
                    if (item.DisplayName == "Bật")
                    {
                        if (item.GetValue<bool>())
                        {
                            return true;
                        }
                        return false;
                    }
                }
                return false;
            }

            public void SetActive(bool active)
            {
                if (Menu == null)
                    return;
                foreach (MenuItem item in Menu.Items)
                {
                    if (item.DisplayName == "Bật")
                    {
                        item.SetValue(active);
                        return;
                    }
                }
            }

            public MenuItem GetMenuItem(String menuName)
            {
                if (Menu == null)
                    return null;
                foreach (MenuItem item in Menu.Items)
                {
                    if (item.Name == menuName)
                    {
                        return item;
                    }
                }
                return null;
            }

            public LeagueSharp.Common.Menu GetSubMenu(String menuName)
            {
                if (Menu == null)
                    return null;
                return Menu.SubMenu(menuName);
            }

            public MenuItemSettings GetMenuSettings(String name)
            {
                foreach (MenuItemSettings menu in SubMenus)
                {
                    if (menu.Name.Contains(name))
                        return menu;
                }
                return null;
            }
        }

        //public static MenuItemSettings  = new MenuItemSettings();
    }

    internal class Program
    {
        private static float lastDebugTime = 0;

        private static void Main(string[] args)
        {
            try
            {
                //SUpdater.UpdateCheck();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return;
            }

            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
        }

        private static void CreateMenu()
        {
            //http://www.cambiaresearch.com/articles/15/javascript-char-codes-key-codes
            try
            {
                Menu.MenuItemSettings tempSettings;
                var menu = new LeagueSharp.Common.Menu("【HuyNK】Hỗ Trợ", "SAwareness", true);

                //Not crashing
                Menu.Timers.Menu = menu.AddSubMenu(new LeagueSharp.Common.Menu("Thời gian", "SAwarenessTimers"));
                Menu.Timers.MenuItems.Add(
                    Menu.Timers.Menu.AddItem(
                        new MenuItem("SAwarenessTimersPingTimes", "Ping khi xuất hiện sau ").SetValue(new Slider(0, 5, 0))));
                Menu.Timers.MenuItems.Add(
                    Menu.Timers.Menu.AddItem(
                        new MenuItem("SAwarenessTimersRemindTime", "Nhắc thời gian").SetValue(new Slider(0, 50, 0))));
                Menu.Timers.MenuItems.Add(
                    Menu.Timers.Menu.AddItem(new MenuItem("SAwarenessTimersLocalPing", "Ping khi hiện").SetValue(true)));
                Menu.Timers.MenuItems.Add(
                    Menu.Timers.Menu.AddItem(
                        new MenuItem("SAwarenessTimersChatChoice", "Chat khi hiện").SetValue(
                        new StringList(new[] { "Không", "Local", "Bình Thường" }))));
                Menu.JungleTimer.Menu =
                    Menu.Timers.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Thời gian rừng", "SAwarenessJungleTimer"));
                Menu.JungleTimer.MenuItems.Add(
                    Menu.JungleTimer.Menu.AddItem(new MenuItem("SAwarenessJungleTimersActive", "Bật").SetValue(false)));
                Menu.RelictTimer.Menu =
                    Menu.Timers.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Thời gian chết", "SAwarenessRelictTimer"));
                Menu.RelictTimer.MenuItems.Add(
                    Menu.RelictTimer.Menu.AddItem(new MenuItem("SAwarenessRelictTimersActive", "Bật").SetValue(false)));
                Menu.HealthTimer.Menu =
                    Menu.Timers.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Thời gian sống", "SAwarenessHealthTimer"));
                Menu.HealthTimer.MenuItems.Add(
                    Menu.HealthTimer.Menu.AddItem(new MenuItem("SAwarenessHealthTimersActive", "Bật").SetValue(false)));
                Menu.InhibitorTimer.Menu =
                    Menu.Timers.Menu.AddSubMenu(new LeagueSharp.Common.Menu("InhibitorTimer", "SAwarenessInhibitorTimer"));
                Menu.InhibitorTimer.MenuItems.Add(
                    Menu.InhibitorTimer.Menu.AddItem(
                        new MenuItem("SAwarenessInhibitorTimersActive", "Bật").SetValue(false)));
                Menu.AltarTimer.Menu =
                    Menu.Timers.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Giờ tế đàn", "SAwarenessAltarTimer"));
                Menu.AltarTimer.MenuItems.Add(
                    Menu.AltarTimer.Menu.AddItem(new MenuItem("SAwarenessAltarTimersActive", "Bật").SetValue(false)));
                Menu.ImmuneTimer.Menu =
                    Menu.Timers.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Miễn nhiễm", "SAwarenessImmuneTimer"));
                Menu.ImmuneTimer.MenuItems.Add(
                    Menu.ImmuneTimer.Menu.AddItem(new MenuItem("SAwarenessImmuneTimersActive", "Bật").SetValue(false)));
                Menu.SummonerTimer.Menu =
                    Menu.Timers.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Thời gian phép bổ trợ", "SAwarenessSummonerTimer"));
                Menu.SummonerTimer.MenuItems.Add(
                    Menu.SummonerTimer.Menu.AddItem(new MenuItem("SAwarenessSummonerTimersActive", "Bật").SetValue(false)));
                Menu.Timers.MenuItems.Add(
                    Menu.Timers.Menu.AddItem(new MenuItem("SAwarenessTimersActive", "Bật").SetValue(false)));

                //Not crashing
                Menu.Range.Menu = menu.AddSubMenu(new LeagueSharp.Common.Menu("Hiện ranges", "SAwarenessRanges"));
                Menu.ShopRange.Menu =
                    Menu.Range.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Tầm cửa hàng",
                        "SAwarenessShopRange"));
                Menu.ShopRange.MenuItems.Add(
                    Menu.ShopRange.Menu.AddItem(
                        new MenuItem("SAwarenessShopRangeMode", "Kiểu").SetValue(
                            new StringList(new[] { "Bạn", "Kẻ thù", "Cả hai" }))));
                Menu.ShopRange.MenuItems.Add(
                    Menu.ShopRange.Menu.AddItem(
                        new MenuItem("SAwarenessShopRangeActive", "Bật").SetValue(false)));
                Menu.VisionRange.Menu =
                    Menu.Range.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Tầm nhìn",
                        "SAwarenessVisionRange"));
                Menu.VisionRange.MenuItems.Add(
                    Menu.VisionRange.Menu.AddItem(
                        new MenuItem("SAwarenessVisionRangeMode", "Kiểu").SetValue(
                            new StringList(new[] { "Bạn", "Kẻ thù", "Cả hai" }))));
                Menu.VisionRange.MenuItems.Add(
                    Menu.VisionRange.Menu.AddItem(
                        new MenuItem("SAwarenessVisionRangeActive", "Bật").SetValue(false)));
                Menu.ExperienceRange.Menu =
                    Menu.Range.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Tầm hưởng EXP",
                        "SAwarenessExperienceRange"));
                Menu.ExperienceRange.MenuItems.Add(
                    Menu.ExperienceRange.Menu.AddItem(
                        new MenuItem("SAwarenessExperienceRangeMode", "Kiểu").SetValue(
                            new StringList(new[] { "Bạn", "Kẻ thù", "Cả hai" }))));
                Menu.ExperienceRange.MenuItems.Add(
                    Menu.ExperienceRange.Menu.AddItem(
                        new MenuItem("SAwarenessExperienceRangeActive", "Bật").SetValue(false)));
                Menu.AttackRange.Menu =
                    Menu.Range.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Tầm Đánh", "SAwarenessAttackRange"));
                Menu.AttackRange.MenuItems.Add(
                    Menu.AttackRange.Menu.AddItem(
                        new MenuItem("SAwarenessAttackRangeMode", "Kiểu").SetValue(
                            new StringList(new[] { "Bạn", "Kẻ thù", "Cả hai" }))));
                Menu.AttackRange.MenuItems.Add(
                    Menu.AttackRange.Menu.AddItem(new MenuItem("SAwarenessAttackRangeActive", "Bật").SetValue(false)));
                Menu.TowerRange.Menu =
                    Menu.Range.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Trụ", "SAwarenessTowerRange"));
                Menu.TowerRange.MenuItems.Add(
                    Menu.TowerRange.Menu.AddItem(
                        new MenuItem("SAwarenessTowerRangeMode", "Kiểu").SetValue(
                            new StringList(new[] { "Bạn", "Kẻ thù", "Cả hai" }))));
                Menu.TowerRange.MenuItems.Add(
                    Menu.TowerRange.Menu.AddItem(new MenuItem("SAwarenessTowerRangeRange", "Khoảng cách").SetValue(new Slider(2000, 10000,
                            0))));
                Menu.TowerRange.MenuItems.Add(
                    Menu.TowerRange.Menu.AddItem(new MenuItem("SAwarenessTowerRangeActive", "Bật").SetValue(false)));
                Menu.SpellQRange.Menu =
                    Menu.Range.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Vòng Q", "SAwarenessSpellQRange"));
                Menu.SpellQRange.MenuItems.Add(
                    Menu.SpellQRange.Menu.AddItem(
                        new MenuItem("SAwarenessSpellQRangeMode", "Kiểu").SetValue(
                            new StringList(new[] { "Bạn", "Kẻ thù", "Cả hai" }))));
                Menu.SpellQRange.MenuItems.Add(
                    Menu.SpellQRange.Menu.AddItem(new MenuItem("SAwarenessSpellQRangeActive", "Bật").SetValue(false)));
                Menu.SpellWRange.Menu =
                    Menu.Range.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Vòng W", "SAwarenessSpellWRange"));
                Menu.SpellWRange.MenuItems.Add(
                    Menu.SpellWRange.Menu.AddItem(
                        new MenuItem("SAwarenessSpellWRangeMode", "Kiểu").SetValue(
                            new StringList(new[] { "Bạn", "Kẻ thù", "Cả hai" }))));
                Menu.SpellWRange.MenuItems.Add(
                    Menu.SpellWRange.Menu.AddItem(new MenuItem("SAwarenessSpellWRangeActive", "Bật").SetValue(false)));
                Menu.SpellERange.Menu =
                    Menu.Range.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Vòng E", "SAwarenessSpellERange"));
                Menu.SpellERange.MenuItems.Add(
                    Menu.SpellERange.Menu.AddItem(
                        new MenuItem("SAwarenessSpellERangeMode", "Kiểu").SetValue(
                            new StringList(new[] { "Bạn", "Kẻ thù", "Cả hai" }))));
                Menu.SpellERange.MenuItems.Add(
                    Menu.SpellERange.Menu.AddItem(new MenuItem("SAwarenessSpellERangeActive", "Bật").SetValue(false)));
                Menu.SpellRRange.Menu =
                    Menu.Range.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Vong R", "SAwarenessSpellRRange"));
                Menu.SpellRRange.MenuItems.Add(
                    Menu.SpellRRange.Menu.AddItem(
                        new MenuItem("SAwarenessSpellRRangeMode", "Kiểu").SetValue(
                            new StringList(new[] { "Bạn", "Kẻ thù", "Cả hai" }))));
                Menu.SpellRRange.MenuItems.Add(
                    Menu.SpellRRange.Menu.AddItem(new MenuItem("SAwarenessSpellRRangeActive", "Bật").SetValue(false)));
                Menu.Range.MenuItems.Add(
                    Menu.Range.Menu.AddItem(new MenuItem("SAwarenessRangesActive", "Bật").SetValue(false)));
               
                //Not crashing
                Menu.Tracker.Menu = menu.AddSubMenu(new LeagueSharp.Common.Menu("Tracker", "SAwarenessTracker"));
                Menu.WaypointTracker.Menu =
                    Menu.Tracker.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Đường truy tìm",
                        "SAwarenessWaypointTracker"));
                Menu.WaypointTracker.MenuItems.Add(
                    Menu.WaypointTracker.Menu.AddItem(
                        new MenuItem("SAwarenessWaypointTrackerActive", "Bật").SetValue(false)));
                Menu.DestinationTracker.Menu =
                    Menu.Tracker.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Kết thúc theo dõi",
                        "SAwarenessDestinationTracker"));
                Menu.DestinationTracker.MenuItems.Add(
                    Menu.DestinationTracker.Menu.AddItem(
                        new MenuItem("SAwarenessDestinationTrackerActive", "Bật").SetValue(false)));
                Menu.CloneTracker.Menu =
                    Menu.Tracker.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Tracker củaBạn", "SAwarenessCloneTracker"));
                Menu.CloneTracker.MenuItems.Add(
                    Menu.CloneTracker.Menu.AddItem(new MenuItem("SAwarenessCloneTrackerActive", "Bật").SetValue(false)));
                Menu.UiTracker.Menu =
                    Menu.Tracker.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Hiển thị CD", "SAwarenessUITracker"));
                Menu.UiTracker.MenuItems.Add(
                    Menu.UiTracker.Menu.AddItem(new MenuItem("SAwarenessItemPanelActive", "Bản điều chỉnh").SetValue(false)));
                Menu.UiTracker.MenuItems.Add(
                    Menu.UiTracker.Menu.AddItem(
                        new MenuItem("SAwarenessUITrackerScale", "Tỷ lệ").SetValue(new Slider(100, 100, 0))));
                tempSettings = Menu.UiTracker.AddMenuItemSettings("CD của địch",
                    "SAwarenessUITrackerEnemyTracker");
                tempSettings.MenuItems.Add(
                    tempSettings.Menu.AddItem(
                        new MenuItem("SAwarenessUITrackerEnemyTrackerXPos", "Điểm X").SetValue(new Slider(-1, 10000,
                            0))));
                tempSettings.MenuItems.Add(
                    tempSettings.Menu.AddItem(
                        new MenuItem("SAwarenessUITrackerEnemyTrackerYPos", "Điểm Y").SetValue(new Slider(-1, 10000,
                            0))));
                tempSettings.MenuItems.Add(
                    tempSettings.Menu.AddItem(
                        new MenuItem("SAwarenessUITrackerEnemyTrackerMode", "Kiểu").SetValue(
                            new StringList(new[] { "Gần nhất","Chỉ 1 ","Tất cả" }))));
                tempSettings.MenuItems.Add(
                    tempSettings.Menu.AddItem(
                        new MenuItem("SAwarenessUITrackerEnemyTrackerSideDisplayMode", "Kiểu").SetValue(
                            new StringList(new[] { "Bình thường", "Đơn giản", "Bản thân" }))));
                tempSettings.MenuItems.Add(
                    tempSettings.Menu.AddItem(
                        new MenuItem("SAwarenessUITrackerEnemyTrackerHeadMode", "Tỷ lệ").SetValue(
                            new StringList(new[] { "Nhỏ", "Lớn" }))));
                tempSettings.MenuItems.Add(
                    tempSettings.Menu.AddItem(
                        new MenuItem("SAwarenessUITrackerEnemyTrackerHeadDisplayMode", "Hiển thị trên cao").SetValue(
                            new StringList(new[] { "Bình thường", "Đơn giản" }))));
                tempSettings.MenuItems.Add(
                    tempSettings.Menu.AddItem(
                        new MenuItem("SAwarenessUITrackerEnemyTrackerActive", "Bật").SetValue(false)));
                tempSettings = Menu.UiTracker.AddMenuItemSettings("CD đồng đội",
                    "SAwarenessUITrackerAllyTracker");
                tempSettings.MenuItems.Add(
                    tempSettings.Menu.AddItem(
                        new MenuItem("SAwarenessUITrackerAllyTrackerXPos", "Điểm X").SetValue(new Slider(-1, 10000,
                            0))));
                tempSettings.MenuItems.Add(
                    tempSettings.Menu.AddItem(
                        new MenuItem("SAwarenessUITrackerAllyTrackerYPos", "Điểm Y").SetValue(new Slider(-1, 10000,
                            0))));
                tempSettings.MenuItems.Add(
                    tempSettings.Menu.AddItem(
                        new MenuItem("SAwarenessUITrackerAllyTrackerMode", "Kiểu").SetValue(
                            new StringList(new[] { "Gần nhất","Chỉ 1 ","Tất cả" }))));
                tempSettings.MenuItems.Add(
                    tempSettings.Menu.AddItem(
                        new MenuItem("SAwarenessUITrackerAllyTrackerSideDisplayMode", "Kiểu").SetValue(
                            new StringList(new[] { "Bình thường","Đơn giản ","Đội"}))));
                tempSettings.MenuItems.Add(
                    tempSettings.Menu.AddItem(
                        new MenuItem("SAwarenessUITrackerAllyTrackerHeadMode", "Tỷ lệ").SetValue(
                            new StringList(new[] { "Nhỏ", "Lớn" }))));
                tempSettings.MenuItems.Add(
                    tempSettings.Menu.AddItem(
                        new MenuItem("SAwarenessUITrackerAllyTrackerHeadDisplayMode", "Hiển thị tren cao").SetValue
                            (new StringList(new[] { "Bình thường", "Đơn giản" }))));
                tempSettings.MenuItems.Add(
                    tempSettings.Menu.AddItem(
                        new MenuItem("SAwarenessUITrackerAllyTrackerActive", "Bật").SetValue(false)));
                //Menu.UiTracker.MenuItems.Add(Menu.UiTracker.Menu.AddItem(new LeagueSharp.Common.MenuItem("SAwarenessUITrackerCameraMoveActive", "Camera move active").SetValue(false)));
                Menu.UiTracker.MenuItems.Add(
                    Menu.UiTracker.Menu.AddItem(
                        new MenuItem("SAwarenessUITrackerPingActive", "PingBật").SetValue(false)));
                Menu.UiTracker.MenuItems.Add(
                    Menu.UiTracker.Menu.AddItem(new MenuItem("SAwarenessUITrackerActive", "Bật").SetValue(false)));
                Menu.UimTracker.Menu =
                    Menu.Tracker.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Hiện munu Ulti Tracker", "SAwarenessUIMTracker"));
                Menu.UimTracker.MenuItems.Add(
                    Menu.UimTracker.Menu.AddItem(
                        new MenuItem("SAwarenessUIMTrackerScale", "Tỷ lệ").SetValue(new Slider(100, 100, 0))));
                Menu.UimTracker.MenuItems.Add(
                    Menu.UimTracker.Menu.AddItem(new MenuItem("SAwarenessUIMTrackerShowSS", "Hiện đường Tốc biến").SetValue(false)));
                Menu.UimTracker.MenuItems.Add(
                    Menu.UimTracker.Menu.AddItem(new MenuItem("SAwarenessUIMTrackerActive", "Bật").SetValue(false)));
                Menu.SsCaller.Menu =
                    Menu.Tracker.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Ping khi tốc biến", "SAwarenessSSCaller"));
                Menu.SsCaller.MenuItems.Add(
                    Menu.SsCaller.Menu.AddItem(
                        new MenuItem("SAwarenessSSCallerPingTimes", "Số lần Ping").SetValue(new Slider(0, 5, 0))));
                Menu.SsCaller.MenuItems.Add(
                    Menu.SsCaller.Menu.AddItem(
                        new MenuItem("SAwarenessSSCallerPingType", "Loại Ping").SetValue(
                            new StringList(new[] { "Bình thường", "Nguy hiểm", "Rời lane", "Trên đường tới", "Rút lui", "Hỗ trợ" }))));
                Menu.SsCaller.MenuItems.Add(
                    Menu.SsCaller.Menu.AddItem(new MenuItem("SAwarenessSSCallerLocalPing", "Ping chỉ mình nghe").SetValue(false)));
                Menu.SsCaller.MenuItems.Add(
                    Menu.SsCaller.Menu.AddItem(
                        new MenuItem("SAwarenessSSCallerChatChoice", "Chọn trò chuyện").SetValue(
                            new StringList(new[] { "Không", "Chỉ trong team", "Bình thường" }))));
                Menu.SsCaller.MenuItems.Add(
                    Menu.SsCaller.Menu.AddItem(
                        new MenuItem("SAwarenessSSCallerDisableTime", "Thời gian khống chế").SetValue(new Slider(20, 180, 1))));
                Menu.SsCaller.MenuItems.Add(
                    Menu.SsCaller.Menu.AddItem(new MenuItem("SAwarenessSSCallerActive", "Bật").SetValue(false)));
                Menu.Killable.Menu =
                    Menu.Tracker.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Có thể giết chết", "SAwarenessKillable"));
                Menu.Killable.MenuItems.Add(
                    Menu.Killable.Menu.AddItem(new MenuItem("SAwarenessKillableActive", "Bật").SetValue(false)));
                Menu.Tracker.MenuItems.Add(
                    Menu.Tracker.Menu.AddItem(new MenuItem("SAwarenessTrackerActive", "Bật").SetValue(false)));
          
                //Not crashing
                Menu.Detector.Menu = menu.AddSubMenu(new LeagueSharp.Common.Menu("Thăm dò", "SAwarenessDetector"));
                Menu.VisionDetector.Menu =
                    Menu.Detector.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Thăm dò",
                        "SAwarenessVisionDetector"));
                Menu.VisionDetector.MenuItems.Add(
                    Menu.VisionDetector.Menu.AddItem(
                        new MenuItem("SAwarenessVisionDetectorDrawRange", "Vòng thăm dò").SetValue(false)));
                Menu.VisionDetector.MenuItems.Add(
                    Menu.VisionDetector.Menu.AddItem(
                        new MenuItem("SAwarenessVisionDetectorActive", "Bật").SetValue(false)));
                Menu.RecallDetector.Menu =
                    Menu.Detector.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Lưu lại điểm xuất hiện",
                        "SAwarenessRecallDetector"));
                Menu.RecallDetector.MenuItems.Add(
                    Menu.RecallDetector.Menu.AddItem(
                        new MenuItem("SAwarenessRecallDetectorPingTimes", "Số lần ping").SetValue(new Slider(0, 5, 0))));
                Menu.RecallDetector.MenuItems.Add(
                    Menu.RecallDetector.Menu.AddItem(
                        new MenuItem("SAwarenessRecallDetectorLocalPing", "Ping chỉ mình thấy").SetValue(true)));
                Menu.RecallDetector.MenuItems.Add(
                    Menu.RecallDetector.Menu.AddItem(
                        new MenuItem("SAwarenessRecallDetectorChatChoice", "Kiểu trò chuyện").SetValue(
                            new StringList(new[] {"Không", "Địa phương", "Bình thường" }))));
                Menu.RecallDetector.MenuItems.Add(
                    Menu.RecallDetector.Menu.AddItem(
                        new MenuItem("SAwarenessRecallDetectorMode", "Kiểu").SetValue(
                            new StringList(new[] {"Cửa sổ Chat", "CD Tracker |", "Tất cả" }))));
                Menu.RecallDetector.MenuItems.Add(
                    Menu.RecallDetector.Menu.AddItem(
                        new MenuItem("SAwarenessRecallDetectorActive", "Bật").SetValue(false)));
                Menu.Detector.MenuItems.Add(
                    Menu.Detector.Menu.AddItem(new MenuItem("SAwarenessDetectorActive", "Bật").SetValue(false)));
                
                //Not crashing
                Menu.Ganks.Menu = menu.AddSubMenu(new LeagueSharp.Common.Menu("Ganks", "SAwarenessGanks"));
                Menu.GankTracker.Menu =
                    Menu.Ganks.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Theo dõi Gank", "SAwarenessGankTracker"));
                Menu.GankTracker.MenuItems.Add(
                    Menu.GankTracker.Menu.AddItem(
                        new MenuItem("SAwarenessGankTrackerTrackRange", "Phạm vi theo dõi").SetValue(new Slider(1, 20000, 1))));
                Menu.GankTracker.MenuItems.Add(
                   Menu.GankTracker.Menu.AddItem(new MenuItem("SAwarenessGankTrackerKillable", "Có thể giết chết").SetValue(false)));
                Menu.GankTracker.MenuItems.Add(
                   Menu.GankTracker.Menu.AddItem(new MenuItem("SAwarenessGankTrackerDraw", "Vẽ đường đi").SetValue(false)));
                Menu.GankTracker.MenuItems.Add(
                   Menu.GankTracker.Menu.AddItem(new MenuItem("SAwarenessGankTrackerPing", "Ping khi máu yếu").SetValue(false)));
                Menu.GankTracker.MenuItems.Add(
                    Menu.GankTracker.Menu.AddItem(new MenuItem("SAwarenessGankTrackerActive", "Bật").SetValue(false)));
                Menu.GankDetector.Menu =
                    Menu.Ganks.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Thăm dò Ganks", "SAwarenessGankDetector"));
                Menu.GankDetector.MenuItems.Add(
                    Menu.GankDetector.Menu.AddItem(
                        new MenuItem("SAwarenessGankDetectorPingTimes", "Số lần Ping").SetValue(new Slider(0, 5, 0))));
                Menu.GankDetector.MenuItems.Add(
                    Menu.GankDetector.Menu.AddItem(
                        new MenuItem("SAwarenessGankDetectorPingType", "Kiểu Ping").SetValue(
                        new StringList(new[] { "Bình thường", "Nguy hiểm", "Rời Lane", "Trên đường tới", "Rút lui", "Hỗ trợ"}))));
                Menu.GankDetector.MenuItems.Add(
                    Menu.GankDetector.Menu.AddItem(
                        new MenuItem("SAwarenessGankDetectorLocalPing", "Ping chỉ mình thấy").SetValue(true)));
                Menu.GankDetector.MenuItems.Add(
                    Menu.GankDetector.Menu.AddItem(
                        new MenuItem("SAwarenessGankDetectorChatChoice", "Kiểu trò chuyện").SetValue(
                            new StringList(new[] {"Không", "Địa phương", "Bình thường" }))));
                Menu.GankDetector.MenuItems.Add(
                    Menu.GankDetector.Menu.AddItem(
                        new MenuItem("SAwarenessGankDetectorTrackRange", "Phạm vi theo dõi").SetValue(new Slider(1, 10000, 1))));
                Menu.GankDetector.MenuItems.Add(
                    Menu.GankDetector.Menu.AddItem(
                        new MenuItem("SAwarenessGankDetectorTrackRangeMax", "Phạm vi tối đa theo dõi").SetValue(new Slider(1, 10000, 1))));
                Menu.GankDetector.MenuItems.Add(
                    Menu.GankDetector.Menu.AddItem(
                        new MenuItem("SAwarenessGankDetectorDisableTime", "Thời gian khống chế").SetValue(new Slider(20, 180, 1))));
                Menu.GankDetector.MenuItems.Add(
                    Menu.GankDetector.Menu.AddItem(new MenuItem("SAwarenessGankDetectorShowJungler", "Show Jungler").SetValue(false)));
                Menu.GankDetector.MenuItems.Add(
                    Menu.GankDetector.Menu.AddItem(new MenuItem("SAwarenessGankDetectorActive", "Bật").SetValue(false)));
                Menu.Ganks.MenuItems.Add(
                    Menu.Ganks.Menu.AddItem(new MenuItem("SAwarenessGanksActive", "Bật").SetValue(false)));
            
                //Not crashing
                Menu.Health.Menu =
                    menu.AddSubMenu(new LeagueSharp.Common.Menu("Trụ -Nhà lính", "SAwarenessObjectHealth"));
                Menu.TowerHealth.Menu =
                    Menu.Health.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Máu Trụ và nhà lính", "SAwarenessTowerHealth"));
                Menu.TowerHealth.MenuItems.Add(
                    Menu.TowerHealth.Menu.AddItem(new MenuItem("SAwarenessTowerHealthActive", "Bật").SetValue(false)));
                Menu.InhibitorHealth.Menu =
                    Menu.Health.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Thời gian sống",
                        "SAwarenessInhibitorHealth"));
                Menu.InhibitorHealth.MenuItems.Add(
                    Menu.InhibitorHealth.Menu.AddItem(
                        new MenuItem("SAwarenessInhibitorHealthActive", "Bật").SetValue(false)));
                Menu.Health.MenuItems.Add(
                    Menu.Health.Menu.AddItem(
                        new MenuItem("SAwarenessHealthMode", "Kiểu").SetValue(new StringList(new[] { "Phần trăm", "Bình thường" }))));
                Menu.Health.MenuItems.Add(
                    Menu.Health.Menu.AddItem(new MenuItem("SAwarenessHealthActive", "Bật").SetValue(false)));
                
                //Not crashing
                Menu.Wards.Menu = menu.AddSubMenu(new LeagueSharp.Common.Menu("Vị trí Mắt", "SAwarenessWards"));
                Menu.WardCorrector.Menu =
                    Menu.Wards.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Chỉnh vị trí mắt", "SAwarenessWardCorrector"));
                Menu.WardCorrector.MenuItems.Add(
                    Menu.WardCorrector.Menu.AddItem(
                        new MenuItem("SAwarenessWardCorrectorKey", "Phím").SetValue(new KeyBind(52, KeyBindType.Press))));
                Menu.WardCorrector.MenuItems.Add(
                    Menu.WardCorrector.Menu.AddItem(
                        new MenuItem("SAwarenessWardCorrectorActive", "Bật").SetValue(false)));
                Menu.BushRevealer.Menu =
                    Menu.Wards.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Bụi cỏ", "SAwarenessBushRevealer"));
                Menu.BushRevealer.MenuItems.Add(
                    Menu.BushRevealer.Menu.AddItem(
                        new MenuItem("SAwarenessBushRevealerKey", "Phím").SetValue(new KeyBind(32, KeyBindType.Press))));
                Menu.BushRevealer.MenuItems.Add(
                    Menu.BushRevealer.Menu.AddItem(new MenuItem("SAwarenessBushRevealerActive", "Bật").SetValue(false)));
                Menu.BushRevealer.MenuItems.Add(
                    Menu.BushRevealer.Menu.AddItem(new MenuItem("By Beaving & Blm95", "By Beaving & Blm95")));
                Menu.InvisibleRevealer.Menu =
                    Menu.Wards.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Stealth Detection",
                        "SAwarenessInvisibleRevealer"));
                Menu.InvisibleRevealer.MenuItems.Add(
                    Menu.InvisibleRevealer.Menu.AddItem(
                        new MenuItem("SAwarenessInvisibleRevealerMode", "Kiểu").SetValue(
                            new StringList(new[] { "Dùng tay", "Tự động" }))));
                Menu.InvisibleRevealer.MenuItems.Add(
                    Menu.InvisibleRevealer.Menu.AddItem(
                        new MenuItem("SAwarenessInvisibleRevealerKey", "Phím").SetValue(new KeyBind(32, KeyBindType.Press))));
                Menu.InvisibleRevealer.MenuItems.Add(
                    Menu.InvisibleRevealer.Menu.AddItem(
                        new MenuItem("SAwarenessInvisibleRevealerActive", "Bật").SetValue(false)));
                Menu.Wards.MenuItems.Add(
                    Menu.Wards.Menu.AddItem(new MenuItem("SAwarenessWardsActive", "Bật").SetValue(false)));

                

                //Not crashing
                Menu.Misc.Menu = menu.AddSubMenu(new LeagueSharp.Common.Menu("Linh Tinh", "SAwarenessMisc"));
                Menu.Misc.MenuItems.Add(
                    Menu.Misc.Menu.AddItem(new MenuItem("SAwarenessMiscActive", "Bật").SetValue(false)));
                Menu.SkinChanger.Menu =
                    Menu.Misc.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Thay Skin", "SAwarenessSkinChanger"));
                Menu.SkinChanger.MenuItems.Add(
                    Menu.SkinChanger.Menu.AddItem(
                        new MenuItem("SAwarenessSkinChangerSkinName", "Skin").SetValue(
                            new StringList(SkinChanger.GetSkinList(ObjectManager.Player.ChampionName))).DontSave()));
                Menu.SkinChanger.MenuItems.Add(
                    Menu.SkinChanger.Menu.AddItem(new MenuItem("SAwarenessSkinChangerActive", "Bật").SetValue(false)));
                Menu.SafeMovement.Menu =
                    Menu.Misc.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Di chuyển an toàn", "SAwarenessSafeMovement"));
                Menu.SafeMovement.MenuItems.Add(
                    Menu.SafeMovement.Menu.AddItem(
                        new MenuItem("SAwarenessSafeMovementBlockIntervall", "Khoảng cách").SetValue(new Slider(20,
                            1000, 0))));
                Menu.SafeMovement.MenuItems.Add(
                    Menu.SafeMovement.Menu.AddItem(new MenuItem("SAwarenessSafeMovementActive", "Bật").SetValue(false)));
                Menu.AutoLevler.Menu =
                    Menu.Misc.Menu.AddSubMenu(new LeagueSharp.Common.Menu("+ Chiêu Lên cấp", "SAwarenessAutoLevler"));
                tempSettings = Menu.AutoLevler.AddMenuItemSettings("Ưu tiên",
                    "SAwarenessAutoLevlerPriority");
                tempSettings.MenuItems.Add(
                    tempSettings.Menu.AddItem(
                        new MenuItem("SAwarenessAutoLevlerPrioritySliderQ", "Q").SetValue(new Slider(0, 3, 0))));
                tempSettings.MenuItems.Add(
                    tempSettings.Menu.AddItem(
                        new MenuItem("SAwarenessAutoLevlerPrioritySliderW", "W").SetValue(new Slider(0, 3, 0))));
                tempSettings.MenuItems.Add(
                    tempSettings.Menu.AddItem(
                        new MenuItem("SAwarenessAutoLevlerPrioritySliderE", "E").SetValue(new Slider(0, 3, 0))));
                tempSettings.MenuItems.Add(
                    tempSettings.Menu.AddItem(
                        new MenuItem("SAwarenessAutoLevlerPrioritySliderR", "R").SetValue(new Slider(0, 3, 0))));
                tempSettings.MenuItems.Add(
                    tempSettings.Menu.AddItem(
                        new MenuItem("SAwarenessAutoLevlerPriorityFirstSpells", "Kiểu").SetValue(
                            new StringList(new[] { "Q W E", "Q E W", "W Q E", "W E Q", "E Q W", "E W Q" }))));
                tempSettings.MenuItems.Add(
                    tempSettings.Menu.AddItem(
                        new MenuItem("SAwarenessAutoLevlerPriorityFirstSpellsActive", "KiểuBật").SetValue(false)));
                tempSettings.MenuItems.Add(
                    tempSettings.Menu.AddItem(
                        new MenuItem("SAwarenessAutoLevlerPriorityActive", "Bật").SetValue(false).DontSave()));
                tempSettings = Menu.AutoLevler.AddMenuItemSettings("Thứ tự",
                    "SAwarenessAutoLevlerSequence");
                tempSettings.MenuItems.Add(
                    tempSettings.Menu.AddItem(
                        new MenuItem("SAwarenessAutoLevlerSequenceLoadChoice", "Thiết lập lựa chọn")
                            .SetValue(AutoLevler.GetBuildNames())
                                .DontSave()));
                tempSettings.MenuItems.Add(
                    tempSettings.Menu.AddItem(
                        new MenuItem("SAwarenessAutoLevlerSequenceShowBuild", "Hiện đồ Tướng địch").SetValue(false)
                            .DontSave()));
                tempSettings.MenuItems.Add(
                    tempSettings.Menu.AddItem(
                        new MenuItem("SAwarenessAutoLevlerSequenceNewBuild", "New Build").SetValue(false)
                            .DontSave()));
                tempSettings.MenuItems.Add(
                    tempSettings.Menu.AddItem(
                        new MenuItem("SAwarenessAutoLevlerSequenceDeleteBuild", "Delete Build").SetValue(false)
                            .DontSave()));
                tempSettings.MenuItems.Add(
                    tempSettings.Menu.AddItem(
                        new MenuItem("SAwarenessAutoLevlerSequenceActive", "Bật").SetValue(false).DontSave()));
                Menu.AutoLevler.MenuItems.Add(
                    Menu.AutoLevler.Menu.AddItem(
                        new MenuItem("SAwarenessAutoLevlerSMode", "Kiểu").SetValue(
                            new StringList(new[] { "Tự lên", "Tự động", "Chỉ  R" }))));
                Menu.AutoLevler.MenuItems.Add(
                    Menu.AutoLevler.Menu.AddItem(new MenuItem("SAwarenessAutoLevlerActive", "Bật").SetValue(false)));
                Menu.MoveToMouse.Menu =
                    Menu.Misc.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Di chuyển theo chuột", "SAwarenessMoveToMouse"));
                Menu.MoveToMouse.MenuItems.Add(
                    Menu.MoveToMouse.Menu.AddItem(
                        new MenuItem("SAwarenessMoveToMouseKey", "Phím").SetValue(new KeyBind(90, KeyBindType.Press))));
                Menu.MoveToMouse.MenuItems.Add(
                    Menu.MoveToMouse.Menu.AddItem(new MenuItem("SAwarenessMoveToMouseActive", "Bật").SetValue(false)));
                Menu.SurrenderVote.Menu =
                    Menu.Misc.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Phím", "SAwarenessSurrenderVote"));
                Menu.SurrenderVote.MenuItems.Add(
                    Menu.SurrenderVote.Menu.AddItem(
                        new MenuItem("SAwarenessSurrenderVoteChatChoice", "Kiểu trò chuyện").SetValue(
                            new StringList(new[] {"Không", "Địa phương", "Bình thường" }))));
                Menu.SurrenderVote.MenuItems.Add(
                    Menu.SurrenderVote.Menu.AddItem(
                        new MenuItem("SAwarenessSurrenderVoteActive", "Bật").SetValue(false)));
                Menu.AutoLatern.Menu =
                    Menu.Misc.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Tự nhấp lồng đèn", "SAwarenessAutoLatern"));
                Menu.AutoLatern.MenuItems.Add(
                    Menu.AutoLatern.Menu.AddItem(
                        new MenuItem("SAwarenessAutoLaternKey", "Phím").SetValue(new KeyBind(84, KeyBindType.Press))));
                Menu.AutoLatern.MenuItems.Add(
                    Menu.AutoLatern.Menu.AddItem(new MenuItem("SAwarenessAutoLaternActive", "Bật").SetValue(false)));
                Menu.AutoJump.Menu =
                    Menu.Misc.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Cắm mắt nhảy", "SAwarenessAutoJump"));
                Menu.AutoJump.MenuItems.Add(
                    Menu.AutoJump.Menu.AddItem(
                        new MenuItem("SAwarenessAutoJumpKey", "Phím").SetValue(new KeyBind(85, KeyBindType.Press))));
                Menu.AutoJump.MenuItems.Add(
                    Menu.AutoJump.Menu.AddItem(new MenuItem("SAwarenessAutoJumpActive", "Bật").SetValue(false)));
                Menu.DisconnectDetector.Menu =
                    Menu.Misc.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Tắt thăm dò",
                        "SAwarenessDisconnectDetector"));
                Menu.DisconnectDetector.MenuItems.Add(
                    Menu.DisconnectDetector.Menu.AddItem(
                        new MenuItem("SAwarenessDisconnectDetectorChatChoice", "Kiểu trò chuyện").SetValue(
                            new StringList(new[] {"Không", "Địa phương", "Bình thường" }))));
                Menu.DisconnectDetector.MenuItems.Add(
                    Menu.DisconnectDetector.Menu.AddItem(
                        new MenuItem("SAwarenessDisconnectDetectorActive", "Bật").SetValue(false)));
                Menu.TurnAround.Menu =
                    Menu.Misc.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Tránh Turn ,Cass,tryn, Saco", "SAwarenessTurnAround"));
                Menu.TurnAround.MenuItems.Add(
                    Menu.TurnAround.Menu.AddItem(new MenuItem("SAwarenessTurnAroundActive", "Bật").SetValue(false)));
                Menu.MinionBars.Menu =
                    Menu.Misc.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Thanh máu lính", "SAwarenessMinionBars"));
                Menu.MinionBars.MenuItems.Add(
                    Menu.MinionBars.Menu.AddItem(new MenuItem("SAwarenessMinionBarsGlowActive", "Hướng dẫn tốt").SetValue(false)));
                Menu.MinionBars.MenuItems.Add(
                    Menu.MinionBars.Menu.AddItem(new MenuItem("SAwarenessMinionBarsActive", "Bật").SetValue(false)));
                //Menu.MinionLocation.Menu =
                //    Menu.Misc.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Minion Location", "SAwarenessMinionLocation"));
                //Menu.MinionLocation.MenuItems.Add(
                //    Menu.MinionLocation.Menu.AddItem(new MenuItem("SAwarenessMinionLocationActive", "Active").SetValue(false)));
                Menu.FlashJuke.Menu =
                    Menu.Misc.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Flash lừa địch", "SAwarenessFlashJuke"));
                Menu.FlashJuke.MenuItems.Add(
                    Menu.FlashJuke.Menu.AddItem(new MenuItem("SAwarenessFlashJukeKeyActive", "Phím").SetValue(new KeyBind(90, KeyBindType.Press))));
                Menu.FlashJuke.MenuItems.Add(
                    Menu.FlashJuke.Menu.AddItem(new MenuItem("SAwarenessFlashJukeRecall", "Biến về").SetValue(false)));
                Menu.FlashJuke.MenuItems.Add(
                    Menu.FlashJuke.Menu.AddItem(new MenuItem("SAwarenessFlashJukeActive", "Bật").SetValue(false)));
                Menu.EasyRangedJungle.Menu =
                    Menu.Misc.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Hiện Jungle", "SAwarenessEasyRangedJungle"));
                Menu.EasyRangedJungle.MenuItems.Add(
                    Menu.EasyRangedJungle.Menu.AddItem(new MenuItem("SAwarenessEasyRangedJungleActive", "Bật").SetValue(false)));
                Menu.FowWardPlacement.Menu =
                    Menu.Misc.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Đề nghị cắm mắt", "SAwarenessFowWardPlacement"));
                Menu.FowWardPlacement.MenuItems.Add(
                    Menu.FowWardPlacement.Menu.AddItem(new MenuItem("SAwarenessFowWardPlacementActive", "Bật").SetValue(false)));
                Menu.RealTime.Menu =
                    Menu.Misc.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Real Time", "SAwarenessRealTime"));
                Menu.RealTime.MenuItems.Add(
                    Menu.RealTime.Menu.AddItem(new MenuItem("SAwarenessRealTimeActive", "Bật").SetValue(false)));
                Menu.ShowPing.Menu =
                    Menu.Misc.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Ping hiển thị", "SAwarenessShowPing"));
                Menu.ShowPing.MenuItems.Add(
                    Menu.ShowPing.Menu.AddItem(new MenuItem("SAwarenessShowPingActive", "Bật").SetValue(false)));
                Menu.PingerName.Menu =
                    Menu.Misc.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Tên người ping", "SAwarenessPingerName"));
                Menu.PingerName.MenuItems.Add(
                    Menu.PingerName.Menu.AddItem(new MenuItem("SAwarenessPingerNameActive", "Bật").SetValue(false)));
                Menu.AntiVisualScreenStealth.Menu =
                    Menu.Misc.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Phát hiện tàn hình", "SAwarenessAntiVisualScreenStealth"));
                Menu.AntiVisualScreenStealth.MenuItems.Add(
                    Menu.AntiVisualScreenStealth.Menu.AddItem(new MenuItem("SAwarenessAntiVisualScreenStealthActive", "Bật").SetValue(false)));
                //Menu.EloDisplayer.Menu =
                //    Menu.Misc.Menu.AddSubMenu(new LeagueSharp.Common.Menu("Elo Displayer", "SAwarenessEloDisplayer"));
                //Menu.EloDisplayer.MenuItems.Add(
                //    Menu.EloDisplayer.Menu.AddItem(new MenuItem("SAwarenessEloDisplayerActive", "Active").SetValue(false)));
                
                Menu.GlobalSettings.Menu =
                    menu.AddSubMenu(new LeagueSharp.Common.Menu("Cài đặt chung", "SAwarenessGlobalSettings"));
                Menu.GlobalSettings.MenuItems.Add(
                    Menu.GlobalSettings.Menu.AddItem(
                        new MenuItem("SAwarenessGlobalSettingsServerChatPingActive", "Trò chuyện bình thường / Ping Bình thường").SetValue(false)));
                
                menu.AddItem(new MenuItem("By Screeder", "Tác giả Screeder"));
				menu.AddItem(new MenuItem("By chaoshen", "Tác giả HuyNK"));
                menu.AddItem(new MenuItem("By chaoshen1", "Version 4.21"));
                menu.AddItem(new MenuItem("By chaoshen", "Donate : khachuyvk@gmail.com"));
                menu.AddToMainMenu();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async static void Game_OnGameLoad(EventArgs args)
        {
            //try
            //{
                CreateMenu();
                Game.PrintChat("SAwareness loaded!");
             

                //TODO: IMPROTANT ChampInfos bugged Need to rework that class this working perfect
              

                new Thread(GameOnOnGameUpdate).Start();
                AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
                AppDomain.CurrentDomain.DomainUnload += delegate { threadActive = false; };
                AppDomain.CurrentDomain.ProcessExit += delegate { threadActive = false; };
                await UimTracker.Init();
                await UiTracker.Init();    


        }

        private static bool threadActive = true;

        private static void GameOnOnGameUpdate(/*EventArgs args*/)
        {
            try
            {
                while (threadActive)
                {
                    Thread.Sleep(1);
                    Type classType = typeof(Menu);
                    BindingFlags flags = BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly;
                    FieldInfo[] fields = classType.GetFields(flags);
                    foreach (FieldInfo p in fields.ToList())
                    {
                        var item = (Menu.MenuItemSettings)p.GetValue(null);
                        if (item.GetActive() == false && item.Item != null)
                        {
                            //item.Item = null;
                        }
                        else if (item.GetActive() && item.Item == null && !item.ForceDisable && item.Type != null)
                        {
                            try
                            {
                                item.Item = System.Activator.CreateInstance(item.Type);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                                throw;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("SAwareness: " + e);
                throw;
            }
            
            //CreateDebugInfos();
        }

        public static PropertyInfo[] GetPublicProperties(Type type)
        {
            if (type.IsInterface)
            {
                var propertyInfos = new List<PropertyInfo>();

                var considered = new List<Type>();
                var queue = new Queue<Type>();
                considered.Add(type);
                queue.Enqueue(type);
                while (queue.Count > 0)
                {
                    Type subType = queue.Dequeue();
                    foreach (Type subInterface in subType.GetInterfaces())
                    {
                        if (considered.Contains(subInterface)) continue;

                        considered.Add(subInterface);
                        queue.Enqueue(subInterface);
                    }

                    PropertyInfo[] typeProperties = subType.GetProperties(
                        BindingFlags.FlattenHierarchy
                        | BindingFlags.Public
                        | BindingFlags.Instance);

                    IEnumerable<PropertyInfo> newPropertyInfos = typeProperties
                        .Where(x => !propertyInfos.Contains(x));

                    propertyInfos.InsertRange(0, newPropertyInfos);
                }

                return propertyInfos.ToArray();
            }

            return type.GetProperties(BindingFlags.Static | BindingFlags.Public);
        }

        private static Assembly evadeAssembly;

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (evadeAssembly == null)
                evadeAssembly = Load();
            return evadeAssembly;
        }

        public static Assembly Load()
        {
            byte[] ba = null;
            string resource = "SAwareness.Resources.DLL.Evade.dll";
            Assembly curAsm = Assembly.GetExecutingAssembly();
            using (Stream stm = curAsm.GetManifestResourceStream(resource))
            {
                ba = new byte[(int) stm.Length];
                stm.Read(ba, 0, (int) stm.Length);
                return Assembly.Load(ba);
            }
        }

        private static void CreateDebugInfos()
        {
            if (lastDebugTime + 60 > Game.ClockTime)
                return;
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter("C:\\SAwarenessDebug.log");
                if(writer == null)
                    return;
                writer.WriteLine("Debug Infos of game: " + Game.Id);
                writer.WriteLine("MapId: " + Game.MapId);
                writer.WriteLine("Mode: " + Game.Mode);
                writer.WriteLine("Region: " + Game.Region);
                writer.WriteLine("Type: " + Game.Type);
                writer.WriteLine("Time: " + Game.ClockTime);

                foreach (var hero in ObjectManager.Get<Obj_AI_Hero>())
                {
                    if (hero.IsMe)
                    {
                        writer.WriteLine("Player: ");
                    }
                    else if (hero.IsAlly)
                    {
                        writer.WriteLine("Ally: ");
                    }
                    else if (hero.IsEnemy)
                    {
                        writer.WriteLine("Enemy: ");
                    }
                    writer.WriteLine("Character: " + hero.ChampionName);
                    writer.Write("Summoners: ");
                    foreach (var spell in hero.Spellbook.Spells)
                    {
                        writer.Write(spell.SData.Name + ", ");
                    }
                    writer.WriteLine("");
                    writer.Write("Items: ");
                    foreach (var item in hero.InventoryItems)
                    {
                        writer.Write(item.Name + ", ");
                    }
                    writer.WriteLine("");
                }
                Type classType = typeof(Menu);
                BindingFlags flags = BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly;
                FieldInfo[] fields = classType.GetFields(flags);
                writer.WriteLine("Activated Options: ");
                foreach (FieldInfo p in fields)
                {
                    var item = (Menu.MenuItemSettings)p.GetValue(null);
                    if (item.GetActive() == false && item.Item != null)
                    {
                        //item.Item = null;
                    }
                    else if (item.GetActive() && !item.ForceDisable)
                    {
                        try
                        {
                            writer.WriteLine("- " + item.Menu.Name);
                            foreach (var menuItem in item.MenuItems)
                            {
                                try{ writer.WriteLine("  - " + menuItem.Name + " | " + menuItem.GetValue<Boolean>()); }
                                catch (Exception e){ if (e is InvalidCastException || e is NullReferenceException) { } }
                                try { writer.WriteLine("  - " + menuItem.Name + " | " + menuItem.GetValue<Slider>().Value); }
                                catch (Exception e) { if (e is InvalidCastException || e is NullReferenceException) { } }
                                try { writer.WriteLine("  - " + menuItem.Name + " | " + menuItem.GetValue<KeyBind>().Active); }
                                catch (Exception e) { if (e is InvalidCastException || e is NullReferenceException) { } }
                                try { writer.WriteLine("  - " + menuItem.Name + " | " + menuItem.GetValue<StringList>().SelectedIndex); }
                                catch (Exception e) { if (e is InvalidCastException || e is NullReferenceException) { } }
                            }
                            //item.Item = System.Activator.CreateInstance(item.Type);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            throw;
                        }
                    }
                }
                lastDebugTime = Game.ClockTime;
            }
            catch (Exception e)
            {
                Console.WriteLine("SAwareness: " + e);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Flush();
                    writer.Close();
                }               
            }            
        }
    }
}

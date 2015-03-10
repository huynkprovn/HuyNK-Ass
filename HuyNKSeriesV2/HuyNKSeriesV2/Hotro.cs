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
    class Hotro
    {
        #region KHAI BAO BIEN
        //ITEM
        public static SpellSlot IgniteSlot = ObjectManager.Player.GetSpellSlot("SummonerDot");
        public static Obj_AI_Hero Player = ObjectManager.Player;
        public static Obj_AI_Hero SelectedTarget = null;
        public static Items.Item Mangxa = new Items.Item(3074,225f);        // Rìu mãng xà  3074
        public static Items.Item Vodanh = new Items.Item(3153,450f);     // Gươm vô danh 3153
        public static Items.Item Tiamax = new Items.Item(3077,225f);        // Tia Max  3077
        public static Items.Item Haitac = new Items.Item(3144,450f);        // Gươm Hải tặc 3144
        public static Items.Item You = new Items.Item(3142,450f);           //Kiếm ma Youmun  3142
        public static Items.Item Khienradun = new Items.Item(3143,490f);     // Khien băng radun 3143
        public static Items.Item Muramana = new Items.Item(3042,500f);       // Thần kiếm muramura 3042
        #endregion

        // Cac hàm dùng Item

        public static void Dung_mangxa(Obj_AI_Hero target)
        {
            if (target != null && Mangxa.IsReady() && Player.Distance(target) < 225f && Items.CanUseItem(Mangxa.Id))
                Items.UseItem(Mangxa.Id, target);
        }
        public static void Dung_vodanh(Obj_AI_Hero target)
        {
            if (target != null && Vodanh.IsReady() && Player.Distance(target) < 450f && Items.CanUseItem(Vodanh.Id))
                Items.UseItem(Vodanh.Id, target);
        }
        public static void Dung_tiamax(Obj_AI_Hero target)
        {
            if (target != null && Tiamax.IsReady()&& Player.Distance(target)< 225f && Items.CanUseItem(Tiamax.Id))
                Items.UseItem(Tiamax.Id, target);
        }
        public static void Dung_haitac(Obj_AI_Hero target)
        {
            if (target != null && Haitac.IsReady()&& Player.Distance(target)< 450f && Items.CanUseItem(Haitac.Id))
                 Items.UseItem(Haitac.Id, target);
        }
        public static void Dung_youmun(Obj_AI_Hero target)
        {
            if (target != null && You.IsReady()&& Player.Distance(target)< 450f && Items.CanUseItem(You.Id))
                Items.UseItem(You.Id, target);
        }
        public static void Dung_radun(Obj_AI_Hero target)
        {
            if (target != null && Khienradun.IsReady()&& Player.Distance(target)< 490f && Items.CanUseItem(Khienradun.Id)) 
                Items.UseItem(Khienradun.Id, target);
        }
        public static void Dung_muramana(Obj_AI_Hero target)
        {
            if (target != null && Muramana.IsReady() && Player.Distance(target)< 525f && Items.CanUseItem(Muramana.Id)) 
                Items.UseItem(Muramana.Id, target);
        }
        public static void Use_Ignite(Obj_AI_Hero target)
        {
            if (target != null && IgniteSlot != SpellSlot.Unknown &&Player.Spellbook.CanUseSpell(IgniteSlot) == SpellState.Ready && Player.Distance(target) < 650)
                    
                Player.Spellbook.CastSpell(IgniteSlot, target);
        }

        public static bool Ignite_Ready()
        {
            if (IgniteSlot != SpellSlot.Unknown && Player.Spellbook.CanUseSpell(IgniteSlot) == SpellState.Ready)
                return true;
            return false;
        }

#region CAC HAM TIEN ICH
        //Dung chiu dinh huong 
        public static void Dungchiu_Dinhhuong(Spell spell, float range, TargetSelector.DamageType type, HitChance hitChance)
        {
            var target = TargetSelector.GetTarget(range, type);

            if (target == null || !spell.IsReady())
                return;
            spell.UpdateSourcePosition();

            if (spell.GetPrediction(target).Hitchance >= hitChance)
                spell.Cast(target, true,true);
        }

        public static int Dem_Dichogan(Vector3 pos, float range)
        {
            return
                ObjectManager.Get<Obj_AI_Hero>().Count(
                    hero => hero.IsEnemy && !hero.IsDead && hero.IsValid && hero.Distance(pos) <= range);
        }

        public static int Dem_Dongdoi(Vector3 pos, float range)
        {
            return
                ObjectManager.Get<Obj_AI_Hero>().Count(
                    hero => hero.IsAlly && !hero.IsDead && hero.IsValid && hero.Distance(pos) <= range);
        }
#endregion
    }
}

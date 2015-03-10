using System;
using System.Collections.Generic;
using System.Linq;
using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;
using Color = System.Drawing.Color;

namespace HuyNKSeriesV2.ListTuong
{

    internal class Olaf : Tuong
    {
        public Olaf()
        {

            SetSpells();
            LoadMenu();
        }

        // Tien hanh setting cho Chiu thuc 
        private void SetSpells()
        {
            List<Spell> SpellList = new List<Spell>();

            Q = new Spell(SpellSlot.Q, 1000);
            Q2 = new Spell(SpellSlot.Q, 550);
            W = new Spell(SpellSlot.W);
            E = new Spell(SpellSlot.E, 325);

            Q.SetSkillshot(0.25f, 75f, 1500f, false, SkillshotType.SkillshotLine);
            Q2.SetSkillshot(0.25f, 75f, 1600f, false, SkillshotType.SkillshotLine);
            SpellList.Add(Q);
            SpellList.Add(Q2);
            SpellList.Add(W);
            SpellList.Add(E);
        }

        // Menu se hien trong game kem voi cai dat
        private void LoadMenu()
        {
            //Chỉnh key
            var key = new Menu("Cài đặt phím ->", "Key");
            key.AddItem(new MenuItem("CombatActive", "Đánh nhau").SetValue(new KeyBind(32, KeyBindType.Press)));      
            key.AddItem(new MenuItem("RiamauActive", "Rỉa máu").SetValue(new KeyBind("V".ToCharArray()[0], KeyBindType.Press)));    
            Caidat.menu.AddSubMenu(key);
            //-------
            //Combo
            var combo = new Menu("Combat ->", "Combo");

            combo.AddItem(new MenuItem("DungQCombo", "Dùng Q").SetValue(true));
            combo.AddItem(new MenuItem("DungWCombo", "Dùng W").SetValue(true));
            combo.AddItem(new MenuItem("DungECombo", "Dùng E").SetValue(true));
            combo.AddItem(new MenuItem("DungRCombo", "Dùng R").SetValue(false));
            Caidat.menu.AddSubMenu(combo);
            // Ria Mau
            var harass = new Menu("Rỉa máu ->", "Harass");
            harass.AddItem(new MenuItem("DungQHarass", "Dùng Q rỉa dài").SetValue(true));
            harass.AddItem(new MenuItem("DungQ2Harass", "Dùng Q ngắn").SetValue(true));
            harass.AddItem(new MenuItem("DungEHarass", "Dùng E rỉa").SetValue(true));
            harass.AddItem(new MenuItem("Qlmana", "Rỉa khi mana còn %").SetValue(new Slider(30, 100, 0)));
            Caidat.menu.AddSubMenu(harass);
            var miscMenu = new Menu("KS :))->", "Misc");
            // Mục linh tinh 
            miscMenu.AddItem(
                new MenuItem("KSbangQ", "KS Bằng Q").SetValue(new KeyBind("O".ToCharArray()[0],
                    KeyBindType.Toggle)));
            Caidat.menu.AddSubMenu(miscMenu);
            var drawMenu = new Menu("Hiện Tầm Đánh", "Drawing");
            drawMenu.AddItem(new MenuItem("Draw_Disabled", "Tắt tất cả").SetValue(false));
            drawMenu.AddItem(new MenuItem("Draw_Q", "Vòng Q").SetValue(true));
            drawMenu.AddItem(new MenuItem("Draw_W", "Vòng W").SetValue(true));
            drawMenu.AddItem(new MenuItem("Draw_E", "Vòng E").SetValue(true));
            drawMenu.AddItem(new MenuItem("Draw_R", "Vòng R").SetValue(true));
            drawMenu.AddItem(new MenuItem("Draw_Q_Killable", "Đánh dấu khi Q chết").SetValue(true));

            MenuItem drawComboDamageMenu =
                new MenuItem("Draw_ComboDamage", "Tính Damage ").SetValue(true);
            drawMenu.AddItem(drawComboDamageMenu);
            Utility.HpBarDamageIndicator.DamageToUnit = GetComboDamage;
            Utility.HpBarDamageIndicator.Enabled = drawComboDamageMenu.GetValue<bool>();
            drawComboDamageMenu.ValueChanged +=
                delegate(object sender, OnValueChangeEventArgs eventArgs)
                {
                    Utility.HpBarDamageIndicator.Enabled = eventArgs.GetNewValue<bool>();
                };

            Caidat.menu.AddSubMenu(drawMenu);
        }

        // Hàm tính damage
        private float GetComboDamage(Obj_AI_Base target)
        {
            double comboDamage = 0;

            if (Q.IsReady())
                comboDamage += Player.GetSpellDamage(target, SpellSlot.Q);

            if (W.IsReady())
                comboDamage += Player.GetSpellDamage(target, SpellSlot.W);

            if (E.IsReady())
                comboDamage += Player.GetSpellDamage(target, SpellSlot.E);

            if (R.IsReady())
                comboDamage += Player.GetSpellDamage(target, SpellSlot.R);

            if (Items.CanUseItem(Hotro.Mangxa.Id))
                comboDamage += Player.GetItemDamage(target, Damage.DamageItems.Hydra); // 

            if (Items.CanUseItem(Hotro.Tiamax.Id))
                comboDamage += Player.GetItemDamage(target, Damage.DamageItems.Tiamat);

            if (Items.CanUseItem(Hotro.Haitac.Id))
                comboDamage += Player.GetItemDamage(target, Damage.DamageItems.Bilgewater);

            if (Items.CanUseItem(Hotro.Vodanh.Id))
                comboDamage += Player.GetItemDamage(target, Damage.DamageItems.Botrk);
                

            if (Hotro.IgniteSlot != SpellSlot.Unknown && Player.Spellbook.CanUseSpell(Hotro.IgniteSlot) == SpellState.Ready)
                
                comboDamage += Player.GetSummonerSpellDamage(target, Damage.SummonerSpell.Ignite);

            return (float) (comboDamage + Player.GetAutoAttackDamage(target)*1);
        }

        private void Harass()
        {

            Obj_AI_Hero target = TargetSelector.GetTarget(Q.Range, TargetSelector.DamageType.Physical);
            if (target.IsValidTarget() && Q.IsReady() && Tienich.kich_hoat("DungQHarass") && Player.Mana / Player.MaxMana * 100 > Tienich.gia_tri("Qlmana") && Player.Distance(target.ServerPosition) <= Q.Range)
            {
                PredictionOutput Qpredict = Q.GetPrediction(target);
                Vector3 hithere = Qpredict.CastPosition.Extend(ObjectManager.Player.Position, -140);
                if (Qpredict.Hitchance >= HitChance.High)

                    Q.Cast(hithere);
            }
            if (target.IsValidTarget() && Q.IsReady() && Tienich.kich_hoat("DungQ2Harass") && Player.Mana / Player.MaxMana * 100 > Tienich.gia_tri("Qlmana") && Player.Distance(target.ServerPosition) <= Q2.Range)
            {
                PredictionOutput Q2predict = Q2.GetPrediction(target);
                Vector3 hithere = Q2predict.CastPosition.Extend(ObjectManager.Player.Position, -140);
                if (Q2predict.Hitchance >= HitChance.High)
                Q2.Cast(hithere);
            }
             if (E.IsReady() && Tienich.kich_hoat("DungEHarass") && Player.Distance(target.ServerPosition) <= E.Range) 
                E.CastOnUnit(target);
        }

        private void Combo()
        {

            Obj_AI_Hero target = TargetSelector.GetTarget(Q.Range, TargetSelector.DamageType.Physical);
            Hotro.Dung_youmun(target);
            Hotro.Dung_radun(target);
            Hotro.Dung_tiamax(target);
            Hotro.Dung_vodanh(target);
            Hotro.Dung_haitac(target);
            Hotro.Dung_mangxa(target);


            if (target.IsValidTarget() && Tienich.kich_hoat("DungQCombo") && Q.IsReady() && Player.Distance(target.ServerPosition) <= Q.Range)
                
                
            {
                PredictionOutput Qpredict = Q.GetPrediction(target);
                Vector3 hithere = Qpredict.CastPosition.Extend(ObjectManager.Player.Position, -100);
                if (Player.Distance(target.ServerPosition) >= 350)
                {
                    Q.Cast(hithere);
                }
                else
                    Q.Cast(Qpredict.CastPosition);
            }



            if (target.IsValidTarget() && Tienich.kich_hoat("DungECombo")
                && E.IsReady()
                && Player.Distance(target.ServerPosition) <= E.Range)

                E.CastOnUnit(target);


            if (target.IsValidTarget() && Tienich.kich_hoat("DungWCombo")
                && W.IsReady()
                && Player.Distance(target.ServerPosition) <= 225f)

                W.Cast();
                
                
        }

        // Ham UseSpells dieu khien Ria mau va combo
     
        public override void GameObject_OnCreate(GameObject obj, EventArgs args)
        {
             GameObject _axeObj;
            if (obj.Name == "olaf_axe_totem_team_id_green.troy")
                _axeObj = obj;
        }

        public override void GameObject_OnDelete(GameObject obj, EventArgs args)
        {
            GameObject _axeObj;
            if (obj.Name == "olaf_axe_totem_team_id_green.troy")
                _axeObj = null;
        }
        //
        public override void Game_OnGameUpdate(EventArgs args)
        {
            if (Tienich.kich_hoat("KSbangQ"))
            {
                KsQ();
                
            }
            if (Caidat.menu.Item("CombatActive").GetValue<KeyBind>().Active)
            {
                Combo();
            }

            if (Caidat.menu.Item("RiamauActive").GetValue<KeyBind>().Active)
            {
                Harass();
                
            }
            
        }

        private float Get_Q_Dmg(Obj_AI_Hero target)
        {
            double dmg = 0;

            dmg += Player.GetSpellDamage(target, SpellSlot.Q);

            PredictionOutput Qpred = Q.GetPrediction(target);
            int collisionCount = Qpred.CollisionObjects.Count;

            if (collisionCount >= 7)
                dmg = dmg*.3;
            else if (collisionCount != 0)
                dmg = dmg*((10 - collisionCount)/10);

            //Game.PrintChat("collision: " + collisionCount);
            return (float) dmg;
        }

        private void KsQ()
        {
            foreach (
                Obj_AI_Hero unit in
                    ObjectManager.Get<Obj_AI_Hero>().Where(x => x.IsValidTarget(1500) && !x.IsDead && x.IsEnemy).OrderBy(x => x.Health))
                        
                        


            {
                float health = unit.Health + unit.HPRegenRate*3 + 25;
                if (Get_Q_Dmg(unit) > health)
                {
                    Q.Cast(unit, true, true);
                    return;
                }
            }
        }

        public override void Drawing_OnDraw(EventArgs args)
        {
            if (Tienich.kich_hoat("Draw_Disabled"))
                return;

            if (Tienich.kich_hoat("Draw_Q"))
                if (Q.Level > 0)
                    Utility.DrawCircle(Player.Position, Q.Range, Q.IsReady() ? Color.Green : Color.Red);
            if (Tienich.kich_hoat("Draw_W"))
                if (W.Level > 0)
                    Utility.DrawCircle(Player.Position, W.Range, W.IsReady() ? Color.Green : Color.Red);

            if (Tienich.kich_hoat("Draw_E"))
                if (E.Level > 0)
                    Utility.DrawCircle(Player.Position, E.Range, E.IsReady() ? Color.Green : Color.Red);

            

            if (Tienich.kich_hoat("Draw_Q_Killable") && R.IsReady())
            {
                foreach (
                    Obj_AI_Hero unit in
                        ObjectManager.Get<Obj_AI_Hero>()
                            .Where(x => x.IsValidTarget(1500) && !x.IsDead && x.IsEnemy)
                            .OrderBy(x => x.Health))
                {
                    float health = unit.Health + unit.HPRegenRate*3 + 25;

                    if (Get_Q_Dmg(unit) > health)
                    {
                        Drawing.DrawText(Drawing.Width*0.39f, Drawing.Height*0.80f, Color.DarkOrange,
                            " Cho no 1 riu di  ");
                        Vector2 wts = Drawing.WorldToScreen(unit.Position);
                        Drawing.DrawText(wts[0] - 20, wts[1], Color.Red, "MUC TIEU NE!!!");


                        var text = new Render.Text("Nem 1 riu nua, chet ba no roi :))!", Player, new Vector2(0, 50),
                            40, ColorBGRA.FromRgba(0xFF00FFBB));
                        text.Add();
                        Q.Cast(unit);
                    }
                }
            }
        }
    }
}

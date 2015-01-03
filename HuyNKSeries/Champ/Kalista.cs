﻿using System;
using System.Collections.Generic;
using System.Linq;
using LeagueSharp;
using LeagueSharp.Common;
using Microsoft.Win32.SafeHandles;
using SharpDX;

using Color = System.Drawing.Color;

namespace HuyNKSeries.Champ
{
  internal class Kalista : Champion
    {
        public static Spell Q, W, E, R;
        public static readonly List<Spell> spellList = new List<Spell>();
        
        public Kalista()
        {
            SetSpells();
            LoadMenu();
        }

        private void LoadMenu()
        {
            
           Menu key = new Menu("Đánh nhau", "Key");
           
                key.AddItem(new MenuItem("ComboActive", "Đánh nhau").SetValue(new KeyBind(32, KeyBindType.Press)));
                key.AddItem(new MenuItem("HarassActive", "Rỉa máu").SetValue(new KeyBind("V".ToCharArray()[0], KeyBindType.Press)));
                key.AddItem(new MenuItem("HarassActiveT", "Rỉa máu (Luôn luôn)!").SetValue(new KeyBind("N".ToCharArray()[0], KeyBindType.Toggle)));
                Menus.menu.AddSubMenu(key);
          

            // Combo
            Menu combo = new Menu("Cài đặt chiêu", "combo");
            combo.AddItem(new MenuItem("comboUseQ", "Dùng Q").SetValue(true));
            combo.AddItem(new MenuItem("comboUseE", "Dùng E").SetValue(true));
            combo.AddItem(new MenuItem("comboNumE", "Dùng E nếu đủ ").SetValue(new Slider(5, 1, 20)));
            combo.AddItem(new MenuItem("comboUseItems", "Dùng items").SetValue(true));
            combo.AddItem(new MenuItem("comboUseIgnite", "Thiêu đốt").SetValue(true));
            combo.AddItem(new MenuItem("comboActive", "Phím đánh nhau").SetValue(new KeyBind(32, KeyBindType.Press)));
            Menus.menu.AddSubMenu(combo);

            // Harass
            Menu harass = new Menu("Rỉa máu", "harass");
            harass.AddItem(new MenuItem("harassUseQ", "Dùng Q").SetValue(true));
          //  harass.AddItem(new MenuItem("harassMana", "Quản lý mana dùng Q (%)").SetValue(new Slider(30)));
            harass.AddItem(new MenuItem("harassActive", "Phím rỉa máu").SetValue(new KeyBind('V', KeyBindType.Press)));
            Menus.menu.AddSubMenu(harass);

            // WaveClear
            Menu waveClear = new Menu("Dọn lính", "waveClear");
            waveClear.AddItem(new MenuItem("waveUseQ", "Dùng Q").SetValue(true));
            waveClear.AddItem(new MenuItem("waveNumQ", "Giết bằng Q nếu lính>=").SetValue(new Slider(3, 1, 10)));
            waveClear.AddItem(new MenuItem("waveUseE", "Dùng E").SetValue(true));
            waveClear.AddItem(new MenuItem("waveNumE", "Giêt lính bằng E >=").SetValue(new Slider(2, 1, 10)));
            waveClear.AddItem(new MenuItem("waveBigE", "Luôn E vào lính to").SetValue(true));
          //  waveClear.AddItem(new MenuItem("waveMana", "Quản lý mana dùng (%)").SetValue(new Slider(30)));
            waveClear.AddItem(new MenuItem("waveActive", "Dọn lính").SetValue(new KeyBind('V', KeyBindType.Press)));
            Menus.menu.AddSubMenu(waveClear);

            // JungleClear
            Menu jungleClear = new Menu("Farm Rừng", "jungleClear");
            jungleClear.AddItem(new MenuItem("jungleUseE", "Dùng E và Q").SetValue(true));
            jungleClear.AddItem(new MenuItem("jungleActive", "Farm rừng").SetValue(new KeyBind('V', KeyBindType.Press)));
            Menus.menu.AddSubMenu(jungleClear);

            // Flee
            Menu flee = new Menu("Chạy trốn", "flee");
            flee.AddItem(new MenuItem("fleeWalljump", "Nhảy qua tường").SetValue(true));
            flee.AddItem(new MenuItem("fleeAA", "Vừa chạy vừa đánh").SetValue(true));
            flee.AddItem(new MenuItem("fleeActive", "Nhảy").SetValue(new KeyBind('G', KeyBindType.Press)));
            Menus.menu.AddSubMenu(flee);

            // Misc
            Menu misc = new Menu("Linh Tinh", "misc");
            misc.AddItem(new MenuItem("miscKillstealE", "Giết bằng E").SetValue(true));
            Menus.menu.AddSubMenu(misc);

            // Items
            Menu items = new Menu("Items", "items");
            items.AddItem(new MenuItem("itemsBotrk", "Vô danh").SetValue(true));
            Menus.menu.AddSubMenu(items);

            // Drawings
            Menu drawings = new Menu("Tầm đánh", "drawings");
            drawings.AddItem(new MenuItem("drawRangeQ", "Vòng Q").SetValue(new Circle(true, Color.FromArgb(150, Color.IndianRed))));
            drawings.AddItem(new MenuItem("drawRangeW", "Vòng W").SetValue(new Circle(true, Color.FromArgb(150, Color.MediumPurple))));
            drawings.AddItem(new MenuItem("drawRangeE", "Vòng E").SetValue(new Circle(true, Color.FromArgb(150, Color.DarkRed))));
            drawings.AddItem(new MenuItem("drawRangeR", "Vòng R").SetValue(new Circle(false, Color.FromArgb(150, Color.Red))));
            MenuItem drawComboDamageMenu = new MenuItem("Draw_ComboDamage", "Thanh máu sau khi Combo ").SetValue(true);
            drawings.AddItem(drawComboDamageMenu);
            Utility.HpBarDamageIndicator.DamageToUnit = GetComboDamage;
            Utility.HpBarDamageIndicator.Enabled = drawComboDamageMenu.GetValue<bool>();
            drawComboDamageMenu.ValueChanged +=
                delegate(object sender, OnValueChangeEventArgs eventArgs)
                {
                    Utility.HpBarDamageIndicator.Enabled = eventArgs.GetNewValue<bool>();
                };

            Menus.menu.AddSubMenu(drawings);

            // Finalize menu
           // Menus.menu.AddToMainMenu();
        }

        public static void SetSpells()
        {
            Q = new Spell(SpellSlot.Q, 1150);
            W = new Spell(SpellSlot.W, 5000);
            E = new Spell(SpellSlot.E, 1000);
            R = new Spell(SpellSlot.R, 1500);

            // Add to spell list
            spellList.AddRange(new[] { Q, W, E, R });

            // Finetune spells
            Q.SetSkillshot(0.25f, 40, 1200, true, SkillshotType.SkillshotLine);
        }
        public  override void Game_OnGameUpdate(EventArgs args)
        {
            // Combo
            if (Menus.menu.SubMenu("combo").Item("comboActive").GetValue<KeyBind>().Active)
                Combo();
            // Harass
            if (Menus.menu.SubMenu("harass").Item("harassActive").GetValue<KeyBind>().Active)
                Harass();
            // WaveClear
            if (Menus.menu.SubMenu("waveClear").Item("waveActive").GetValue<KeyBind>().Active)
                WaveClear();
            // JungleClear
            if (Menus.menu.SubMenu("jungleClear").Item("jungleActive").GetValue<KeyBind>().Active)
                JungleClear();
            // Flee
            if (Menus.menu.SubMenu("flee").Item("fleeActive").GetValue<KeyBind>().Active)
                Flee();

            // Check killsteal
            if (E.IsReady() && Menus.menu.SubMenu("misc").Item("miscKillstealE").GetValue<bool>())
            {
                foreach (var enemy in ObjectManager.Get<Obj_AI_Hero>().Where(h => h.IsValidTarget(E.Range)))
                {
                    if (Menus.player.GetSpellDamage(enemy, SpellSlot.E) > enemy.Health)
                    {
                        E.Cast();
                        break;
                    }
                }
            }
        }
        public static float GetComboDamage(Obj_AI_Hero target)
        {
            // Auto attack damage
            double damage = Menus.player.GetAutoAttackDamage(target);

            // Q damage
            if (Q.IsReady())
                damage += Menus.player.GetSpellDamage(target, SpellSlot.Q);

            // E stack damage
            if (E.IsReady())
                damage += Menus.player.GetSpellDamage(target, SpellSlot.E);

            return (float)damage;
        }

        
        public static void Combo()
        {
            bool useQ = Menus.menu.SubMenu("combo").Item("comboUseQ").GetValue<bool>();
            bool useE = Menus.menu.SubMenu("combo").Item("comboUseE").GetValue<bool>();

            Obj_AI_Hero target;

            if (useQ && Q.IsReady())
                target = TargetSelector.GetTarget(Q.Range, TargetSelector.DamageType.Physical);
            else
                target = TargetSelector.GetTarget(Orbwalking.GetRealAutoAttackRange(Menus.player),TargetSelector.DamageType.Physical);

            if (target == null)
                return;

            // Item usage
            if (Menus.menu.SubMenu("combo").Item("comboUseItems").GetValue<bool>())
            {
                if (Menus.menu.SubMenu("items").Item("itemsBotrk").GetValue<bool>())
                {
                    bool foundCutlass = Items.HasItem(3144);
                    bool foundBotrk = Items.HasItem(3153);

                    if (foundCutlass || foundBotrk)
                    {
                        if (foundCutlass || Menus.player.Health + Menus.player.GetItemDamage(target, Damage.DamageItems.Botrk) < Menus.player.MaxHealth)
                            Items.UseItem(foundCutlass ? 3144 : 3153, target);
                    }
                }
            }

            // Spell usage
            if (useQ && Q.IsReady())
                HuyNkItems.CastBasicSkillShot(Q, Q.Range, TargetSelector.DamageType.Physical, HitChance.Medium);
                Q.Cast(target, HuyNkItems.packets());

            if (useE && E.IsReady())
            {
                E.IsKillable(target);
                E.Cast(target);
            
            }
        }
       
        
        public static void Harass()
        {
           

            var target = TargetSelector.GetTarget(Q.Range, TargetSelector.DamageType.Physical);
          

            bool useQ = Menus.menu.SubMenu("harass").Item("harassUseQ").GetValue<bool>();

            if (useQ && Q.IsReady())
                
              // Q.Cast(target, HuyNkItems.packets());
               HuyNkItems.CastBasicSkillShot(Q, Q.Range, TargetSelector.DamageType.Physical, HitChance.Medium);
            
        }
        public static void getAvailableJumpSpots()
        {
            int size = 295;
            int n = 15;
            double x, y;
            Vector3 drawWhere;

            if (!Q.IsReady())
            {
                Drawing.DrawText(Drawing.Width * 0.44f, Drawing.Height * 0.80f, Color.Red,
                " SKILL Q HAVEN'T READY");
            }
            else
            {
                Drawing.DrawText(Drawing.Width * 0.39f, Drawing.Height * 0.80f, Color.DarkOrange,
                    "CLICK TO JUMP");
            }
            Vector3 playerPosition = HuyNkItems.Player.Position;
            Drawing.DrawCircle(ObjectManager.Player.Position, size, Color.RoyalBlue);
            Obj_AI_Hero     qtarget = LeagueSharp.Common.TargetSelector.GetTarget(Q.Range, LeagueSharp.Common.TargetSelector.DamageType.Physical);
            for (int i = 1; i <= n; i++)
            {
                x = size * Math.Cos(2 * Math.PI * i / n);
                y = size * Math.Sin(2 * Math.PI * i / n);
                drawWhere = new Vector3((int)(playerPosition.X + x), (float)(playerPosition.Y + y), playerPosition.Z);
                if (!Utility.IsWall(drawWhere))
                {
                    if (Q.IsReady() && Game.CursorPos.Distance(drawWhere) <= 80f)
                    {
                        if (qtarget != null)
                            Q.Cast(qtarget);
                        else
                            Q.Cast(new Vector2(drawWhere.X, drawWhere.Y), true);

                        Packet.C2S.Move.Encoded(new Packet.C2S.Move.Struct(drawWhere.X, drawWhere.Y)).Send();
                        return;
                    }
                  
                   // Utility.DrawCircle(drawWhere, 20, Color.Red);
                    
                }
            }

        }
        public static void Flee()
        {
            bool useWalljump = Menus.menu.SubMenu("flee").Item("fleeWalljump").GetValue<bool>();
            if (useWalljump)
            {
                getAvailableJumpSpots();
            }
            bool useAA = Menus.menu.SubMenu("flee").Item("fleeAA").GetValue<bool>();

            if (useAA)
            {
                var dashObject = GetDashObject();
                if (dashObject != null)
                    Orbwalking.Orbwalk(dashObject, Game.CursorPos);
                else
                    Orbwalking.Orbwalk(null, Game.CursorPos);
            }
        }
        public static void JungleClear()
        {
            bool useQE = Menus.menu.SubMenu("jungleClear").Item("jungleUseE").GetValue<bool>();

            if (useQE && Q.IsReady())
            {
                var minions = MinionManager.GetMinions(Menus.player.Position, Q.Range, MinionTypes.All, MinionTeam.Neutral);

                // Check if a jungle mob can die with E
                foreach (var minion in minions)
                {
                    if (Menus.player.GetSpellDamage(minion, SpellSlot.Q) > minion.Health)
                    {
                        Q.Cast(true);
                        break;
                    }
                }
            }
            if (useQE && E.IsReady())
            {
                var minions = MinionManager.GetMinions(Menus.player.Position, E.Range, MinionTypes.All, MinionTeam.Neutral);

                // Check if a jungle mob can die with E
                foreach (var minion in minions)
                {
                    if (Menus.player.GetSpellDamage(minion, SpellSlot.E) > minion.Health)
                    {
                        E.Cast(true);
                        break;
                    }
                }
            }
        }
        public static void WaveClear()
        {
            // Mana check
            if ((Menus.player.Mana / Menus.player.MaxMana) * 100 < Menus.menu.SubMenu("waveClear").Item("waveMana").GetValue<Slider>().Value)
                return;

            bool useQ = Menus.menu.SubMenu("waveClear").Item("waveUseQ").GetValue<bool>();
            bool useE = Menus.menu.SubMenu("waveClear").Item("waveUseE").GetValue<bool>();
            bool bigE = Menus.menu.SubMenu("waveClear").Item("waveBigE").GetValue<bool>();

            // Q usage
            if (useQ && Q.IsReady())
            {
                int hitNumber = Menus.menu.SubMenu("waveClear").Item("waveNumQ").GetValue<Slider>().Value;

                // Get minions in range
                var minions = ObjectManager.Get<Obj_AI_Minion>().Where(m => m.BaseSkinName.Contains("Minion") && m.IsValidTarget(Q.Range)).ToList();

                if (minions.Count >= hitNumber)
                {
                    // Sort by distance
                    minions.Sort((m1, m2) => m2.Distance(Menus.player, true).CompareTo(m1.Distance(Menus.player, true)));

                    // Helpers
                    int bestHitCount = 0;
                    PredictionOutput bestResult = null;

                    foreach (var minion in minions)
                    {
                        var prediction = Q.GetPrediction(minion);

                        // Get targets being hit with colliding Q
                        var targets = prediction.CollisionObjects;
                        // Sort them by distance
                        targets.Sort((t1, t2) => t1.Distance(Menus.player, true).CompareTo(t2.Distance(Menus.player, true)));

                        // Validate
                        if (targets.Count > 0)
                        {
                            // Loop through the next targets to see if they will die with the Q hitting
                            for (int i = 0; i < targets.Count; i++)
                            {
                                if (Menus.player.GetSpellDamage(targets[i], SpellSlot.Q) < targets[i].Health || i == targets.Count)
                                {
                                    // Can't kill this minion, check result so far
                                    if (i >= hitNumber && (bestResult == null || bestHitCount < i))
                                    {
                                        bestHitCount = i;
                                        bestResult = prediction;
                                    }

                                    // Break the loop cuz can't kill target
                                    break;
                                }
                            }
                        }
                    }

                    // Check if we have a valid target with enough targets being hit
                    if (bestResult != null)
                        Q.Cast(bestResult.CastPosition);
                }
            }

            // General E usage
            if (useE && E.IsReady())
            {
                int hitNumber = Menus.menu.SubMenu("waveClear").Item("waveNumE").GetValue<Slider>().Value;

                // Get surrounding
                var minions = MinionManager.GetMinions(Menus.player.Position, E.Range);

                if (minions.Count >= hitNumber)
                {
                    // Check if enough minions die with E
                    int conditionMet = 0;
                    foreach (var minion in minions)
                    {
                        if (Menus.player.GetSpellDamage(minion, SpellSlot.E) > minion.Health)
                            conditionMet++;
                    }

                    // Cast on condition met
                    if (conditionMet >= hitNumber)
                        E.Cast(true);
                }
            }

            // Always E on big minions
            if (bigE && E.IsReady())
            {
                // Get big minions
                var minions = MinionManager.GetMinions(Menus.player.Position, E.Range).Where(m => m.BaseSkinName.Contains("MinionSiege"));

                foreach (var minion in minions)
                {
                    if (Menus.player.GetSpellDamage(minion, SpellSlot.E) > minion.Health)
                    {
                        // On first big minion which can die with E, use E
                        E.Cast(true);
                        break;
                    }
                }
            }
        }
        public static Obj_AI_Base GetDashObject()
        {
            float realAArange = Orbwalking.GetRealAutoAttackRange(Menus.player);

            var objects = ObjectManager.Get<Obj_AI_Base>().Where(o => o.IsValidTarget(realAArange));
            Vector2 apexPoint = Menus.player.ServerPosition.To2D() + (Menus.player.ServerPosition.To2D() - Game.CursorPos.To2D()).Normalized() * realAArange;

            Obj_AI_Base target = null;

            foreach (var obj in objects)
            {
                if (VectorHelper.IsLyingInCone(obj.ServerPosition.To2D(), apexPoint, Menus.player.ServerPosition.To2D(), realAArange))
                {
                    if (target == null || target.Distance(apexPoint, true) > obj.Distance(apexPoint, true))
                        target = obj;
                }
            }

            return target;
        }
        public static void Obj_AI_Hero_OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (sender.IsMe)
            {
                if (args.SData.Name == "KalistaExpungeWrapper")
                    Utility.DelayAction.Add(250, Orbwalking.ResetAutoAttackTimer);
            }
        }
        public override void Drawing_OnDraw(EventArgs args)
        {
            // Spell ranges
            foreach (var spell in spellList)
            {
                var circleEntry = Menus.menu.SubMenu("drawings").Item("drawRange" + spell.Slot.ToString()).GetValue<Circle>();
                if (circleEntry.Active)
                    Utility.DrawCircle(Menus.player.Position, spell.Range, circleEntry.Color);
            }
        }


        public static bool useQ { get; set; }
    }
}

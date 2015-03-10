using System;
using System.Collections.Generic;
using System.Linq;
using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;

namespace HuyNKSeriesV2
{
    internal class Tuong
    {
        public Tuong()
        {
            //Events
            Game.OnGameUpdate += Game_OnGameUpdate;
            Drawing.OnDraw += Drawing_OnDraw;
            Interrupter.OnPossibleToInterrupt += Interrupter_OnPosibleToInterrupt;
            AntiGapcloser.OnEnemyGapcloser += AntiGapcloser_OnEnemyGapcloser;
            GameObject.OnCreate += GameObject_OnCreate;
            Obj_AI_Base.OnProcessSpellCast += Obj_AI_Base_OnProcessSpellCast;
            Game.OnGameSendPacket += Game_OnSendPacket;
            GameObject.OnDelete += GameObject_OnDelete;
        }

        public Tuong(bool load)
        {
            if (load)
                GameOnLoad();
            ;
        }

        //Orbwalker 
        public Orbwalking.Orbwalker Orbwalker;

        //Player 
        public Obj_AI_Hero Player = ObjectManager.Player;
        public Obj_AI_Hero SelectedTarget = null;

        //Spells
        public List<Spell> SpellList = new List<Spell>();

        public Spell Q;
        public Spell Q2;

        public Spell W;
        public Spell W2;
        public Spell E;
        public Spell E2;
        public Spell R;
        public Spell _r2;
     



        public void GameOnLoad()
        {


            Caidat.SetuptMenu();


        }

        //to create by champ
        public virtual void Drawing_OnDraw(EventArgs args)
        {
            //for champs to use
        }

        public virtual void AntiGapcloser_OnEnemyGapcloser(ActiveGapcloser gapcloser)
        {
            //for champs to use
        }

        public virtual void Interrupter_OnPosibleToInterrupt(Obj_AI_Base unit, InterruptableSpell spell)
        {
            //for champs to use
        }

        public virtual void Game_OnGameUpdate(EventArgs args)
        {
            //for champs to use
        }

        public virtual void GameObject_OnCreate(GameObject sender, EventArgs args)
        {
            //for champs to use
        }

        public virtual void GameObject_OnDelete(GameObject sender, EventArgs args)
        {
            //for champs to use
        }

        public virtual void Obj_AI_Base_OnProcessSpellCast(Obj_AI_Base unit, GameObjectProcessSpellCastEventArgs args)
        {
            //for champ use
        }

        public virtual void Game_OnSendPacket(GamePacketEventArgs args)
        {
            // Avoid stupic Q casts while jumping in mid air!
            if (args.PacketData[0] == Packet.C2S.Cast.Header && Caidat.player.IsDashing())
            {
                // Don't process the packet if we are jumping!
                if (Packet.C2S.Cast.Decoded(args.PacketData).Slot == SpellSlot.Q)
                    args.Process = false;
            }
        }
    }
}

  

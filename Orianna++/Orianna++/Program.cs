using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;

namespace Orianna__
{
    class Program
    {
        public string[] Tanks;

        public static List<Spell> SpellList;
        public static Spell Q, W, E, R;

        public static Orbwalking.Orbwalker Orbwalker;

        public static bool isBallMoving;
        public static Vector3 currentBallPosition;
        public static int ballStatus;

        public const string ChampionName = "Orianna";

        public static Obj_AI_Hero Player;

        public static Menu Config;

        public static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += Game_OnLoad;
        }

        public static void Game_OnLoad(EventArgs args)
        {
            Player = ObjectManager.Player;

            if (Player.ChampionName != ChampionName)
            {
                return;
            }

            //Initialize spells
            SetupSpells();

            //Setup Menu

            //Subscribe to other events
            Drawing.OnDraw += Drawing_OnDraw;
            GameObject.OnCreate += GameObject_OnCreate;
        }

        private static void SetupSpells()
        {
            /* name source
             * https://github.com/Esk0r/LeagueSharp/blob/master/Evade/SpellDatabase.cs
             */

            SpellList = new List<Spell>();

            Q = new Spell(SpellSlot.Q, 825);
            W = new Spell(SpellSlot.W, 245);
            E = new Spell(SpellSlot.E, 1095);
            R = new Spell(SpellSlot.R, 370);

            Q.SetSkillshot(0.0f, 80, 1200, false, SkillshotType.SkillshotLine);
            W.SetSkillshot(0.25f, 247, float.MaxValue, false, SkillshotType.SkillshotCircle);
            E.SetSkillshot(0.0f, 80, 1700, false, SkillshotType.SkillshotLine);
            R.SetSkillshot(0.7f, 370, float.MaxValue, false, SkillshotType.SkillshotCircle);

            SpellList.Add(Q);
            SpellList.Add(W);
            SpellList.Add(E);
            SpellList.Add(R);
        }

        private static void LoadMenu()
        {
            Config = new Menu("Orianna++", ChampionName, true);
            TargetSelector.AddToMenu(Config.SubMenu("Target Selector"));
            Orbwalker = new Orbwalking.Orbwalker(Config.SubMenu("Orbwalker"));



            //Combo Menu
            var comboMenu = new Menu("Combo", "Combo");
            comboMenu.AddItem(new MenuItem("selected", "Focus Selected Target", true).SetValue(true));
            comboMenu.AddItem(new MenuItem("UseQCombo", "Use Q", true).SetValue(true));
            comboMenu.AddItem(new MenuItem("UseWCombo", "Use W", true).SetValue(true));
            comboMenu.AddItem(new MenuItem("UseECombo", "Use E", true).SetValue(true));
            comboMenu.AddItem(new MenuItem("UseRCombo", "Use R", true).SetValue(true));
            comboMenu.AddItem(new MenuItem("autoRCombo", "Smart R Threshold", true).SetValue(new Slider(20, 1)));
            Config.AddSubMenu(comboMenu);
        }

        public static void Drawing_OnDraw(EventArgs args)
        {

        }

        public static void GameObject_OnCreate(GameObject sender, EventArgs args)
        {

        }

    }

    
}

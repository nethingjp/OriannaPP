using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Common;

namespace Orianna__
{
    class Program
    {

        public const string ChampionName = "Orianna";

        public static void main(string[] args)
        {
            //Events
            CustomEvents.Game.OnGameLoad += Game_OnLoad;
            Drawing.OnDraw += Drawing_OnDraw;
            GameObject.OnCreate += GameObject_OnCreate;
        }

        static void Game_OnLoad(EventArgs args)
        {
            //Initialize spells

        }

        static void Drawing_OnDraw(EventArgs args)
        {

        }

        static void GameObject_OnCreate(GameObject sender, EventArgs args)
        {

        }

    }

    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ensage;
using Ensage.Common;
using SharpDX;
using Ensage.Common.Extensions;

namespace prediction
{
    class Program
    {
        static void Main(string[] args)
        {
            Drawing.OnDraw += Drawing_OnDraw;

        }
        static void Drawing_OnDraw(EventArgs args)
        {
            var mereka = ObjectMgr.GetEntities<Hero>().Where(x => x.Team != ObjectMgr.LocalHero.Team).ToList();
            foreach (var dia in mereka)
            {
                if (!dia.IsIllusion && !dia.IsVisible)
                {
                    posisiterakhir(dia);
                }
            }
        }

        static void posisiterakhir(Hero dia)
        {
            try
            {
                if (dia.IsAlive)
                {
                    var Angle = dia.FindAngleR();
                    Vector2 garis = Drawing.WorldToScreen(dia.Position); //Facing position line
                    garis.X += (float)Math.Cos(Angle) * 500;
                    garis.Y += (float)Math.Sin(Angle) * 500;
                    if (Drawing.WorldToScreen(dia.Position).Y > 15)
                    {
                        Drawing.DrawLine(Drawing.WorldToScreen(dia.Position), garis, Color.Red);
                        Drawing.DrawText(string.Format("{0} {1}", dia.Name.Replace("npc_dota_hero_",""), (int)Game.GameTime), Drawing.WorldToScreen(dia.Position), Color.Cyan, FontFlags.AntiAlias | FontFlags.Outline);
                    }
                } 
            }
            catch (Exception ex)
            { }
        }

        }

    }


}

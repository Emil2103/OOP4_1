using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP4_1
{
    public class CCircle
    {
        public int x = 0;
        public int y = 0;
        public static int radius = 20;
        public bool popal = false;
        Pen blackPen;
        Pen redPen;

        public CCircle(int x, int y)
        {
            blackPen = new Pen(Color.Black);
            blackPen.Width = 2;
            redPen = new Pen(Color.Red);
            redPen.Width = 2;
            this.x = x;
            this.y = y;
        }

        public bool Popal(int x, int y)
        {
            if (Math.Pow(this.x - x, 2) + Math.Pow(this.y - y, 2) <= radius * radius)
                return true;
            else
                return false;
              
        }
        public void DrawCCircle(Graphics G)
        {
            G.FillEllipse(Brushes.White, (x - radius), (y - radius), 2 * radius, 2 * radius);
            G.DrawEllipse(popal ? redPen : blackPen, (x - radius), (y - radius), 2 * radius, 2 * radius);
        }
    }
}
    


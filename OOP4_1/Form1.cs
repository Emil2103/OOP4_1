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
    public partial class Form1 : Form
    {
        DrawVert V;
        List<CCircle> C;
        int selected;

        public Form1()
        {
            InitializeComponent();
            C = new List<CCircle>();
            V = new DrawVert(sheet.Width, sheet.Height);
            sheet.Image = V.GetBitmap();
        }

        private void sheet_MouseClick(object sender, MouseEventArgs e)
        {
            C.Add(new CCircle(e.X, e.Y, C.Count() + 1));
            V.drawVertex(e.X, e.Y);
            sheet.Image = V.GetBitmap();

            for(int i = 0; i < C.Count; i++)
            {
                if (Math.Pow((C[i].x - e.X), 2) + Math.Pow((C[i].y - e.Y), 2) <= V.R * V.R)
                {
                    
                        V.drawSelectedVertex(C[i].x, C[i].y);
                        sheet.Image = V.GetBitmap();
                    
                }
            }
        }
    }
}

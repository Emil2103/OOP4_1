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
        Graphics G;
        Storage S;
        Bitmap bitmap;
        bool ctrlPress = false;
        
        public Form1()
        {
            InitializeComponent();
            S = new Storage(100);
            bitmap = new Bitmap(sheet.Width, sheet.Height);
            G = Graphics.FromImage(bitmap);
            sheet.Image = bitmap;
        }

        private void sheet_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                for (int i = 0; i < S.getsize(); i++)
                {
                    if (S.circle[i] != null)
                    {
                        CCircle current = S.circle[i];
                        if (S.circle[i].Popal(e.X, e.Y))
                        {
                            if (!ctrlPress)
                            {
                                unselectedAll();
                            }
                            current.popal = (current.popal ? false : true);
                            this.Invalidate();
                            return;
                        }
                    }
                } 
                unselectedAll();
                CCircle newCircle = new CCircle(e.X, e.Y);
                S.addCCircle(newCircle);
                this.Invalidate();
            }
        }

        private void sheet_Paint(object sender, PaintEventArgs e)
        {
            G.Clear(Color.White);
            for(int i = 0; i < S.getsize(); i++)
            {
                if (S.circle[i] != null)
                    S.circle[i].DrawCCircle(G);
            }
            sheet.Image = bitmap;
        }

        private void unselectedAll()
        {
            for(int i = 0; i < S.getsize(); i++)
            {
                if(S.circle[i] != null)
                   S.circle[i].popal = false;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
                ctrlPress = true;
            if(e.KeyCode == Keys.Delete)
            {
                for(int i = 0; i < S.getsize(); i++)
                {
                    if (S.circle[i] != null && S.circle[i].popal)
                    {
                        S.deleteCCircle(i);
                    }
                }
                this.Invalidate();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            ctrlPress = false;
        }

        
    }
}

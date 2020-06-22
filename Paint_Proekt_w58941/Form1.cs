using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.IO;

namespace Paint_Proekt_w58941
{
    /// <summary>
    /// Klasa podstawowa, w której znajdują się wszystkie przyciski obiekty używane w programie
    /// </summary>
    public partial class Form1 : Form
    {
        Color paintcolor;
        bool choose = false;
        bool draw = false;
        int x, y, lx, ly = 0;
        item currItem;
        public Form1()
        {
            InitializeComponent();
        }
        public enum item
        { 
        Rectangle, Ellipse, Line, Text, Brush, Pencil, Eraser, ColorPicker
        }
        private void toolStripComboBox5_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip3_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            choose = false;

        }
        /// <summary>
        /// suwaki zmieniają kolor, który będzie używany podczas pracy z różnymi obiektami w programie może przyjąć kolor
        /// </summary>
        private void red_Scroll(object sender, EventArgs e)
        {
            paintcolor = Color.FromArgb(alpha.Value, red.Value, green.Value, blue.Value);
            CCC.BackColor = paintcolor;
        }

        private void green_Scroll(object sender, EventArgs e)
        {
            paintcolor = Color.FromArgb(alpha.Value, red.Value, green.Value, blue.Value);
            CCC.BackColor = paintcolor;
        }

        private void blue_Scroll(object sender, EventArgs e)
        {
            paintcolor = Color.FromArgb(alpha.Value, red.Value, green.Value, blue.Value);
            CCC.BackColor = paintcolor;
        }

        private void alpha_Scroll(object sender, EventArgs e)
        {
            paintcolor = Color.FromArgb(alpha.Value, red.Value, green.Value, blue.Value);
            CCC.BackColor = paintcolor;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            currItem = item.Line;
        }
        /// <summary>
        /// Tworzy linię gdzie początkowy parametr rysowania jest X a punkt końcowy linii jest równa y
        /// </summary>

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            draw = false;
            lx = e.X;
            ly = e.Y;
            if (currItem == item.Line)
            {
                Graphics g = pictureBox3.CreateGraphics();
                g.DrawLine(new Pen(new SolidBrush(paintcolor)), new Point(x, y), new Point(lx, ly));
                g.Dispose();
            }
        }
        /// <summary>
        /// Funkcja, która tworzy obiekty takie jak: kwadrat, okrąg, pędze, ołówek.
        /// EventArgs e jest parametrem o nazwie e, który zawiera dane zdarzenia.
        /// Object Sender jest parametrem zwanym Sender, który zawiera odniesienie do sterowania/obiektu, który wywołał zdarzenie.
        /// </summary>
        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            if (draw)
            {
                Graphics g = pictureBox3.CreateGraphics();
                switch (currItem)
                {
                    case item.Rectangle:
                        g.FillRectangle(new SolidBrush(paintcolor), x, y, e.X - x, e.Y - y);
                        break;
                    case item.Ellipse:
                        g.FillEllipse(new SolidBrush(paintcolor), x, y, e.X - x, e.Y - y);
                        break;
                    case item.Brush:
                        g.FillEllipse(new SolidBrush(paintcolor), e.X - x + x, e.Y - y + y, Convert.ToInt32(toolStripComboBox1.Text), Convert.ToInt32(toolStripComboBox1.Text));
                        break;
                    case item.Pencil:
                        g.FillEllipse(new SolidBrush(paintcolor), e.X - x + x, e.Y - y + y, 5, 5);
                        break;
                    case item.Eraser:
                        g.FillEllipse(new SolidBrush(pictureBox3.BackColor), e.X - x + x, e.Y - y + y, Convert.ToInt32(toolStripComboBox1.Text), Convert.ToInt32(toolStripComboBox1.Text));
                        break;

                }
                g.Dispose();
            }
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            draw = true;
            x = e.X;
            y = e.Y;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            currItem = item.Rectangle;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            currItem = item.Ellipse;
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            currItem = item.Brush;

        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            currItem = item.Pencil;
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            currItem = item.ColorPicker;
        }
        /// <summary>
        /// Narzędzie do dopasowywania kolorów po kliknięciu wybranego odcienia w programie
        /// </summary>

        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (currItem == item.ColorPicker)
            {
                Bitmap bmp = new Bitmap(pictureBox3.Width, pictureBox3.Height);
                Graphics g = Graphics.FromImage(bmp);
                Rectangle rect = pictureBox3.RectangleToScreen(pictureBox3.ClientRectangle);
                g.CopyFromScreen(rect.Location, Point.Empty, pictureBox3.Size);
                g.Dispose();
                paintcolor = bmp.GetPixel(e.X, e.Y);
                CCC.BackColor = paintcolor;
                bmp.Dispose();
                
                red.Value = paintcolor.R;
                green.Value = paintcolor.G;
                blue.Value = paintcolor.B;
                alpha.Value = paintcolor.A;

            }
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            currItem = item.Eraser;
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            currItem = item.Text;
        }
        /// <summary>
        /// Narzędzie do tworzenia tekstu dodawanie cieni do tekstu i stylu.
        /// </summary>

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            
            if (currItem == item.Text)
            {
                Graphics g = pictureBox3.CreateGraphics();
                if (toolStripComboBox6.Text == "Regular")
                {
                    g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Regular), new SolidBrush(paintcolor), new PointF(x, y));
                }
                else if (toolStripComboBox6.Text == "Bold")
                {
                    g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Bold), new SolidBrush(paintcolor), new PointF(x, y));
                }
                else if (toolStripComboBox6.Text == "Underline")
                {
                    g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Underline), new SolidBrush(paintcolor), new PointF(x, y));
                }
                else if (toolStripComboBox6.Text == "Strikeout")
                {
                    g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Strikeout), new SolidBrush(paintcolor), new PointF(x, y));
                }
                else if (toolStripComboBox6.Text == "Italic")
                {
                    g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Italic), new SolidBrush(paintcolor), new PointF(x, y));
                }

                if (toolStripComboBox2.Text == "SE")
                {
                    if (toolStripComboBox6.Text == "Regular")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Regular), new SolidBrush(Color.Gray), new PointF(x + 5, y + 5));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Regular), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (toolStripComboBox6.Text == "Bold")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Bold), new SolidBrush(Color.Gray), new PointF(x + 5, y + 5));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Bold), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (toolStripComboBox6.Text == "Underline")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Underline), new SolidBrush(Color.Gray), new PointF(x + 5, y + 5));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Underline), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (toolStripComboBox6.Text == "Strikeout")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Strikeout), new SolidBrush(Color.Gray), new PointF(x + 5, y + 5));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Strikeout), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (toolStripComboBox6.Text == "Italic")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Italic), new SolidBrush(Color.Gray), new PointF(x + 5, y + 5));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Italic), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                }
                else if (toolStripComboBox2.Text == "SW")
                {
                    if (toolStripComboBox6.Text == "Regular")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Regular), new SolidBrush(Color.Gray), new PointF(x - 5, y + 5));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Regular), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (toolStripComboBox6.Text == "Bold")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Bold), new SolidBrush(Color.Gray), new PointF(x - 5, y + 5));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Bold), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (toolStripComboBox6.Text == "Underline")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Underline), new SolidBrush(Color.Gray), new PointF(x - 5, y + 5));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Underline), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (toolStripComboBox6.Text == "Strikeout")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Strikeout), new SolidBrush(Color.Gray), new PointF(x - 5, y + 5));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Strikeout), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (toolStripComboBox6.Text == "Italic")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Italic), new SolidBrush(Color.Gray), new PointF(x - 5, y + 5));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Italic), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                }
                else if (toolStripComboBox2.Text == "NE")
                {
                    if (toolStripComboBox6.Text == "Regular")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Regular), new SolidBrush(Color.Gray), new PointF(x + 5, y - 5));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Regular), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (toolStripComboBox6.Text == "Bold")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Bold), new SolidBrush(Color.Gray), new PointF(x + 5, y - 5));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Bold), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (toolStripComboBox6.Text == "Underline")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Underline), new SolidBrush(Color.Gray), new PointF(x + 5, y - 5));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Underline), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (toolStripComboBox6.Text == "Strikeout")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Strikeout), new SolidBrush(Color.Gray), new PointF(x + 5, y - 5));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Strikeout), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (toolStripComboBox6.Text == "Italic")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Italic), new SolidBrush(Color.Gray), new PointF(x + 5, y - 5));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Italic), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                }
                else if (toolStripComboBox2.Text == "NW")
                {
                    if (toolStripComboBox6.Text == "Regular")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Regular), new SolidBrush(Color.Gray), new PointF(x - 5, y - 5));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Regular), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (toolStripComboBox6.Text == "Bold")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Bold), new SolidBrush(Color.Gray), new PointF(x - 5, y - 5));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Bold), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (toolStripComboBox6.Text == "Underline")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Underline), new SolidBrush(Color.Gray), new PointF(x - 5, y - 5));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Underline), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (toolStripComboBox6.Text == "Strikeout")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Strikeout), new SolidBrush(Color.Gray), new PointF(x - 5, y - 5));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Strikeout), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (toolStripComboBox6.Text == "Italic")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Italic), new SolidBrush(Color.Gray), new PointF(x - 5, y - 5));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Italic), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                
                }
                else if (toolStripComboBox2.Text == "S")
                {
                    if (toolStripComboBox6.Text == "Regular")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Regular), new SolidBrush(Color.Gray), new PointF(x, y + 5));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Regular), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (toolStripComboBox6.Text == "Bold")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Bold), new SolidBrush(Color.Gray), new PointF(x, y + 5));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Bold), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (toolStripComboBox6.Text == "Underline")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Underline), new SolidBrush(Color.Gray), new PointF(x, y + 5));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Underline), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (toolStripComboBox6.Text == "Strikeout")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Strikeout), new SolidBrush(Color.Gray), new PointF(x, y + 5));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Strikeout), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (toolStripComboBox6.Text == "Italic")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Italic), new SolidBrush(Color.Gray), new PointF(x, y + 5));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Italic), new SolidBrush(paintcolor), new PointF(x, y));
                    }

                }
                else if (toolStripComboBox2.Text == "N")
                {
                    if (toolStripComboBox6.Text == "Regular")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Regular), new SolidBrush(Color.Gray), new PointF(x, y - 5));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Regular), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (toolStripComboBox6.Text == "Bold")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Bold), new SolidBrush(Color.Gray), new PointF(x, y - 5));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Bold), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (toolStripComboBox6.Text == "Underline")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Underline), new SolidBrush(Color.Gray), new PointF(x, y - 5));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Underline), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (toolStripComboBox6.Text == "Strikeout")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Strikeout), new SolidBrush(Color.Gray), new PointF(x, y - 5));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Strikeout), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (toolStripComboBox6.Text == "Italic")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Italic), new SolidBrush(Color.Gray), new PointF(x, y - 5));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Italic), new SolidBrush(paintcolor), new PointF(x, y));
                    }

                }
                else if (toolStripComboBox2.Text == "W")
                {
                    if (toolStripComboBox6.Text == "Regular")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Regular), new SolidBrush(Color.Gray), new PointF(x-5, y ));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Regular), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (toolStripComboBox6.Text == "Bold")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Bold), new SolidBrush(Color.Gray), new PointF(x-5, y ));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Bold), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (toolStripComboBox6.Text == "Underline")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Underline), new SolidBrush(Color.Gray), new PointF(x-5, y ));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Underline), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (toolStripComboBox6.Text == "Strikeout")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Strikeout), new SolidBrush(Color.Gray), new PointF(x-5, y ));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Strikeout), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (toolStripComboBox6.Text == "Italic")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Italic), new SolidBrush(Color.Gray), new PointF(x-5, y));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Italic), new SolidBrush(paintcolor), new PointF(x, y));
                    }

                }
                else if (toolStripComboBox2.Text == "E")
                {
                    if (toolStripComboBox6.Text == "Regular")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Regular), new SolidBrush(Color.Gray), new PointF(x + 5, y));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Regular), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (toolStripComboBox6.Text == "Bold")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Bold), new SolidBrush(Color.Gray), new PointF(x + 5, y));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Bold), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (toolStripComboBox6.Text == "Underline")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Underline), new SolidBrush(Color.Gray), new PointF(x + 5, y));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Underline), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (toolStripComboBox6.Text == "Strikeout")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Strikeout), new SolidBrush(Color.Gray), new PointF(x + 5, y));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Strikeout), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (toolStripComboBox6.Text == "Italic")
                    {
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Italic), new SolidBrush(Color.Gray), new PointF(x + 5, y));
                        g.DrawString(toolStripComboBox3.Text, new Font(toolStripComboBox4.Text, Convert.ToInt32(toolStripComboBox5.Text), FontStyle.Italic), new SolidBrush(paintcolor), new PointF(x, y));
                    }

                }
                g.Dispose();
            }
        }

        private void toolStripComboBox6_Click(object sender, EventArgs e)
        {
     
            

        }

        private void toolStripComboBox3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox2_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// usuwa wszystkie obiekty utworzone na kanwie głównym
        /// </summary>

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            pictureBox3.Refresh();
            pictureBox3.Image = null;
        }
        /// <summary>
        /// Otwiera obraz wybrany z komputera
        /// </summary>

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "Png files| *.png|jpeg files|*jpg|bitmaps|*.bmp";
            if(o.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox3.Image = (Image)Image.FromFile(o.FileName).Clone();
            }
        }
        /// <summary>
        /// Zapisuje malowane obiekty, które znajdują się na głównym płótnie
        /// </summary>

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox3.Width, pictureBox3.Height);
            Graphics g = Graphics.FromImage(bmp);
            Rectangle rect = pictureBox3.RectangleToScreen(pictureBox3.ClientRectangle);
            g.CopyFromScreen(rect.Location, Point.Empty, pictureBox3.Size);
            g.Dispose();
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "Png files|*.png|jpeg files |jpg|bitmaps|*.bmp";
            if (s.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (File.Exists(s.FileName))
                {
                    File.Delete(s.FileName);
                }
                if (s.FileName.Contains(".jpg"))
                {
                    bmp.Save(s.FileName, ImageFormat.Jpeg);
                }
                else if (s.FileName.Contains(".png"))
                {
                    bmp.Save(s.FileName, ImageFormat.Png);
                }
                else if (s.FileName.Contains(".bmp"))
                {
                    bmp.Save(s.FileName, ImageFormat.Bmp);
                }
            }
        }

        /// <summary>
        /// usuwa wszystkie obiekty utworzone na kanwie głównym
        /// </summary>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            pictureBox3.Refresh();
            pictureBox3.Image = null;
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            choose = true;
        }
        /// <summary>
        /// Zmienia kolor za pomocą suwaków
        /// </summary>

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (choose == true)
            {
                Bitmap bmp = (Bitmap)pictureBox2.Image;
                float factor_x = (float)pictureBox2.Width / bmp.Width;
                float factor_y = (float)pictureBox2.Height / bmp.Height;
                if ((e.X >= 0) && (e.X < bmp.Width) && (e.Y >= 0) && (e.Y < bmp.Height))
                {
                    paintcolor = bmp.GetPixel((int)(e.X / factor_x), (int)(e.Y / factor_y));

                    red.Value = paintcolor.R;
                    green.Value = paintcolor.G;
                    blue.Value = paintcolor.B;
                    alpha.Value = paintcolor.A;

                    CCC.BackColor = paintcolor;
                }
               
            }
        }
        /// <summary>
        /// Funkcja posiada czcionki dla tekstu, cienie, rozmiar.
        /// </summary>

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
            FontFamily[] family = FontFamily.Families;
            foreach (FontFamily font in family)
            {
                toolStripComboBox4.Items.Add(font.GetName(1).ToString());
                
            }
            {
                toolStripComboBox6.Items.Add("Regular");
                toolStripComboBox6.Items.Add("Bold");
                toolStripComboBox6.Items.Add("Underline");
                toolStripComboBox6.Items.Add("Strikeout");
                toolStripComboBox6.Items.Add("Italic");
            }            
            {
                toolStripComboBox5.Items.Add("8");
                toolStripComboBox5.Items.Add("9");
                toolStripComboBox5.Items.Add("10");
                toolStripComboBox5.Items.Add("11");
                toolStripComboBox5.Items.Add("12");
                toolStripComboBox5.Items.Add("14");
                toolStripComboBox5.Items.Add("16");
                toolStripComboBox5.Items.Add("18");
                toolStripComboBox5.Items.Add("20");
                toolStripComboBox5.Items.Add("22");
                toolStripComboBox5.Items.Add("24");
                toolStripComboBox5.Items.Add("26");
                toolStripComboBox5.Items.Add("28");
                toolStripComboBox5.Items.Add("36");
                toolStripComboBox5.Items.Add("48");
                toolStripComboBox5.Items.Add("72");
            }
            {
                toolStripComboBox2.Items.Add("SE");
                toolStripComboBox2.Items.Add("SW");
                toolStripComboBox2.Items.Add("NE");
                toolStripComboBox2.Items.Add("NW");
                toolStripComboBox2.Items.Add("S");
                toolStripComboBox2.Items.Add("N");
                toolStripComboBox2.Items.Add("W");
                toolStripComboBox2.Items.Add("E");
                toolStripComboBox2.Items.Add("None");
            }            
        }
    }
}

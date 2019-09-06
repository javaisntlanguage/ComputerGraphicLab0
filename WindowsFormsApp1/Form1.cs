using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        List<MouseEventArgs> Coordinates;
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Coordinates = new List<MouseEventArgs>();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Left) //если лкм
            {
                bmp.SetPixel(e.X, e.Y, Color.Black); //делаем пиксель черным
                Coordinates.Add(e);//добавляем в листок с точками
            }
            else if (e.Button == MouseButtons.Right)//если пкм
            {
                Random random = new Random();//создаем объект рандома
                var pointColor = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255)); //выбираем рандомный цвет
                foreach (MouseEventArgs Coordinate in Coordinates) //проходим по листку 
                {
                    bmp.SetPixel(Coordinate.X, Coordinate.Y, pointColor); //меняем цвет точек на рандомный
                }
            }
            pictureBox1.Image = bmp; //отображаем
        }
    }
}

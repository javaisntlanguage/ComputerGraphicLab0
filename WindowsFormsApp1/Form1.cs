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
        List<Point> Coordinates;
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Coordinates = new List<Point>(); 
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e) //событие (функция вызывается, когда нажата кнопка мыши)
        {
            var p = new Point(e.X, e.Y); //вызов конструктора создание объекта
            if (e.Button == MouseButtons.Left) //если нажата левая кнопка мыши, то выполняется (делается черный пиксель)
            {
                bmp.SetPixel(p.X, p.Y, Color.Black); //делаем пиксель черным
                Coordinates.Add(p);//добавляем в листок с точками
            }
            else if (e.Button == MouseButtons.Right)//если правая
            {
                Random random = new Random();//создаем объект рандома
                var pointColor = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255)); 
                foreach (Point Coordinate in Coordinates) //проходим по координатам
                {
                    bmp.SetPixel(Coordinate.X, Coordinate.Y, pointColor); 
                }
            }
            pictureBox1.Image = bmp; 
        }
    }
}

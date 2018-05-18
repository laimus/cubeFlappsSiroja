using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CubeFlapps_Undermove
{
    public partial class Form1 : Form
    {
        const int gravity = 1;
        const int minPenWidth = 2;

        Bitmap bmp;
        Pen pen;
        Random rnd = new Random();
        Font f = SystemFonts.DefaultFont;

        Rectangle player;
        int playerVelocity = 0;
        int playerForce = 20;
        int score = 0;
        bool isGlowingOn = true;

        Rectangle tube1;
        Rectangle tube2;
        Rectangle tube3;
        Rectangle tube4;
        Rectangle tube5;
        Rectangle tube6;
        int space = 150;
        int tubesVelocity = -3;

        SoundPlayer soundPlayer;

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pen = new Pen(Brushes.Aqua);
            player = new Rectangle(30, 30, 30, 30);
            tube1 = new Rectangle(300, 300, 80, 500);
            tube2 = new Rectangle(tube1.X, tube1.Y - tube1.Height - space, 80, 500);
            tube3 = new Rectangle(500, 400, 80, 500);
            tube4 = new Rectangle(tube3.X, tube3.Y - tube3.Height - space, 80, 500);
            tube5 = new Rectangle(700, 200, 80, 500);
            tube6 = new Rectangle(tube5.X, tube5.Y - tube5.Height - space, 80, 500);


            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.IO.Stream resourceStream = assembly.GetManifestResourceStream(@"CubeFlapps_Undermove.music_undermove.wav");
            soundPlayer = new SoundPlayer(resourceStream);
            soundPlayer.PlayLooping();
        }

        // Главный цикл игры. Отрисовка + логика 
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(pen.Width > minPenWidth)
            {
                pen.Width--;
            }

            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Black);

            // Отрисовываем объекты из памяти
            Draw(g);

            pictureBox1.Image = bmp;
            g.Dispose();
        }

        // Если мы хотим чтобы что-то отбразилось на экране, 
        // то нужно добавить это сюда
        private void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.White, player);
            g.FillRectangle(Brushes.Blue, tube1);
            g.FillRectangle(Brushes.Blue, tube2);
            g.FillRectangle(Brushes.Blue, tube3);
            g.FillRectangle(Brushes.Blue, tube4);
            g.FillRectangle(Brushes.Blue, tube5);
            g.FillRectangle(Brushes.Blue, tube6);
            g.DrawRectangle(pen, player);
            g.DrawRectangle(pen, tube1);
            g.DrawRectangle(pen, tube2);
            g.DrawRectangle(pen, tube3);
            g.DrawRectangle(pen, tube4);
            g.DrawRectangle(pen, tube5);
            g.DrawRectangle(pen, tube6);
            g.DrawString(score.ToString(), f, Brushes.White, 400, 400);
        }

        private void TubesLogic()
        {
            // дигаем трубы
            tube1.X += tubesVelocity;
            tube2.X = tube1.X;

            tube3.X += tubesVelocity;
            tube4.X = tube3.X;

            tube5.X += tubesVelocity;
            tube6.X = tube5.X;

            // если правый край трубы зашел за левый край
            // то перемещаем трубы в правый край
            if (tube1.Right <= 0)
            {
                tube1.X = pictureBox1.Width;
                tube1.Y = rnd.Next(space + 30, pictureBox1.Height - 30);
                tube2.Y = tube1.Y - space - tube1.Height;
            }

            if (tube3.Right <= 0)
            {
                tube3.X = pictureBox1.Width;
                tube3.Y = rnd.Next(space + 30, pictureBox1.Height - 30);
                tube4.Y = tube3.Y - space - tube3.Height;
            }

            if (tube5.Right <= 0)
            {
                tube5.X = pictureBox1.Width;
                tube5.Y = rnd.Next(space + 30, pictureBox1.Height - 30);
                tube6.Y = tube5.Y - space - tube5.Height;
            }
        }

        private void PlayerLogic()
        {
            score++;

            // Двигаем игрока с ускорением
            playerVelocity += gravity;
            player.Y += playerVelocity;

            // Если игрок нижней частью коснулся 
            // нижней части игрового поля,
            // то пермещаем кго вверх и сбрасываем скорость
            // иначе если игрок коснулся потолка, то сбрасываем скорость 
            // и перемещаем его вплотную к потолку.
            if (player.Bottom >= pictureBox1.Height)
            {
                player.Y = 0;
                playerVelocity = 0;
                score = 0;
            }
            else if (player.Y < 0)
            {
                playerVelocity = 0;
                player.Y = 0;
            }

            if (player.Right >= tube1.Left &&
                player.Bottom >= tube1.Top &&
                player.Left < tube1.Right) 
            {
                player.Y = 0;
                playerVelocity = 0;
                score = 0;
            }
            if (player.Right >= tube2.Left &&
                player.Top <= tube2.Bottom &&
                player.Left < tube2.Right)
            {
                player.Y = 0;
                playerVelocity = 0;
                score = 0;
            }

            if (player.Right >= tube3.Left &&
                player.Bottom >= tube3.Top &&
                player.Left < tube3.Right)
            {
                player.Y = 0;
                playerVelocity = 0;
                score = 0;
            }
            if (player.Right >= tube4.Left &&
                player.Top <= tube4.Bottom &&
                player.Left < tube4.Right)
            {
                player.Y = 0;
                playerVelocity = 0;
                score = 0;
            }

            if (player.Right >= tube5.Left &&
                player.Bottom >= tube5.Top &&
                player.Left < tube5.Right)
            {
                player.Y = 0;
                playerVelocity = 0;
                score = 0;
            }
            if (player.Right >= tube6.Left &&
                player.Top <= tube6.Bottom &&
                player.Left < tube6.Right)
            {
                player.Y = 0;
                playerVelocity = 0;
                score = 0;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            // Если нажат пробел, то добавляем скорость вверх
            if(e.KeyCode == Keys.Space)
            {
                playerVelocity -= playerForce;
                drawTimer.Start();
                playerTimer.Start();
                tubesTimer.Start();

                if(isGlowingOn)
                {
                    pen.Width = 10;
                }
            }
            else if(e.KeyCode == Keys.Escape)
            {
                drawTimer.Enabled = !drawTimer.Enabled;
                playerTimer.Enabled = !playerTimer.Enabled;
                tubesTimer.Enabled = !tubesTimer.Enabled;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
            }
            else if(e.KeyCode == Keys.L)
            {
                drawTimer.Stop();
                playerTimer.Stop();
                tubesTimer.Stop();
                new LeaderboardForm(score).Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Black);

            // Отрисовываем объекты из памяти
            Draw(g);

            pictureBox1.Image = bmp;
            g.Dispose();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            drawTimer.Start();
            playerTimer.Start();
            tubesTimer.Start();
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            new LeaderboardForm(score).Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            new SettingsForm().Show();
        }

        private void tubesTimer_Tick(object sender, EventArgs e)
        {
            TubesLogic();
        }

        private void playerTimer_Tick(object sender, EventArgs e)
        {
            PlayerLogic();
        }

        private void settingsUpdateTimer_Tick(object sender, EventArgs e)
        {
            if(File.Exists("settings"))
            {
                string[] settings = File.ReadAllLines("settings");
                if(settings.Length >= 3)
                {
                    playerTimer.Interval = Convert.ToInt32(settings[0]); 
                    tubesTimer.Interval = Convert.ToInt32(settings[1]);
                    isGlowingOn = Convert.ToBoolean(settings[2]);
                }
            }
            else
            {
                File.Create("settings");
            }
        }
    }
}

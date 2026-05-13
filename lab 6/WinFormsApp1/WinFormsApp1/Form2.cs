using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        private Timer timerSpawn = new Timer();
        private Timer timerGame = new Timer();

        private Button[,] grid;
        private Random rand = new Random();

        private int score = 0;
        private int timeLeft;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            int X = ustawieniagry.X;
            int Y = ustawieniagry.Y;

            grid = new Button[X, Y];
            int size = 60;

            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    Button btn = new Button
                    {
                        Width = size,
                        Height = size,
                        Left = j * size,
                        Top = i * size,
                        Tag = "empty",
                        Text = ""
                    };

                    btn.Click += Btn_Click;

                    this.Controls.Add(btn);
                    grid[i, j] = btn;
                }
            }

            timeLeft = ustawieniagry.Czas;

            timerGame.Interval = 1000;
            timerGame.Tick += TimerGame_Tick;
            timerGame.Start();

            timerSpawn.Interval = 3000;
            timerSpawn.Tick += (s, e) => SpawnAnimal();
            timerSpawn.Start();

            SpawnAnimal();
        }

        void SpawnAnimal()
        {
            if (grid == null) return;

            foreach (var b in grid)
            {
                b.Text = "";
                b.Tag = "empty";
            }

            int x = rand.Next(ustawieniagry.X);
            int y = rand.Next(ustawieniagry.Y);

            int animal = rand.Next(3); // 0=hyrax, 1=szop, 2=krokodyl

            if (animal == 0 && ustawieniagry.Hyraxy > 0)
            {
                grid[x, y].Text = "H";
                grid[x, y].Tag = "hyrax";
            }
            else if (animal == 1 && ustawieniagry.Szopy > 0)
            {
                grid[x, y].Text = "S";
                grid[x, y].Tag = "szop";
            }
            else if (animal == 2 && ustawieniagry.Krokodyle > 0)
            {
                grid[x, y].Text = "K";
                grid[x, y].Tag = "krokodyl";
            }
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;

            switch (b.Tag?.ToString())
            {
                case "hyrax":
                    score++;
                    if (ustawieniagry.Hyraxy > 0) ustawieniagry.Hyraxy--;
                    break;

                case "szop":
                    score--;
                    if (ustawieniagry.Szopy > 0) ustawieniagry.Szopy--;
                    break;

                case "krokodyl":
                    EndGame("Kliknąłeś krokodyla!");
                    return;
            }
        }
        private void TimerGame_Tick(object sender, EventArgs e)
        {
            timeLeft--;

            lblTime.Text = timeLeft.ToString();

            if (timeLeft <= 0)
            {
                EndGame("Czas minął!");
            }
        }
        void EndGame(string reason)
        {
            timerGame.Stop();
            timerSpawn.Stop();

            MessageBox.Show($"{reason}\nWynik: {score}");

            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

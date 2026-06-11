using System;
using System.Drawing;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        private Timer timerSpawn = new Timer();
        private Timer timerHide 
        private Timer timerGame = new Timer();

        private Button[,] grid;
        private Random rand = new Random();

        private int score = 0;
        private int timeLeft;
        private int caughtHyrax = 0;
        private int targetHyrax = 0;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            int rows = ustawieniagry.X;
            int cols = ustawieniagry.Y;

            targetHyrax = ustawieniagry.Hyraxy;

            grid = new Button[rows, cols];
            
            int size = 60;
            int startX = 20; ;
            int startY = 70;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Button btn = new Button
                    {
                        Width = size,
                        Height = size,
                        Left = startX+j * size,
                        Top = StartY+i * size,
                        Tag = "empty",
                        Text = "🗑️"
                        Font = new Font("Segoe UI Emoji", 18),
                        BackColor = Color.LightGray
                    };

                    btn.Click += Btn_Click;
                    Controls.Add(btn);
                    grid[i, j] = btn;
                }
            }

            timeLeft = ustawieniagry.Czas;
            lblTime.Text = $"Czas: {timeLeft}";
            lblScore.Text= $"Punkty: {score}";
            lblHyrax.Text = $"Hyraxy: {caughtHyrax}/{targetHyrax}";

            timerGame.Interval = 1000;
            timerGame.Tick += TimerGame_Tick;
            timerGame.Start();

            timerSpawn.Interval = 3000;
            timerSpawn.Tick += TimerSpawn_Tick;
            timerSpawn.Start();

            timerHide.Interval = 1000;
            timerHide.Tick += TimerHide_Tick;

            SpawnAnimals();
        }
        private void TimerSpawn_Tick(object sender, EventArgs e)
        {
            SpawnAnimals();
        }
        private void TimerHide_Tick(object sender, EventArgs e)
        {
            ClearBoard();
            timerHide.Stop();
        }

        void SpawnAnimals()
        {
            ClearBoard();
            int animalCount = rand.Next(1, 4);
            for (int i = 0; i < animalCount; i++)
            {
                int x = rand.Next(ustawieniagry.Y);
                int y = rand.Next(ustawieniagry.X);

                while (grid[x, y].Tag.ToString() != "empty")
                {
                    x = rand.Next(ustawieniagry.Y);
                    y = rand.Next(ustawieniagry.X);
                }

                string animal = DrawAnimal();

                if (animal == "hyrax")
                {
                    grid[x, y].Text = "H";
                    grid[x, y].BackColor = Color.LightGreen;
                    grid[x, y].Tag = "hyrax";
                }
                else if (animal == "szop")
                {
                    grid[x, y].Text = "S";
                    grid[x, y].BackColor = Color.LightBlue;
                    grid[x, y].Tag = "szop";
                }
                else if (animal == "krokodyl")
                {
                    grid[x, y].Text = "K";
                    grid[x, y].BackColor = Color.IndianRed;
                    grid[x, y].Tag = "krokodyl";
                }
            }
            timerHide.Start();
        }
        private string DrawAnimal()
        {
            int max = ustawieniagry.Hyraxy + ustawieniagry.Szopy + ustawieniagry.Krokodyle;
            int number = rand.Next(max);

            if (number < ustawieniagry.Hyraxy) return "hyrax";
            else if (number < ustawieniagry.Hyraxy + ustawieniagry.Szopy) return "szop";
            else return "krokodyl";
        }
        private void ClearBoard()
        {
            foreach (Button b in grid)
            {
                b.Text = "🗑️";
                b.Tag = "empty";
                b.BackColor = Color.LightGray;
            }
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;

            switch (b.Tag?.ToString())
            {
                case "hyrax":
                    score++;
                    caughtHyrax++;
                    b.Text = "🗑️";
                    b.Tag = "empty";
                    b.BackColor = Color.LightGray;
                    if (caughtHyrax >= targetHyrax)
                    {
                        EndGame("Wygrałeś! Złapałeś wszystkie hyraxy!");
                        return;
                    }
                    break;

                case "szop":
                    score--;
                    b.Text = "🗑️";
                    b.Tag = "empty";
                    b.BackColor = Color.LightGray;
                    break;

                case "krokodyl":
                    EndGame("Kliknąłeś krokodyla!");
                    return;
            }
            lblScore.Text=$"Punkty: {score}";
            lblHyrax.Text = $"Hyraxy: {caughtHyrax}/{targetHyrax}";
        }
        private void TimerGame_Tick(object sender, EventArgs e)
        {
            timeLeft--;

            lblTime.Text = $"Czas: {timeLeft}";

            if (timeLeft <= 0)
            {
                EndGame("Czas minął!");
            }
        }
        private void EndGame(string reason)
        {
            timerGame.Stop();
            timerSpawn.Stop();
            timerHide.Stop();

            foreach (Button b in grid)
            {
                b.Enabled = false;
            }

            MessageBox.Show($"{reason}\nWynik: {score}"\nCzas pozostaly:{timeLeft} sekund);
            Close();
        }
    }
}

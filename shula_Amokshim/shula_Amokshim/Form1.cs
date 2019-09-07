using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shula_Amokshim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static Block[,] Game;
        static Point gridSize = new Point(10, 10);
        static bool lose = false;
        const int cubeSize = 25;


        static bool Flag = false;
        Time timer;
        int tCounter = 1;
        newGame win;
        Point[] bombList;
        const int init_bombs = 15;
        int backGroundHeight;

        void resetGame()
        {
            for (int i = 0; i < gridSize.X; i++)
            {
                for (int j = 0; j < gridSize.Y; j++)
                {
                    Game[i, j].vis.Visible = false;
                }
            }
        }

        int range(int num, int min, int max)
        {
            if (num < min) return min;
            if (num > max) return max;
            return num;
        }

        void initGame(int x, int y, int bombs)
        {
            x = range(x, 7, 35);
            y = range(y, 7, 35);
            bombs = range(bombs, (int)(x * y / 10), (int)(x * y / 2));
            if (Game != null) resetGame();

            Game = generateGrid(x, y);
            bombList = armBombs(Game, bombs);
            timer = new Time();
            tCounter = 0;

        }

        Point[] armBombs(Block[,] game, int bombNum)
        {
            bombList = new Point[bombNum];
            Random rand = new Random();
            for (int i = 0; i < bombNum; i++)
            {
                do
                {
                    bombList[i] = new Point(rand.Next(gridSize.X), rand.Next(gridSize.Y));
                } while (game[bombList[i].X, bombList[i].Y].isBomb());

                game[bombList[i].X, bombList[i].Y].arm();

            }

            return bombList;

        }

        Block[,] generateGrid(int x, int y)
        {
            gridSize = new Point(x, y);

            Block[,] grid = new Block[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    grid[i, j] = new Block(25 * i + 5, backGroundHeight + (j * 25), idCode(i, j));
                    init_block(grid[i, j]);
                }
            }

            return grid;
        }

        int idCode(int i, int j)
        {
            return i * j + i + j;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            backGroundHeight = background.Height + 5;
            initGame(gridSize.X, gridSize.Y, init_bombs);

        }

        void init_block(Block b)
        {
            Label temp = b.vis;
            Controls.Add(temp);
        }

        class Block
        {
            public int x { get; set; }
            public int y { get; set; }
            public Label vis { get; set; }
            public bool is_bomb { get; set; }
            public bool isflag = false;
            public bool pressed = false;
            public Block(int x, int y, int id)
            {
                vis = new Label();
                vis.Width = 25;
                vis.Height = 25;
                vis.Location = new Point(x, y);
                vis.Visible = true;
                vis.Text = " ";
                is_bomb = false;
                vis.BackColor = Color.Gray;
                vis.BorderStyle = BorderStyle.Fixed3D;
                vis.TextAlign = ContentAlignment.MiddleCenter;



                vis.Click += new EventHandler(DynamicButton_Click);


            }

            public bool isBomb()
            {
                return is_bomb;
            }

            public void arm()
            {
                this.is_bomb = true;
            }

            private void DynamicButton_Click(object sender, EventArgs e)
            {

                
                Point cor = getXY(Game, this);
                if (lose || pressed || (Game[cor.X, cor.Y].vis.BackColor == Color.LightGray)) return;
                if (!Flag)
                {
                    if (isflag)
                    {
                        vis.ForeColor = Color.Black;
                        vis.Text = "";
                        isflag = false;
                        return;
                    }
                    if (is_bomb)
                    {
                        GameOver();
                        return;
                    }
                    int bomb_in_area = getPoints(cor.X, cor.Y);
                    
                }
                else
                {
                    if (isflag)
                    {
                        vis.ForeColor = Color.Black;
                        vis.Text = "";
                        isflag = false;
                    }
                    else
                    {
                        vis.ForeColor = Color.Red;
                        vis.Text = "🏁";
                        isflag = true;
                    }
                }

            }

        }

        static Point getXY(Block[,] game, Block b)
        {
            for (int i = 0; i < gridSize.X; i++)
            {
                for (int j = 0; j < gridSize.Y; j++)
                {
                    if (game[i, j] == b)
                        return new Point(i, j);
                }
            }
            return Point.Empty;

        }

        static public void clearPoints(int x, int y)
        {
            int ret = 0;
            Game[x, y].vis.BackColor = Color.LightGray;

            if (x > 0)// left
            {
                if (getPoints(x - 1, y) == 0 && Game[x - 1, y].vis.BackColor != Color.LightGray)
                {
                    clearPoints(x - 1, y);
                }
            }
            if (y > 0)// top
            {
                if (getPoints(x, y - 1) == 0 && Game[x, y - 1].vis.BackColor != Color.LightGray)
                {
                    clearPoints(x, y - 1);
                }
            }

            if (y < gridSize.Y - 1 && Game[x, y + 1].vis.BackColor != Color.LightGray)// bottom
            {
                if (getPoints(x, y + 1) == 0)
                {
                    clearPoints(x, y + 1);
                }
            }

            if (x < gridSize.X - 1 && Game[x + 1, y].vis.BackColor != Color.LightGray)// right
            {
                if (getPoints(x + 1, y) == 0)
                {
                    clearPoints(x + 1, y);
                }
            }

        }

        static public int getPoints(int x, int y)
        {
            int ret = 0;
            if (x > 0)
            {
                if (Game[x - 1, y].is_bomb) ret += 1; // left
            }
            if (y > 0)
            {
                if (Game[x, y - 1].is_bomb) ret += 1; // top
            }

            if (y > 0 && x > 0)
            {
                if (Game[x - 1, y - 1].is_bomb) ret += 1; // top left
            }

            if (y < gridSize.Y - 1)
            {
                if (Game[x, y + 1].is_bomb) ret += 1; // bottom
            }

            if (y < gridSize.Y - 1 && x > 0)
            {
                if (Game[x - 1, y + 1].is_bomb) ret += 1;// bottom left
            }

            if (y < gridSize.Y - 1 && x < gridSize.X - 1)
            {
                if (Game[x + 1, y + 1].is_bomb) ret += 1;// bottom right
            }

            if (x < gridSize.X - 1)
            {
                if (Game[x + 1, y].is_bomb) ret += 1;// right
            }

            if (y > 0 && x < gridSize.X - 1)
            {
                if (Game[x + 1, y - 1].is_bomb) ret += 1;// top right
            }


            if (ret > 0)
            {
                Game[x, y].vis.Text = ret.ToString();
                Game[x, y].pressed = true;
                switch (ret)
                {
                    case 1:
                        Game[x, y].vis.ForeColor = Color.Blue;
                        break;
                    case 2:
                        Game[x, y].vis.ForeColor = Color.Green;
                        break;
                    case 3:
                        Game[x, y].vis.ForeColor = Color.Red;
                        break;
                    case 4:
                        Game[x, y].vis.ForeColor = Color.DarkBlue;
                        break;
                    case 5:
                        Game[x, y].vis.ForeColor = Color.Gold;
                        break;
                    case 6:
                        Game[x, y].vis.ForeColor = Color.Purple;
                        break;
                    case 7:
                        Game[x, y].vis.ForeColor = Color.Brown;
                        break;
                    case 8:
                        Game[x, y].vis.ForeColor = Color.Yellow;
                        break;

                }

                return ret;
            }
            else
            {
                clearPoints(x, y);
                return 0;
            }
        }

        private void Master_Click(object sender, EventArgs e)
        {

        }

        private void mainthread_Tick(object sender, EventArgs e)
        {
            tCounter += 1;

            tLabel.Left = button1.Left + button1.Width + 5;
            Mode.Left = tLabel.Left + tLabel.Width + 5;

            this.Height = Game[0, gridSize.Y - 1].vis.Top + 3 * cubeSize - 5;
            this.Width = Game[gridSize.X - 1, 0].vis.Left + 2 * cubeSize - 5;

            ShowBombs.Left = this.Width - ShowBombs.Width - 20;
            background.Width = this.Width;
            if (tCounter % 100 == 0 && !lose)
            {
                timer.inc();
            }
            tLabel.Text = timer.time();

            if (WinGame() && !lose)
            {
                lose = true;
                MessageBox.Show("Good Job, your time was: " + timer.time());
            }




            if (win != null)
            {
                if (win.finished)
                {
                    lose = false;
                    initGame(win.intwidth, win.intheight, win.intbombs);
                    win.Close();
                    win = null;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (win != null) win.Close();
            win = new newGame();
            win.Show();



        }

        private void ShowBombs_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridSize.X; i++)
            {
                for (int j = 0; j < gridSize.Y; j++)
                {
                    if (Game[i, j].isBomb())
                        Game[i, j].vis.BackColor = Color.Red;
                }
            }
        }

        bool WinGame()
        {
            bool ret = true;
            for (int i = 0; i<gridSize.X; i++)
            {
                for (int j = 0; j<gridSize.Y; j++)
                {
                    if (Game[i, j].is_bomb == true)
                        ret = ret && Game[i, j].is_bomb == Game[i, j].isflag;
                    if (!Game[i, j].is_bomb)
                    {
                        ret = ret && (Game[i, j].vis.Text != "");
                    }
                }
            }
            return ret;
        }

        static void GameOver()
        {
            for (int i = 0; i < gridSize.X; i++)
            {
                for (int j = 0; j < gridSize.Y; j++)
                {
                    if (Game[i, j].isBomb())
                    {
                        Game[i, j].vis.BackColor = Color.Red;
                        Game[i, j].vis.Text = "💣";
                    }
                }
            }
            MessageBox.Show("Game Over!");
            lose = true;

        }

        class Time
        {
            int seconds;
            public Time()
            {
                seconds = 0;
            }

            public string time()
            {
                string sec = (seconds % 60).ToString();
                string min = ((int)(seconds / 60)).ToString();

                if ((seconds % 60) < 10)
                    sec = "0" + sec;
                if ((int)(seconds / 60) < 10)
                    min = "0" + min;

                return min + " : " + sec;
            }

            public void inc()
            {
                seconds++;
            }
        }

        private void Mode_Click(object sender, EventArgs e)
        {
            Flag = !Flag;
            if (Flag)
            {
                Mode.ForeColor = Color.FromArgb(0, 192, 0);
                Mode.Text = "🏁";
            }
            else
            {
                Mode.ForeColor = Color.Blue;
                Mode.Text = "💣";
            }
        }
    }

    
}

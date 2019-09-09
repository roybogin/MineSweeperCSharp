using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class Form1 : Form
    {
        public static readonly int ROWS = 20;
        public static readonly int COLS = 20;
        public static int unviewed = ROWS * COLS;
        public static readonly int BOMBS = 30;
        public static Panel[,] grid = new Panel[ROWS, COLS];
        public static Color[] colors = {Color.LightGreen, Color.SkyBlue, Color.Red, Color.Violet, Color.Silver, Color.Orange, Color.Yellow, Color.Green };
        DateTime start;
        DateTime end;

        public Form1()
        {
            InitializeComponent();
            start = DateTime.Now;
            this.Size = new Size(30 * COLS + 40, 30 * ROWS + 40);
            CreateBoard(masterLabel);
            GenerateBombs(BOMBS);
        }

        public void Victory()
        {
            end = DateTime.Now;
            BackColor = Color.SpringGreen;
            MessageBox.Show("You Won!!!\nTime it took: " + (end-start).Minutes + ":" + (end-start).Seconds);
            foreach(Panel p in grid)
            {
                p.getLabel().Click -= Label_Click;
            }
        }

        public void Lose()
        {
            BackColor = Color.Red;
            MessageBox.Show("You Lost");
            foreach (Panel p in grid)
            {
                p.getLabel().Click -= Label_Click;
            }
        }

        public Label Clone(Label original, string name, Point location)
        {
            Label newLabel = new Label();
            newLabel.Location = location;
            newLabel.Name = name;
            newLabel.Visible = true;
            newLabel.Text = original.Text;
            newLabel.Size = original.Size;
            newLabel.TextAlign = original.TextAlign;
            newLabel.BackColor = original.BackColor;
            newLabel.AutoSize = original.AutoSize;
            newLabel.Click += Label_Click;
            this.Controls.Add(newLabel);
            return newLabel;
        }

        public void CreateBoard(Label original)
        {
            for(int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    grid[row, col] = new Panel(Clone(original, row + "-" + col, new Point(30 * col + 5, 30 * row + 5)));
                }
            }
        }

        public void GenerateBombs(int n)
        {
            if (n >= grid.Length-1)
                throw new Exception("The number of the bombs is too high");
            else
            {
                int i = 0;
                while(i < n)
                {
                    Random random = new Random();
                    int randomRow = random.Next(ROWS);
                    int randomCol = random.Next(COLS);
                    Panel p = grid[randomRow, randomCol];
                    if(p.HasBomb())
                        continue;
                    p.AddBomb();
                    i++;
                }
            }
        }

        
        private Panel GetPanel(Label label)
        {
            return grid[int.Parse(label.Name.Substring(0, label.Name.IndexOf('-'))), int.Parse(label.Name.Substring(label.Name.IndexOf('-') + 1))];
        }

        private void Label_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouseEvent = (MouseEventArgs)e;
            Panel p = GetPanel((Label)sender);
            if(mouseEvent.Button == MouseButtons.Left)
            {
                p.LeftClick();
                if (unviewed == BOMBS)
                    Victory();
                if (p.HasBomb())
                    Lose();
            }
            else if (mouseEvent.Button == MouseButtons.Right)
            {
                p.RightClick();
            }
        }  
    }
}

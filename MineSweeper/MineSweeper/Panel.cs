using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper
{
    public class Panel
    {
        private Label label;
        private bool hasBomb;
        private bool viewed;
        private bool flagged;

        public Panel(Label label)
        {
            this.label = label;
            hasBomb = false;
            viewed = false;
            flagged = false;
        }

        private List<Panel> getAround()
        {
            List<Panel> list = new List<Panel>();
            int row = int.Parse(label.Name.Substring(0, label.Name.IndexOf('-')));
            int col = int.Parse(label.Name.Substring(label.Name.IndexOf('-') + 1));
            if (row != 0)
            {
                if (col != 0)
                    list.Add(Form1.grid[row - 1, col - 1]);

                list.Add(Form1.grid[row - 1, col]);

                if (col != Form1.COLS-1)
                    list.Add(Form1.grid[row - 1, col + 1]);
            }

            if (col != 0)
                list.Add(Form1.grid[row, col - 1]);

            list.Add(Form1.grid[row, col]);

            if (col != Form1.COLS - 1)
                list.Add(Form1.grid[row, col + 1]);

            if (row != Form1.ROWS-1)
            {
                if (col != 0)
                    list.Add(Form1.grid[row + 1, col - 1]);

                list.Add(Form1.grid[row + 1, col]);

                if (col != Form1.COLS - 1)
                    list.Add(Form1.grid[row + 1, col + 1]);
            }
            return list;
        }

        public Label getLabel()
        {
            return label;
        }

        public bool HasBomb()
        {
            return hasBomb;
        }

        public void AddBomb()
        {
            if (!hasBomb)
                hasBomb = true;
        }

        public int BombsAround()
        {
            int bombCount = 0;
            List<Panel> list = getAround();
            foreach(Panel p in list)
            {
                if(p.HasBomb())
                {
                    bombCount++;
                }
            }
            return bombCount;
        }

        public void ShowSquare()
        {
            int bombCount = BombsAround();
            viewed = true;
            if (bombCount != 0)
            {
                label.Text = bombCount.ToString();
                label.BackColor = Form1.colors[bombCount - 1];
                Form1.unviewed--;     
            }
            else
            {
                label.Text = "";
                Form1.unviewed--;
                List<Panel> list = getAround();
                foreach (Panel p in list)
                {
                    if((!p.viewed)&&(!p.flagged))
                        p.ShowSquare();
                }
            }
            
        }

        public void LeftClick()
        {
            if (!viewed && !flagged)
            {
                viewed = true;
                if (hasBomb)
                {
                    label.Text = "X";
                    label.ForeColor = Color.Red;
                }
                else
                {
                    this.ShowSquare();
                }
            }
        }

        public void RightClick()
        {
            if (!viewed)
            {
                if (flagged)
                {
                    flagged = false;
                    label.ForeColor = Color.Black;
                    label.Text = "O";
                }
                else
                {
                    flagged = true;
                    label.ForeColor = Color.Blue;
                    label.Text = "F";
                }
            }
        }

    }
}

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

        private List<Panel> getAround() //get the panels around the given panel
        {
            List<Panel> list = new List<Panel>();
            int row = int.Parse(label.Name.Substring(0, label.Name.IndexOf('-')));
            int col = int.Parse(label.Name.Substring(label.Name.IndexOf('-') + 1));
            if (row != 0)   //if the panel isn't on the first row (has a row above it)
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

            if (row != Form1.ROWS-1) //if the panel isn't on the last row (has a row below it)
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

        public int BombsAround()    //count number of bombs around the panel
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
            if (bombCount != 0) //show the number of bombs near the panel
            {
                label.Text = bombCount.ToString();
                label.BackColor = Form1.colors[bombCount - 1];
                Form1.unviewed--;     
            }
            else
            {   //if there are no bombs around the panel, uncover the panel around this one recursively
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
            if (!viewed && !flagged)    //work if not viewed or flagged
            {
                viewed = true;
                if (hasBomb)    //fail if the panel has a bomb
                {
                    label.Text = "X";
                    label.ForeColor = Color.Red;
                }
                else
                {
                    this.ShowSquare();  //show the panel's value
                }
            }
        }

        public void RightClick()    //toggle flag
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

using System;
using System.Drawing;
using System.Windows.Forms;
using SudokuSolver;

namespace Sudoku
{
    public partial class Form1 : Form
    {
        private int TextBoxSize { get; set; } = 40;
        private int SquareSize => TextBoxSize * 3;
        private int OverallSize => SquareSize * 3;

        public Form1()
        {
            InitializeComponent();
            this.Squares = new CustomGroupBox[3][];
            for(int i = 0; i < 3; i++)
            {
                Squares[i] = new CustomGroupBox[] { new CustomGroupBox(TextBoxSize), new CustomGroupBox(TextBoxSize), new CustomGroupBox(TextBoxSize) };
            }
            int boxNumber = 0;

            this.Size = new Size(this.Size.Width, OverallSize + (2 * OverallBox.Location.Y));

            int submitY = (this.Size.Height - Submit.Size.Height) / 2;
            Submit.Location = new Point(Submit.Location.X, submitY);

            for (int row = 0; row < 3; row++)
            {
                for(int col = 0; col < 3; col++)
                {
                    CustomGroupBox box = Squares[row][col];
                    this.OverallBox.Controls.Add(box);

                    foreach (TextBox[] textBoxes in box.Boxes)
                    {
                        foreach(TextBox textBox in textBoxes)
                        {
                            box.Controls.Add(textBox);
                        }
                    }
                    box.Size = new Size(SquareSize, SquareSize);
                    box.Location = new Point(col * SquareSize, row * SquareSize);
                    box.BoxNumber = boxNumber;

                    Color backColor = Color.White;
                    if (boxNumber % 2 == 1)
                    {
                        backColor = Color.LightGray;
                    }
                    box.BackColor = backColor;

                    boxNumber++;
                }
            }
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            int[][] grid = new int[9][];
            for(int i = 0; i < grid.Length; i++)
            {
                grid[i] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0};
            }

            grid = GetGrid(grid);
            Solver.PrintGrid(grid);
            if (Solver.SolveSodoku(grid)) 
            {
                FillGrid(grid, Color.Red);
            }
            else { }
        }

        private int[][] GetGrid(int[][] grid)
        {
            for(int row = 0; row < Squares.Length; row++)
            {
                for (int col = 0; col < Squares[0].Length; col++)
                {
                    CustomGroupBox square = Squares[row][col];
                    for(int i = 0; i < square.Boxes.Length; i++)
                    {
                        for(int j = 0; j < square.Boxes[0].Length; j++)
                        {
                            string value = square.Boxes[i][j].Text;
                            if(value != "")
                            {
                                grid[3*(row)+j][(3 * col) + i] = Int16.Parse(value);
                            }
                        }
                    }
                }
            }

            return grid;
        }

        private void FillGrid(int[][] grid, Color color)
        {
            for (int row = 0; row < Squares.Length; row++)
            {
                for (int col = 0; col < Squares[0].Length; col++)
                {
                    CustomGroupBox square = Squares[row][col];
                    for (int i = 0; i < square.Boxes.Length; i++)
                    {
                        for (int j = 0; j < square.Boxes[0].Length; j++)
                        {
                            string value = square.Boxes[i][j].Text;
                            if (value == "")
                            {
                                square.Boxes[i][j].ForeColor = color;
                                square.Boxes[i][j].Text = grid[3 * (row) + j][(3 * col) + i].ToString();
                            }
                        }
                    }
                }
            }
        }
    }
}

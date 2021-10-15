using System;
using System.IO;

namespace SudokuSolver
{
    public static class Solver
    {
        public static int UNASSIGNED = 0;
        public static int N = 9;

        public unsafe static bool SolveSodoku(int[][] grid)
        {
            int row, col;
            if (!FindUnassignedLocation(grid, &row, &col)) { return true; }
            for(int num = 1; num <= N; num++)
            {
                if(IsSafe(grid, row, col, num))
                {
                    grid[row][col] = num;
                    if (SolveSodoku(grid))
                        return true;
                    grid[row][col] = UNASSIGNED;
                }
            }
            return false;
        }

        /**
         * Searched the grid to find an entry that is still unassigned
         */
        private unsafe static bool FindUnassignedLocation(int[][] grid, int* row, int* col)
        {
            for(*row = 0; *row < N; *row+=1)
            {
                for(*col = 0; *col < N; *col+=1)
                {
                    if(grid[*row][*col] == UNASSIGNED)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool UsedInRow(int[][] grid, int row, int num)
        {
            for(int col = 0; col < N; col++)
            {
                if(grid[row][col] == num)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool UsedInCol(int[][] grid, int col, int num)
        {
            for (int row = 0; row < N; row++)
            {
                if (grid[row][col] == num)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool UsedInBox(int[][] grid, int boxStartRow, int boxStartCol, int num)
        {
            for(int row = 0; row < 3; row++)
            {
                for(int col = 0; col < 3; col++)
                {
                    if (grid[row+boxStartRow][col+boxStartCol] == num)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool IsSafe(int[][] grid, int row, int col, int num)
        {
            return !UsedInRow(grid, row, num) && !UsedInCol(grid, col, num) && !UsedInBox(grid, row - row % 3, col - col % 3, num);
        }

        public static void PrintGrid(int[][] grid)
        {
            string output = "";
            foreach (int[] row in grid)
            {
                foreach (int col in row)
                {
                    output += $"{col} ";
                }
                output += "\n";
            }
            Console.WriteLine(output);
            using (StreamWriter file = new StreamWriter("output.txt"))
            {
                file.Write(output);
            }
        }

        public static void Main(string[] args)
        {
            int[][] grid = new int[][] { 
                        new int[] { 3, 0, 6, 5, 0, 8, 4, 0, 0},
                        new int[] { 5, 2, 0, 0, 0, 0, 0, 0, 0},
                        new int[] { 0, 8, 7, 0, 0, 0, 0, 3, 1},
                        new int[] { 0, 0, 3, 0, 1, 0, 0, 8, 0}, 
                        new int[] { 9, 0, 0, 8, 6, 3, 0, 0, 5}, 
                        new int[] { 0, 5, 0, 0, 9, 0, 6, 0, 0},
                        new int[] { 1, 3, 0, 0, 0, 0, 2, 5, 0},
                        new int[] { 0, 0, 0, 0, 0, 0, 0, 7, 4},
                        new int[] { 0, 0, 5, 2, 0, 6, 3, 0, 0} };

            if (SolveSodoku(grid))
            {
                PrintGrid(grid);
            }
            else { Console.WriteLine("No Solution exists"); }
        }
    }
}

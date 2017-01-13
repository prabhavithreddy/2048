using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Com.Factset
{
    public class Game
    {
        public int[,] Grid { get; private set; }
        private List<int> emptyCells;
        private int defaultNumber = 2;
        public int Score { get; private set; }
        public event EventHandler<ScoreEventArgs> CellsMoved;
        public IRandomNumber RandomNumber;
        public Game()
        {
            Grid = new int[4, 4];
            emptyCells = new List<int>();
            CellsMoved += CalculateScore;
            RandomNumber = new GenerateNumberUsingRandomClass();
            InitializeCells();
        }
        public Game(IRandomNumber randomNumber)
            : this()
        {
            this.RandomNumber = randomNumber;
        }
        public void InitializeCells()
        {
            int randomCell = RandomNumber.GetRandomNumber(Grid.Length - 1);
            AssignNumberToGrid(randomCell);
        }
        public void ClearGrid()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    Grid[i, j] = 0;
            Score = 0;
        }
        private void AssignNumberToGrid(int randomCell)
        {
            int row = randomCell / 4;
            int col = randomCell % 4;
            Grid[row, col] = defaultNumber;
        }
        public void MoveCellsDown()
        {
            bool isCellExistsAboveCurrentRow = false;
            for (int col = 0; col < 4; col++)
            {
                for (int row = 2; row >= 0; row--)
                {
                    int j = row;
                    while (j < 3 && (Grid[j + 1, col] == Grid[j, col] || Grid[j + 1, col] == 0))
                    {
                        if (Grid[j, col] > 0) isCellExistsAboveCurrentRow = true;
                        if (Grid[j + 1, col] > 0 && Grid[j, col] > 0)
                            CellsMoved(this, new ScoreEventArgs(Grid[j + 1, col] * 2, "Down"));
                        Grid[j + 1, col] += Grid[j, col];
                        Grid[j, col] = 0;
                        j++;
                    }
                }

            }
            RegisterEmptyCells();
            if (isCellExistsAboveCurrentRow)
                AssignRandomNumber();
            Debug("Down");
        }
        public void MoveCellsUp()
        {
            bool isCellExistsAboveCurrentRow = false;
            for (int col = 0; col < 4; col++)
            {
                for (int row = 1; row <= 3; row++)
                {
                    int j = row;
                    while (j > 0 && (Grid[j - 1, col] == Grid[j, col] || Grid[j - 1, col] == 0))
                    {
                        if (Grid[j, col] > 0) isCellExistsAboveCurrentRow = true;
                        if (Grid[j - 1, col] > 0 && Grid[j, col] > 0)
                            CellsMoved(this, new ScoreEventArgs(Grid[j - 1, col] * 2, "Up"));
                        Grid[j - 1, col] += Grid[j, col];
                        Grid[j, col] = 0;
                        j--;
                    }
                }

            }
            RegisterEmptyCells();
            if (isCellExistsAboveCurrentRow)
                AssignRandomNumber();
            Debug("Up");
        }
        public void MoveCellsLeft()
        {
            bool isCellExistsBelowCurrentRow = false;
            for (int row = 0; row < 4; row++)
                for (int col = 1; col <= 3; col++)
                {
                    int j = col;
                    while (j > 0 && (Grid[row, j - 1] == Grid[row, j] || Grid[row, j - 1] == 0))
                    {
                        if (Grid[row, j] > 0) isCellExistsBelowCurrentRow = true;
                        if (Grid[row, j - 1] > 0 && Grid[row, j] > 0)
                            CellsMoved(this, new ScoreEventArgs(Grid[row, j - 1] * 2, "Left"));
                        Grid[row, j - 1] += Grid[row, j];
                        Grid[row, j] = 0;
                        j--;
                    }
                }
            RegisterEmptyCells();
            if (isCellExistsBelowCurrentRow)
                AssignRandomNumber();
            Debug("Left");
        }
        public void MoveCellsRight()
        {
            bool isCellExistsBelowCurrentRow = false;
            for (int row = 0; row < 4; row++)
                for (int col = 2; col >= 0; col--)
                {
                    int j = col;
                    while (j < 3 && (Grid[row, j + 1] == Grid[row, j] || Grid[row, j + 1] == 0))
                    {
                        if (Grid[row, j] > 0) isCellExistsBelowCurrentRow = true;
                        if (Grid[row, j + 1] > 0 && Grid[row, j] > 0)
                            CellsMoved(this, new ScoreEventArgs(Grid[row, j + 1] * 2, "Right"));
                        Grid[row, j + 1] += Grid[row, j];
                        Grid[row, j] = 0;
                        j++;
                    }
                }
            RegisterEmptyCells();
            if (isCellExistsBelowCurrentRow)
                AssignRandomNumber();
            Debug("Right");
        }
        public string PrintGridState()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            for (int rows = 0; rows < 4; rows++)
            {
                if (rows == 1 || rows == 2 || rows == 3)
                    sb.AppendLine();
                for (int cols = 0; cols < 4; cols++)
                {
                    sb.Append(Grid[rows, cols]).Append(" ");
                }
            }
            sb.AppendLine();
            return sb.ToString();
        }
        private void AssignRandomNumber()
        {
            int randomNumber = RandomNumber.GetRandomNumber(emptyCells.Count - 1);
            int emptyCellPosition = emptyCells[randomNumber];
            AssignNumberToGrid(emptyCellPosition);
        }
        private void RegisterEmptyCells()
        {
            emptyCells.Clear();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    if (Grid[i, j] == 0)
                        emptyCells.Add(i * 4 + j);
                }
        }
        private void CalculateScore(object sender, ScoreEventArgs e)
        {
            if (Score == 0)
                File.WriteAllText("C:\\Debug\\Output.txt", "");
            Score += e.Value;
        }
        private void Debug(string direction)
        {
            File.AppendAllText("C:\\Debug\\Output.txt", direction);
            File.AppendAllText("C:\\Debug\\Output.txt", PrintGridState());
        }
    }
}

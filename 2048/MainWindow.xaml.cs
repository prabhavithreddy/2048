using MahApps.Metro.Controls;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Com.Factset
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private static Label[,] cells = new Label[4, 4];
        Game g;
        public MainWindow()
        {
            g = new Game();
            InitializeComponent();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    var b = cells[i, j] = new Label();
                    SetLabelStyle(b);
                    Grid.SetRow(b, i);
                    Grid.SetColumn(b, j);
                    mainGrid.Children.Add(b);
                }
            Render();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                g.MoveCellsDown();
            }
            if (e.Key == Key.Up)
            {
                g.MoveCellsUp();
            }
            if (e.Key == Key.Left)
            {
                g.MoveCellsLeft();
            }
            if (e.Key == Key.Right)
            {
                g.MoveCellsRight();
            }
            if (e.Key == Key.F5)
            {
                g.ClearGrid();
                g.InitializeCells();
            }
            Render();
        }
        private void Render()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    int value = g.Grid[i, j];
                    switch (value)
                    {
                        case 0: cells[i, j].Content = "";
                            cells[i, j].Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#CDC1B4"));
                            break;
                        case 2: SetLabelProperties(cells[i, j], value, "#776e65", "#eee4da");
                            break;
                        case 4: SetLabelProperties(cells[i, j], value, "#776e65", "#ede0c8");
                            break;
                        case 8: SetLabelProperties(cells[i, j], value, "#f9f6f2", "#f2b179");
                            break;
                        case 16: SetLabelProperties(cells[i, j], value, "#f9f6f2", "#f59563");
                            break;
                        case 32: SetLabelProperties(cells[i, j], value, "#f9f6f2", "#f67c5f");
                            break;
                        case 64: SetLabelProperties(cells[i, j], value, "#f9f6f2", "#f65e3b");
                            break;
                        case 128: SetLabelProperties(cells[i, j], value, "#f9f6f2", "#edcf72");
                            break;
                        case 256: SetLabelProperties(cells[i, j], value, "#f9f6f2", "#edcc61");
                            break;
                        case 512: SetLabelProperties(cells[i, j], value, "#f9f6f2", "#edc850");
                            break;
                        case 1024: SetLabelProperties(cells[i, j], value, "#f9f6f2", "#edc53f");
                            break;
                        case 2048: SetLabelProperties(cells[i, j], value, "#f9f6f2", "#edc22e");
                            break;
                        default: SetLabelProperties(cells[i, j], value, "#f9f6f2", "#3c3a32");
                            break;
                    }
                }
            this.Title = string.Format("{0}                 Score - {1}             New Game - {2}", 2048, g.Score, "F5");
        }
        private void SetLabelProperties(Label b, int value, string foregroundColor, string backgroundColor)
        {
            b.Content = value == 0 ? "" : value.ToString();
            b.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(backgroundColor));
            b.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom(foregroundColor));
        }
        private void SetLabelStyle(Label b)
        {
            Style style = this.FindResource("LabelTemplate") as Style;
            b.Style = style;
        }
    }
}

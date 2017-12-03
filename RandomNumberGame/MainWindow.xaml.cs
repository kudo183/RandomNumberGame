using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RandomNumberGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random _rng = new Random();
        bool _isGenerated = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        TextBlock CreateCell(int row, int column, string text, double fontSize)
        {
            var tg = new TransformGroup();
            tg.Children.Add(new RotateTransform()
            {
                Angle = _rng.Next(0, 73) * 5
            });
            tg.Children.Add(new TranslateTransform()
            {
                X = _rng.Next(-15, 15),
                Y = _rng.Next(-15, 15)
            });
            tg.Children.Add(new ScaleTransform()
            {
                ScaleX = 1 + (double)_rng.Next(1, 6) / 10,
                ScaleY = 1 + (double)_rng.Next(1, 6) / 10
            });

            var tb = new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                FontSize = fontSize,
                Text = text,
                RenderTransformOrigin = new Point(0.5, 0.5),
                RenderTransform = tg
            };

            Grid.SetRow(tb, row);
            Grid.SetColumn(tb, column);

            return tb;
        }

        private void GenerateClick(object sender, RoutedEventArgs e)
        {
            _isGenerated = true;

            int count = int.Parse(txtNumber.Text);

            int column = (int)Math.Floor(Math.Sqrt(count / 1.4));

            int row = count / column;

            if (row * column < count)
            {
                row = row + 1;
            }

            grid.Children.Clear();
            grid.ColumnDefinitions.Clear();
            grid.RowDefinitions.Clear();

            for (int i = 0; i < row; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < column; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            var array = _rng.CreateRandomIntArray(count);

            var fontSize = double.Parse(txtFontSize.Text);

            int index = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    grid.Children.Add(CreateCell(i, j, array[index].ToString(), fontSize));
                    index++;
                    if (index == count)
                        return;
                }
            }
        }

        private void PrintClick(object sender, RoutedEventArgs e)
        {
            if (_isGenerated == false)
            {
                MessageBox.Show("Nothing to print, please click Generate to generate content first.", "No content", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            PrintDialog dlg = new PrintDialog();

            if (dlg.ShowDialog().GetValueOrDefault())
            {
                dlg.PrintVisual(grid, Title);
            }
        }

        private void ResetClick(object sender, RoutedEventArgs e)
        {
            txtNumber.Text = "100";
            txtFontSize.Text = "20";
            txtPageWidth.Text = "21cm";
            txtPageHeight.Text = "29.7cm";
        }
    }
}

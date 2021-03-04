using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace coursWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            //Grid grid = new Grid();
            //grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(2,GridUnitType.Star)});
            //grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1,GridUnitType.Star)});
            //grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1,GridUnitType.Auto)});
            //grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            //grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            //Button b = new Button()
            //{
            //    Content = "B2"
            //};

            //maGrille.Children.Add(b);
            //Grid.SetRow(b, 0);
            //Grid.SetColumn(b, 0);
            //Content = grid;
            ChangeButton();
        }

        public void ChangeButton()
        {
            b1.Content = "test";
            b1.Click += ClickButton;
            ourTextBox.Text = "edit textbox";
        }


        public void ClickButton(object sender, RoutedEventArgs args)
        {
            if(sender is Button b)
            {
                MessageBox.Show(b.Content.ToString());
            }
            ourTextBlock.Text = ourTextBox.Text;
        }
    }
}

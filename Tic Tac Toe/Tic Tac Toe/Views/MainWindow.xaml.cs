using System;
using System.Linq;
using System.Windows;
using Tic_Tac_Toe.Boards;
using Tic_Tac_Toe.Pages;
using Tic_Tac_Toe.Refresheres;

namespace Tic_Tac_Toe.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private static bool _firstPlayer = true;
        public static bool FirstPlayer
        {
            get
            {
                return _firstPlayer;
            }
            set
            {
                _firstPlayer = value;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new BoardPage();
        }

        private void BoardButton_Click(object sender, RoutedEventArgs e)
        {
            if (Main.Content.ToString() != "Tic_Tac_Toe.Pages.BoardPage")
            {
                Main.Dispatcher.Invoke(new Action(() => { Main.Content = new BoardPage(); }));
            }
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            if (Main.Content.ToString() != "Tic_Tac_Toe.Pages.SettingsPage")
            {

                Main.Content = new SettingsPage();
            }
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            var cell = Board.Cells.FirstOrDefault(x => x.Sign != null);
            if (cell != null) UpdateBoard.Update();
            Main.Content = new BoardPage();
        }
    }
}

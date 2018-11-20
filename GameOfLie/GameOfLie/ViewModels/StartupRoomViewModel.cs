using GameOfLie.Models;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GameOfLie.ViewModels
{
    public class StartupRoomViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public StartupRoomViewModel(ContentPage masterPage)
            :this(masterPage, new ConfigurationModel())
        {
        }

        public StartupRoomViewModel(ContentPage masterPage, ConfigurationModel configurationModel)
        {
            _masterPage = masterPage;
            _configurationModel = configurationModel;
        }

        private ContentPage _masterPage;
        private ConfigurationModel _configurationModel;

        public int RowCounts
        {
            get => _configurationModel.RowCounts;
            set { _configurationModel.RowCounts = value; OnPropertyChanged(); }
        }

        public int ColumnCounts
        {
            get => _configurationModel.ColumnCounts;
            set { _configurationModel.ColumnCounts = value; OnPropertyChanged(); }
        }

        public SKColor AliveColor
        {
            get => _configurationModel.AliveColor;
            set { _configurationModel.AliveColor = value; OnPropertyChanged(); }
        }

        public string NavButtonText { get => "Start Game Of Life"; }

        Command _navigateToGame;
        public Command NavigateToGame
        {
            get
            {
                return _navigateToGame ?? (_navigateToGame = new Command(async () => await ExecuteNavigationCommand()));
            }
        }

        async Task ExecuteNavigationCommand()
        {
            await _masterPage.Navigation.PushAsync(new GameRoom(_configurationModel));
        }
    }
}

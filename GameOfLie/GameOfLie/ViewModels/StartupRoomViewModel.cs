using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
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

        private int rowCounts;
        public int RowCounts
        {
            get => rowCounts;
            set { rowCounts = value; OnPropertyChanged(); }
        }

        private int columnCounts;
        public int ColumnCounts
        {
            get => columnCounts;
            set { columnCounts = value; OnPropertyChanged(); }
        }

        private Color deadColor;

        public Color DeadColor
        {
            get => deadColor;
            set { deadColor = value; OnPropertyChanged(); }
        }

        private Color aliveColor;

        public Color AliveColor
        {
            get => aliveColor;
            set { aliveColor = value; OnPropertyChanged(); }
        }
    }
}

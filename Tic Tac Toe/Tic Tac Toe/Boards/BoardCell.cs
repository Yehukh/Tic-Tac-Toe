using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Tic_Tac_Toe.Boards
{
    public class BoardCell : INotifyPropertyChanged
    {
        private string _sign;
        private bool _canSelect = true;
        private bool _canModify = true;

        public string Sign
        {
            get { return _sign; }
            set
            {
                _sign = value;
                if (value != null)
                {
                    CanSelect = false;
                }
                OnPropertyChanged();
            }
        }

        public bool CanSelect
        {
            get { return _canSelect; }
            set
            {
                _canSelect = value;
                OnPropertyChanged();
            }
        }
        public bool CanModify
        {
            get { return _canModify; }
            set
            {
                _canModify = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

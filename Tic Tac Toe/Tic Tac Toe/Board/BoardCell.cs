using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    public class BoardCell : INotifyPropertyChanged
    {
        private string _sign;
        private bool _canSelect = true;

        public string Sign
        {
            get { return _sign; }
            set
            {
                _sign = value;
                if (value != null)
                    CanSelect = false;
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

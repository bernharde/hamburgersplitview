using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NavPaneSample.ViewModels
{
    public class NavigationItem : INotifyPropertyChanged
    {
        string text;

        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                OnPropertyChanged();
            }
        }

        string mdlText;

        public string MdlText
        {
            get
            {
                return mdlText;
            }

            set
            {
                mdlText = value;
                OnPropertyChanged();
            }
        }

        bool isSelected;

        public bool IsSelected
        {
            get
            {
                return isSelected;
            }

            set
            {
                isSelected = value;
                OnPropertyChanged();
            }
        }

        public Action<NavigationItem> Action
        {
            get
            {
                return action;
            }

            set
            {
                action = value;
            }
        }

        Action<NavigationItem> action;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Execute()
        {
            Action(this);
        }
    }
}

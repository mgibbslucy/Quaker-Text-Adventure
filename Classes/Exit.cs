using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quaker.Classes
{
    public class Exit
    {
        private String direction = "NULL";
        private String name = "NULL";
        private String text = "NULL";
        private String path = "NULL";

        public String Direction
        {
            get => direction;
            set { direction = value; RaisePropertyChanged("Direction");  }
        }
        public String Name
        {
            get => name;
            set { name = value; RaisePropertyChanged("Name"); }
        }
        public String Text
        {
            get => text;
            set { text = value; RaisePropertyChanged("Text"); }
        }
        public String Path
        {
            get => path;
            set { path = value; RaisePropertyChanged("Path"); }
        }
        #region NOTIFY METHODS

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        #endregion
    }
}

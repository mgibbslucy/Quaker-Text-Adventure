using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quaker.Classes
{
    public class Room
    {
        List<Exit> exits = new List<Exit>();
        String picture = (Directory.GetCurrentDirectory()+"\\Images\\test.png");
        String text = "NULL";
        String name = "NULL";

        public Room() { }

        public Room(String flag)
        {
            Exit temp = new Exit();
            temp.Direction = "North";
            temp.Path = "XMLFiles/textNext.XML";
            temp.Name = "Tomato Hut";
            temp.Text = "Wait, I've got it! You're a Libra. You're Jewish? Love your nails. Your place or mine?";

            
            Exits = new List<Exit>() { temp };
        }
        public List<Exit> Exits
        {
            get => exits;
            set { exits = value; RaisePropertyChanged("Exits"); }
        }
        public String Picture
        {
            get => picture;
            set { picture = value; RaisePropertyChanged("Picture"); }
        }
        public String Text
        {
            get => text;
            set { text = value; RaisePropertyChanged("Text"); }
        }
        public String Name
        {
            get => name;
            set { name = value; RaisePropertyChanged("Name"); }
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

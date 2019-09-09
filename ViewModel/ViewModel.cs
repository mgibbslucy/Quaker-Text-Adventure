using Quaker.Classes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Input;
using XmlDict;
namespace Quaker.ViewModels
{
    public class ViewModel : INotifyPropertyChanged
    {
        private DelegateCommand<ViewModel> _inputHandleCommand;
        private XMLHandler handler = new XMLHandler();
        private Room currentRoom = new Room(" ");
        private XmlDictNodeList exitList = new XmlDictNodeList();
        private String picture = Directory.GetCurrentDirectory() + "\\Images\\test.png";
        private String outputText = "";
        private String inputText = "";
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        

        public ViewModel()
        {
            CurrentRoom = Handler.LoadRoom(Directory.GetCurrentDirectory() + "\\XML Files\\Intro.XML", CurrentRoom);
        }

        public XMLHandler Handler
        {
            get => handler;
            set { handler = value; OnPropertyChanged("Handler"); }
        }
        public Room CurrentRoom
        {
            get => currentRoom;
            set
            {
                currentRoom = value;
                OutputText = PopulateOutputText();
                Picture = CurrentRoom.Picture;
                player = new System.Media.SoundPlayer(CurrentRoom.Sounds[0].Path);
                player.PlayLooping();
                OnPropertyChanged("OutputText");
            }
        }
        public XmlDictNodeList ExitList
        {
            get => exitList;
            set { exitList = value; OnPropertyChanged("ExitList"); }
        }
        public String Picture
        {
            get => picture;
            set { picture = value; OnPropertyChanged("Picture"); }
        }
        public String OutputText
        {
            get => outputText;
            set { outputText = value; OnPropertyChanged("OutputText"); }
        }

        public String InputText
        {
            get => inputText;
            set
            {
                inputText = value;
                OnPropertyChanged("InputText");
            }
        }

        #region private methods

        private String PopulateOutputText()
        {
            OutputText = "";

            OutputText += CurrentRoom.Name;
            OutputText += "\n\n" + CurrentRoom.Text;

            OutputText += "\n\n\n\nPaths you can go";

            foreach (Exit x in CurrentRoom.Exits)
            {
                OutputText += "\n\n\t\t" + x.Direction + ": \t\t" + x.Name;
            }

            return OutputText;
        }

        #endregion
        #region Commands
        public ICommand InputHandleCommand
        {
            get
            {
                return _inputHandleCommand ??
                       (_inputHandleCommand = new DelegateCommand<ViewModel>(HandleInput));
            }
        }
        #endregion
        #region delegates

        public void HandleInput(ViewModel obj)
        {
            var temp = CurrentRoom.Exits.Where(a => (a as Exit).Direction == InputText);
            if (temp.Any())
            {
                CurrentRoom = Handler.LoadRoom((temp.First() as Exit).Path, currentRoom);
            }

            InputText = "";
            OnPropertyChanged("InputText");
        }

        #endregion


        #region Notify Methods

        // Create the OnPropertyChanged method to raise the event 
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
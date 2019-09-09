using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlDict;

namespace Quaker.Classes
{
    public class XMLHandler
    {
        public Room LoadRoom(String path, Room currentRoom)
        {
            XmlDictNode temp = new XmlDictNode(File.ReadAllText(path));
            currentRoom.Exits = new List<Exit>();
            currentRoom.Sounds = new List<Sound>();
            var tempExit = new Exit();
            Sound tempSound = new Sound();

            currentRoom.Picture = temp["Picture"].Attributes["Path"].Value;

            foreach(var node in temp["Exit"])
            {
                tempExit.Name = node.Attributes["Name"].Value;
                tempExit.Text = node.Attributes["Text"].Value;
                tempExit.Path = node.Attributes["Path"].Value;
                tempExit.Direction = node.Attributes["Direction"].Value;

                currentRoom.Exits.Add(tempExit);
                tempExit = new Exit();
            }

            foreach (var node in temp["Sound"])
            {
                tempSound.Type = node.Attributes["Type"].Value;
                tempSound.Path = node.Text;

                currentRoom.Sounds.Add(tempSound);
                tempSound = new Sound();
            }

            currentRoom.Name = temp["Title"].Text;
            currentRoom.Text = temp["Text"].Text;

            return currentRoom;
        }
    }
}

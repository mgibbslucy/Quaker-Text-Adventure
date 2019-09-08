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
            var tempExit = new Exit();

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

            currentRoom.Name = temp["Title"].Text;
            currentRoom.Text = temp["Text"].Text;


            return currentRoom;
        }
    }
}

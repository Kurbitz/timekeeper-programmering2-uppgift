using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Kurbitz_TimeManager
{
    public class SaveLoad
    {
        string path = "C:\\C# Files\\data.dat";


        public void SaveToFile(Project project, string fileName = "Time_Manager_Project", bool append = false)
        {
            using (Stream stream = File.Open(path, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, project);
            }
        }

        public Project LoadFromFile(string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (Project)binaryFormatter.Deserialize(stream);
            }            
        }
    }
}

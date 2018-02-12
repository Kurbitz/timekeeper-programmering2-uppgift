using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Kurbitz_TimeManager
{
    class SaveLoad
    {
        string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "TimeManager", "project.dat");

        public void SaveToFile(Project project)
        {
            using(Stream stream = File.Open(path, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(stream, project);
            }
        }

        public Project LoadFromFile()
        {
            Project project = null;
            try
            {
                using(Stream stream = File.Open(path, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    project = (Project)bf.Deserialize(stream);
                }
            }
            catch(IOException e)
            {
                project = new Project("Untitled");
            }
            return project;
        }
    }
}

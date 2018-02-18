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
        private const string DEFAULT_FILENAME = "Time_Manager_Project";
        string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TimeManager") + DEFAULT_FILENAME + ".xml";
        private Project project = new Project();


        public void SaveToFile(Project project)
        {
            System.IO.StreamWriter sw = System.IO.File.CreateText(path);
           
            if (project.GetType().IsSerializable)
            {
                System.Xml.Serialization.XmlSerializer xsSerializer = new System.Xml.Serialization.XmlSerializer(project.GetType());
                xsSerializer.Serialize(sw, project);
                sw.Close();
            }
            //fileName = project.Name + ".dat";
            //using (Stream stream = File.Open(path, FileMode.Create, FileAccess.Write))
            //{
            //    BinaryFormatter bf = new BinaryFormatter();
            //    bf.Serialize(stream, project);
            //}
        }

        public Project LoadFromFile()
        {
            if (System.IO.File.Exists(path))
            {
                System.IO.StreamReader sr = System.IO.File.OpenText(path);
                System.Xml.Serialization.XmlSerializer xsSerializer = new System.Xml.Serialization.XmlSerializer(project.GetType());
                object loadData = xsSerializer.Deserialize(sr);
                project = (Project)loadData;
                sr.Close();
                return project;
            }
            return project;
            //Project project = null;
            //try
            //{
            //    using(Stream stream = File.Open(path, FileMode.Open))
            //    {
            //        BinaryFormatter bf = new BinaryFormatter();
            //        project = (Project)bf.Deserialize(stream);
            //    }
            //}
            //catch(IOException e)
            //{
            //    project = new Project("Untitled");
            //}
            //return project;
        }
    }
}

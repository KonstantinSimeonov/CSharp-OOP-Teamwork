using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;


namespace BinarySerialization
{
  public class BinarySerialization
    {

        public string fileContent;


        public void Serialize(string pathFrom, string pathTo)
        {
            fileContent = File.ReadAllText(pathFrom);
            var stream = new FileStream(pathTo, FileMode.OpenOrCreate);
            var binaryFormatter = new BinaryFormatter();

            binaryFormatter.Serialize(stream, fileContent);
            stream.Close();
        }

        public string Deserialize(string path)
        {
            var stream = new FileStream(path, FileMode.Open);
            var binaryFormatter = new BinaryFormatter();

            string result = (string)binaryFormatter.Deserialize(stream);
            stream.Close();
            return result;

        }

    }
}

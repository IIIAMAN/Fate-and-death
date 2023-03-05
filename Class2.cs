using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PraKTICHESKAYATWOOOOO
{
    internal class Class2
    {
        public static void MySerialize<T>(T zametochi)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string json = JsonConvert.SerializeObject(zametochi);
            File.WriteAllText(desktop + "\\Zametka.json", json);
        }
        public static T MyDeserialize<T>()
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string json = File.ReadAllText(desktop + "\\Zametka.json");
            T zametochi = JsonConvert.DeserializeObject<T>(json);
            return zametochi;
        }
    }
}

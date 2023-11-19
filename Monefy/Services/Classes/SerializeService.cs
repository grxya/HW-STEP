using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Monefy.Services.Interfaces;

namespace Monefy.Services.Classes
{
    public class SerializeService : ISerializeService
    {
        public ObservableCollection<T> Deserialize<T>(string filepath)
        {
            using FileStream fs = new(filepath, FileMode.OpenOrCreate);
            using StreamReader sr = new(fs);

            string? json = sr.ReadToEnd();

            if (string.IsNullOrEmpty(json))
            {
                return null;
            }

            return JsonSerializer.Deserialize<ObservableCollection<T>>(json);
        }

        public void Serialize<T>(ObservableCollection<T> data, string filepath)
        {
            using FileStream fs = new(filepath, FileMode.OpenOrCreate);
            using StreamWriter sw = new(fs);

            string json = JsonSerializer.Serialize(data);

            sw.Write(json);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace File
{
    public class ReadFile
    {
        public static List<Voo> ExtrairDados(string pathFile)
        {
            StreamReader reader = new(pathFile);
            var jsonString = reader.ReadToEnd();
            var dados = JsonConvert.DeserializeObject<List<Voo>>(jsonString) as List<Voo>;

            return dados ?? null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace JsonCMS.Areas.Manager.Models
{
    public class JsonHandler
    {
        private string readPath;
        private string writePath;

        public JsonHandler(string _readPath, string _writePath)
        {
            readPath = _readPath;
            writePath = _writePath;
        }

        public dynamic readJsonFile()
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject(System.IO.File.ReadAllText(readPath));
        }

        public void writeJsonFile(dynamic jsonToWrite)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonToWrite, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(writePath, output);
        }
    }
}
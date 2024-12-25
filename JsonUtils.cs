using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class JsonUtils
    {
        public static JsonUtils Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new JsonUtils();
                return _instance;
            }
        }

        private static JsonUtils _instance;
        private JsonUtils() { }

        public bool GetFromFile<T> (string path, out T? @object) where T : class
        {
            @object = null;

            try
            {
                @object = JsonSerializer.Deserialize<T>(File.ReadAllText(path));
            }

            catch
            {
                return false;
            }

            return true;
        }

        public bool SaveToFile<T>(T @object, string path)
        {
            try
            {
                File.WriteAllText(path, JsonSerializer.Serialize(@object));
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}

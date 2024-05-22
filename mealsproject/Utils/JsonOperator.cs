namespace MealsProject.Utils
{
    internal class JsonOperator                //internal class accessible only within files in the same assembly
    {
        private readonly string _filename;
        public JsonOperator(string fileName) 
        { 
            this._filename =fileName;
        }

        public bool WriteToJson(object obj)
        {
            try
            {
                var jsonString = System.Text.Json.JsonSerializer.Serialize(obj);
                File.WriteAllText(this._filename, jsonString);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public string ReadFromJson()
        {
            try
            {
                var jsonString = File.ReadAllText(this._filename);
                return jsonString;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return string.Empty;
            }
        }
    }
}

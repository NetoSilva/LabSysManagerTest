namespace AtualizadorClientes.Helpers
{
    public static class JsonHelper
    {
        public static string RemoveWcfReturnNode(string json)
        {
            var s = json.Replace("{\"return\":", "");
            s = s.Remove(s.Length - 1);
            return s;
        }
    }
}

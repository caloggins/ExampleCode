namespace QueryClasses
{
    using System.Text;

    public static class ToStringExtension
    {
        public static string PrintProperties<TThing>(this TThing o)
        {
            var infos = typeof(TThing).GetProperties();

            var sb = new StringBuilder();

            foreach (var info in infos)
            {
                var value = info.GetValue(o, null) ?? "(null)";
                sb.AppendLine(info.Name + ": " + value);
            }

            return sb.ToString();
        }
    }
}
namespace AutmapperLists
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AutoMapper;

    using FizzWare.NBuilder;

    class Program
    {
        static void Main()
        {
            try
            {
                var ins = Builder<In>.CreateListOfSize(5).Build();

                Mapper.CreateMap<In, Out>();

                var outs = Mapper.Map<IEnumerable<In>, IEnumerable<Out>>(ins);
                outs.ToList().ForEach(Console.WriteLine);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }

    public abstract class Direction
    {
        public override string ToString()
        {
            var propertyValues = (
                from p in GetType().GetProperties()
                let v = p.GetValue(this, null) ?? "(null)"
                select p.Name + ": " + v
                );
            var sb = new StringBuilder();
            sb.AppendLine(string.Format("--- {0} ---", GetType().Name));
            propertyValues.ToList().ForEach(s => sb.AppendLine(s));
            return sb.ToString();
        }
    }

    public class In : Direction
    {
        public int Count { get; set; }

        public Guid Id { get; set; }
    }

    public class Out : Direction
    {
        public int Count { get; set; }

        public Guid Id { get; set; }
    }
}

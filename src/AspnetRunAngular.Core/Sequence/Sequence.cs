namespace AspnetRunAngular.Core.Sequence
{
    public class Sequence
    {
        public Sequence(string name, string prefix, string format = "{0:00000}")
        {
            Name = name;
            Prefix = prefix;
            Format = format;
        }

        public string Name { get; }
        public string Prefix { get; }
        public string Format { get; }

        public readonly static Sequence OrderSequence = new Sequence("OrderSequence", "ORD");
    }
}

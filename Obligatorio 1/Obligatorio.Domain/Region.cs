namespace Obligatorio.Domain
{
    public class Region
    {
        public string Name { get; set; }

        public Region()
        {
            Name = "Default Name";
        }

        public override bool Equals(object obj)
        {
            return obj is Region region &&
                   Name == region.Name;
        }
    }
}

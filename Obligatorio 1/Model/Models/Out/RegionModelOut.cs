using Obligatorio.Domain;

namespace Model.Models.Out
{
    public class RegionModelOut
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public RegionModelOut()
        {

        }

        public RegionModelOut(Region region)
        {
            this.Id = region.Id;
            this.Name = region.Name;
        }

        public override bool Equals(object obj)
        {
            return obj is RegionModelOut model &&
                   Name == model.Name &&
                   Id == model.Id;
        }
    }
}

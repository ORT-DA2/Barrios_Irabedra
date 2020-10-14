using Obligatorio.Domain;

namespace Model.Models.In
{
    public class RegionModelIn
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public RegionModelIn()
        {
        }

        public RegionModelIn(Region region)
        {
            this.Name = region.Name;
            this.Id = region.Id;
        }

        public override bool Equals(object obj)
        {
            return obj is RegionModelIn model &&
                   Name == model.Name &&
                   Id == model.Id;
        }

        public Region ToEntity()
        {
            Region region = new Region();
            region.Name = this.Name;
            return region;
        }
    }
}

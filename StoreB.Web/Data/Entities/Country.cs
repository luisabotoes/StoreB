namespace StoreB.Web.Data.Entities
{
    public class Country : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FlagImg { get; set; }
    }
}

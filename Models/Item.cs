namespace D2R_Items.Models
{
    public class Item
    {
       public string Name { get; set; }
        public string ItemClass { get; set; }
        public IEnumerable<string> ItemTypes { get; set; }
        public string Description { get; set; }
    }
}

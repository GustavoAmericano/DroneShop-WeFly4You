namespace Droneshop.Core.Entity
{
    public class Filter
    {
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public bool IncludeOtherEntity { get; set; }
        public bool IsSortedDescendingByPrice { get; set; }
        public int ManufacturerId { get; set; }
    }
}
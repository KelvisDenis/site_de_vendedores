namespace Site_1.Models.Extension
{
    public class SellerFormViewModel
    {
        public Seller seller { get; set; }
        public ICollection<Departament> departaments { get; set; }
    }
}

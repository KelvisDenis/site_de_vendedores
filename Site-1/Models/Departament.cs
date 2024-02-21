using System.ComponentModel.DataAnnotations;

namespace Site_1.Models
{
    public class Departament
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public ICollection<Seller> Sellers{ get; set; } = new List<Seller>();
        public Departament() { }
        public Departament(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
        public void AddSeller(Seller seller) { 
        Sellers.Add(seller);
        }
        public void RemoveSeller(Seller seller) { 
        Sellers.Remove(seller);
        }
        public double TotalSales(DateTime init, DateTime final) {
            return Sellers.Sum(sr => sr.TotalSales(init, final));
        }
    }
}

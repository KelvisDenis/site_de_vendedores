using System.ComponentModel.DataAnnotations;

namespace Site_1.Models
{
    public class Seller
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(40, MinimumLength =6)]
        public string? Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }
        
        [Required]
        [Range(500, 1000000000)]
        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; }
        public Departament Departament { get; set; }
        public int DepartamentId { get; set; }
        public ICollection<SellesRecord> Sellers { get; set; } = new List<SellesRecord>();

        public Seller() { }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Departament departament)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Departament = departament;
        }
        public void Add(SellesRecord record) { 
        Sellers.Add(record);
        }
        public void Remove(SellesRecord record) { 
        Sellers.Remove(record);
        }
        public double TotalSales(DateTime init, DateTime final)
        {
            return Sellers.Where(sr => sr.Date >= init && sr.Date <= final).Sum(sr => sr.Amout);
        }
    }
}

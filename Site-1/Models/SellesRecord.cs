using Site_1.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Site_1.Models
{
    public class SellesRecord
    {
        [Key]
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0: dd//MM//yyyy}")]
        public DateTime Date { get; set; }

        [DisplayFormat(DataFormatString = "{0: F2}")]
        public double Amout { get; set; }
        public SaleStatus Status { get; set; }
        [Key]
        public Seller? Seller { get; set; }

        public SellesRecord() { }
        public SellesRecord(int id, DateTime date, double amout, SaleStatus status, Seller seller)
        {
            Id = id;
            Date = date;
            Amout = amout;
            Status = status;
            Seller = seller;
        }
    }
}

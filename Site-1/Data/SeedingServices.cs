using Site_1.Models;
using Site_1.Models.Enums;

namespace Site_1.Data
{
    public class SeedingServices
    {
        private Site_1Context _context;

        public SeedingServices(Site_1Context context)
        {
            _context = context;
        }
        public void Seed()
        {
            if (
                _context.Departament.Any() ||
                _context.Sellers.Any() ||
                _context.SellesRecords.Any()) 
            {
                return;
            }
            Departament departament1 = new Departament(1, "Computers");
            Departament departament2 = new Departament(2, "Eletronic");
            Departament departament3 = new Departament(3, "Fashion");
            Departament departament4 = new Departament(4, "Books");

            Seller s1 = new Seller
            {
                Id = 1,
                Email = "Bob@gmail.com",
                Name = "Bob",
                BaseSalary = 1000.0,
                BirthDate = new DateTime(1998, 5, 21),
                Departament = departament1
            };
            Seller s2 = new Seller
            {
                Id = 2,
                Email = "teste@gmail.com",
                Name = "aniel",
                BaseSalary = 2000.0,
                BirthDate = new DateTime(1998, 5, 21),
                Departament = departament2
            }; Seller s3 = new Seller
            {
                Id = 3,
                Email = "teste3@gmail.com",
                Name = "Silvio",
                BaseSalary = 1200.0,
                BirthDate = new DateTime(2000, 7, 1),
                Departament = departament3
            }; Seller s4 = new Seller
            {
                Id = 4,
                Email = "teste4gmail.com",
                Name = "francisco",
                BaseSalary = 1500.0,
                BirthDate = new DateTime(1999, 3, 2),
                Departament = departament4
            };
            SellesRecord r1 = new SellesRecord(1, new DateTime(2024, 09, 25), 11000.0, SaleStatus.Billed, s1);
            SellesRecord r2 = new SellesRecord(2, new DateTime(2024, 09, 4), 7000.0, SaleStatus.Billed, s3);
            SellesRecord r3 = new SellesRecord(3, new DateTime(2024, 09, 13), 4000.0, SaleStatus.Canceled, s4);
            SellesRecord r4 = new SellesRecord(4, new DateTime(2024, 09, 1), 8000.0, SaleStatus.Billed, s1);
            SellesRecord r5 = new SellesRecord(5, new DateTime(2024, 09, 21), 3000.0, SaleStatus.Billed, s3);
            SellesRecord r6 = new SellesRecord(6, new DateTime(2024, 09, 15), 2000.0, SaleStatus.Billed, s1);
            SellesRecord r7 = new SellesRecord(7, new DateTime(2024, 09, 28), 13000.0, SaleStatus.Billed, s2);
            SellesRecord r8 = new SellesRecord(8, new DateTime(2024, 09, 11), 4000.0, SaleStatus.Billed, s4);
            SellesRecord r9 = new SellesRecord(9, new DateTime(2024, 09, 14), 11000.0, SaleStatus.Pending, s3);
            SellesRecord r10 = new SellesRecord(10, new DateTime(2024, 09, 7), 9000.0, SaleStatus.Billed, s2);
            SellesRecord r11 = new SellesRecord(11, new DateTime(2024, 09, 13), 6000.0, SaleStatus.Billed, s2);
            SellesRecord r12 = new SellesRecord(12, new DateTime(2024, 09, 25), 7000.0, SaleStatus.Pending, s3);
            SellesRecord r13 = new SellesRecord(13, new DateTime(2024, 09, 29), 10000.0, SaleStatus.Billed, s4);
            SellesRecord r14 = new SellesRecord(14, new DateTime(2024, 09, 4), 3000.0, SaleStatus.Billed, s1);
            SellesRecord r15 = new SellesRecord(15, new DateTime(2024, 09, 12), 4000.0, SaleStatus.Billed, s1);
            SellesRecord r16 = new SellesRecord(16, new DateTime(2024, 10, 5), 2000.0, SaleStatus.Billed, s4);
            SellesRecord r17 = new SellesRecord(17, new DateTime(2024, 10, 1), 12000.0, SaleStatus.Billed, s1);
            SellesRecord r18 = new SellesRecord(18, new DateTime(2024, 10, 24), 6000.0, SaleStatus.Billed, s3);
            SellesRecord r19 = new SellesRecord(19, new DateTime(2024, 10, 22), 8000.0, SaleStatus.Billed, s2);
            SellesRecord r20 = new SellesRecord(20, new DateTime(2024, 10, 15), 8000.0, SaleStatus.Billed, s1);
            SellesRecord r21 = new SellesRecord(21, new DateTime(2024, 10, 17), 9000.0, SaleStatus.Billed, s2);
            SellesRecord r22 = new SellesRecord(22, new DateTime(2024, 10, 24), 4000.0, SaleStatus.Billed, s4);
            SellesRecord r23 = new SellesRecord(23, new DateTime(2024, 10, 19), 11000.0, SaleStatus.Canceled, s2);
            SellesRecord r24 = new SellesRecord(24, new DateTime(2024, 10, 12), 8000.0, SaleStatus.Billed, s4);
            SellesRecord r25 = new SellesRecord(25, new DateTime(2024, 10, 31), 7000.0, SaleStatus.Billed, s3);
            SellesRecord r26 = new SellesRecord(26, new DateTime(2024, 10, 6), 5000.0, SaleStatus.Billed, s4);
            SellesRecord r27 = new SellesRecord(27, new DateTime(2024, 10, 13), 9000.0, SaleStatus.Pending, s1);
            SellesRecord r28 = new SellesRecord(28, new DateTime(2024, 10, 7), 4000.0, SaleStatus.Billed, s3);
            SellesRecord r29 = new SellesRecord(29, new DateTime(2024, 10, 23), 12000.0, SaleStatus.Billed, s4);
            SellesRecord r30 = new SellesRecord(30, new DateTime(2024, 10, 12), 5000.0, SaleStatus.Billed, s2);

            _context.Departament.AddRange(
                departament1, departament2, departament3, departament4
                );
            _context.Sellers.AddRange(
                s1, s2, s3, s4
                );
            _context.SellesRecords.AddRange(
                r1,r2, r3,r4,r5,r6,r7,r8,r9,r10,r11, r12,r13, r14,r15,r16,r17,r18, r19, r20, r21, r22,
                r23, r24,  r25,r26, r27,r28, r29, r30
                );
            _context.SaveChanges();
        }
    }
}

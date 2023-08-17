using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Models;
using WebMVC.Models.Enums;

namespace WebMVC.Data
{
    public class SeedingService
    {
        private WebMVCContext _context;

        public SeedingService(WebMVCContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any()|| _context.Seller.Any() || _context.SalesRecord.Any())
            {
                return;
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Books");

            Seller s1 = new Seller(1,"Teste","bob@gmail.com", new DateTime(1991,3,5), 1000.00, d1);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2023, 08, 17), 110000.0, SaleStatus.Canceled, s1);

            _context.Department.AddRange(d1, d2);
            _context.Seller.AddRange(s1);
            _context.SalesRecord.AddRange(r1);

            _context.SaveChanges();
        }
    }
}

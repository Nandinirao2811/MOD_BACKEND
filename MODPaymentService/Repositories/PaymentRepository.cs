using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MODPaymentService.Models;
using MODPaymentService.Context;

namespace MODPaymentService.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentContext _context;
        public PaymentRepository(PaymentContext context)
        {
            _context = context;
        }

        public void AddPayment(Payment item)
        {
            _context.Payments.Add(item);
            _context.SaveChanges();
        }
       
        public List<Payment> GetAllPayments()
        {
            return _context.Payments.ToList();
        }
    }
}

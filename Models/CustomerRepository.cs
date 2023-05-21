namespace HimlayanEverestInsurance.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext context;

        public CustomerRepository(AppDbContext _context)
        {
            context = _context;
        }
        public void Add(Customer ctr)
        {
            context.Customers.Add(ctr);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            var customer = context.Customers.Find(Id);
            if(customer != null) 
            { 
               context.Customers.Remove(customer);  
                context.SaveChanges();
            
            }
        }

        public Customer Get(int Id)
        {
            


                Customer ctr = context.Customers.FirstOrDefault(c => c.Customer_Id==Id);
            if (ctr != null)
            {
                return ctr;

            }
            else
                return null;
            
        
            }

        public IEnumerable<Customer> GetAll()
        {
            return context.Customers.ToList();
            
        }

        public void Update(Customer ctr)
        {
           if(ctr!=null)
            {
                var customer = context.Customers.Find(ctr.Customer_Id);
               
                if(customer != null) 
                 {
                    customer.Customer_Name = ctr.Customer_Name;
                    customer.Customer_Phone = ctr.Customer_Phone;   
                    customer.Customer_Email= ctr.Customer_Email; 
                   var customerst = context.Customers.Update(customer);
                    customerst.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();



                }

            }
        }
    }
}

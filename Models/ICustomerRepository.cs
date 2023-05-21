namespace HimlayanEverestInsurance.Models
{
   public interface  ICustomerRepository
    {

        void Add(Customer ctr);

        void Update(Customer ctr);
        
        void Delete(int Id);

        IEnumerable<Customer> GetAll();

        Customer Get(int Id);






    }
}

using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //AdCar();
            //AdBrand();
            //  AddCustomer();
            // AddUser();

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental = new Rental { CarId = 1, CustomerId = 1, RentDate = new DateTime(2022, 09, 07), ReturnDate = new DateTime(2022, 09, 15) };
            rentalManager.Add(rental);
        }

        private static void AddUser()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            User user = new User { Email = "yusuf1@gmail.com", FirstName = "yusuf1", LastName = "ad222", Password = "123123" };
            userManager.Update(user);
        }

        private static void AddCustomer()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Customer customer = new Customer { CompanyName = "vanHavaYolları" };
            customerManager.Add(customer);
        }

        private static void AdBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand = new Brand();
            brand.BrandName = "Q5599";

            Console.WriteLine("---------------------");
            brandManager.Add(brand);
            Console.WriteLine("---------------------");

            foreach (var item in brandManager.GetAll().Data)
            {
                Console.WriteLine(item.BrandName, item.BrandId.ToString());
            }
        }

        private static void AdCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            if (result.Succes == true)
            {
                Console.WriteLine(result.Message);
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.CarName, item.Description);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }

}


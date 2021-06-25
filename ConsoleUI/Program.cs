using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFreamwork;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IProjectService projectService = new ProjectManager(new EfProjectDal());
            //projectService.Add(new Project
            //{
            //    Name = "a"
            //});
            foreach (var project in
            projectService.GetAll().Data)
            {
                Console.WriteLine(project.Name);
            }


            Console.WriteLine("Method Success!!!");
        }

        private static void ServiceGetAll()
        {
            ISrvService srvService = new ServiceManager(new EfServiceDal());
            foreach (var service in srvService.GetAll().Data)
            {
                Console.WriteLine(service.Name);
            }
        }

        private static void CustomerGetAll()
        {
            CustomerManager customerService = new CustomerManager(new EfCustomerDal());

            foreach (var customer in customerService.GetAll().Data)
            {
                Console.WriteLine(customer.FirstName + " " + customer.LastName);
            }
        }
    }
}

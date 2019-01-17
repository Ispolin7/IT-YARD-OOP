using System;
using IT_YARD.Models;

namespace IT_YARD
{
    class Program
    {
        static void Main(string[] args)
        {
            //Вызов скрытых методов         
            var address1 = new Address();
            address1.City = "Poltava";
            address1.Country = "Ukraine";
            var customer1 = new Customer("Andrii");
            customer1.LastName = "Kononenko";
            // Сокрытие методов
            address1.DisplayEntityInfo();
            customer1.DisplayEntityInfo();
            Console.ReadLine();
            Console.WriteLine("Hello World!");
        }
    }
}

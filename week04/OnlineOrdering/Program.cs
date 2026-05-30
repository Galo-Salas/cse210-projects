using System;

class Program
{
    static void Main(string[] args)
    {
        // 1. Instantiate Order 1 (Domestic USA)
        Address address1 = new Address("1400 N 900 E", "Provo", "UT", "USA");
        Customer customer1 = new Customer("Brother Anderson", address1);
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Scripture Case", "SC-100", 25.50, 1));
        order1.AddProduct(new Product("Study Journal", "SJ-050", 12.75, 3));

        // 2. Instantiate Order 2 (International)
        Address address2 = new Address("Av. Javier Prado Este 456", "San Isidro", "Lima", "Peru");
        Customer customer2 = new Customer("Galo Suarez", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Mechanical Keyboard", "TECH-302", 110.00, 1));
        order2.AddProduct(new Product("Ergonomic Mouse", "TECH-405", 45.99, 1));
        order2.AddProduct(new Product("Monitor Stand", "TECH-112", 35.50, 2));

        // 3. Display Order 1 Metrics
        Console.WriteLine("========================================");
        Console.WriteLine("ORDER 1 SUMMARY");
        Console.WriteLine("========================================");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalCost():0.00}\n");

        // 4. Display Order 2 Metrics
        Console.WriteLine("========================================");
        Console.WriteLine("ORDER 2 SUMMARY");
        Console.WriteLine("========================================");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotalCost():0.00}\n");
    }
}
using System;
using System.Collections.Generic;

// this is the address class that hold a bunch of location stuff and details like the street, city, state and country of a buyers adress
class Address
{
    // these can oly be accessed or changes within this class becuase they are private
    private string street;
    private string city;
    private string state;
    private string country;

    // THE constructor baby, it gathers all the info
    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }
            // i learned that the "this" keyword refers to the classes own field, and so this sets each private variable to the constructors input values

    // this is a yes or no (true or false) if the address is in the usa or not
    public bool IsInUSA()
    {
        // this converts it to lowercase and compares it to usa to make it work 
        return country.ToLower() == "usa";
    }

    // 

    // this returns the full address string! yay
    public string GetFullAddress()
    {
        return $"{street}\n{city}, {state}\n{country}";
    }
}

// this is the customer class 
class Customer
{
    // these store the customers name and address
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        // this assignes the constuctors perameters
        this.name = name;
        this.address = address;
    }

    // getter that returns the customers name
    public string GetName()
    {
        return name;
    }

    public string GetAddressString()
    {
        return address.GetFullAddress();
    }

    // this checks if the customer lives in the usa
    public bool LivesInUSA()
    {
        return address.IsInUSA();
    }
}

// product class that represents a single product
class Product
{
    // privates that are for the product name, id, unit price, and how many of the items were bought
    private string name;
    private string productId;
    private double pricePerUnit;
    private int quantity;

    // constructor that sets all fields
    public Product(string name, string productId, double pricePerUnit, int quantity)
    {
        // this assigns imput values
        this.name = name;
        this.productId = productId;
        this.pricePerUnit = pricePerUnit;
        this.quantity = quantity;
    }

    // this calculates the total price, it multiplies the unit price with the quantity
    public double GetTotalCost()
    {
        // the simple math to get the total cost of the product
        return pricePerUnit * quantity;
    }

    // returns the products name and id as a label string
    public string GetPackingLabel()
    {
        return $"{name} (ID: {productId})";
    }
}

// this is the order class, it holds all the customers info for their order
class Order
{
    // this stores the customer who made the order and a list of the products that they wanted
    private Customer customer;
    private List<Product> products = new List<Product>();

    // this constructor assigns the customer to their order
    public Order(Customer customer)
    {
        this.customer = customer;
    }

    // the method to add a product to the products list
    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    // this will calculate the full price of the order
    // it starts with zero, goes through every product in the list and adds it to the total cost and then it adds the shipping cost and finally returns the total order price
    public double GetTotalPrice()
    {
        double total = 0;
        foreach (Product product in products)
        {
            total += product.GetTotalCost();
        }

        total += customer.LivesInUSA() ? 5.0 : 35.0;
        return total;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product product in products)
        {
            label += product.GetPackingLabel() + "\n";
        }
        return label;
    }

    // this is a sring listing all the products in order
    // it loops through the products changing each label and then returns the final
    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{customer.GetName()}\n{customer.GetAddressString()}";
    }
}

// main program! :)
class Program
{
    static void Main()
    {
        // this is the 1st order, they are a USA customer
        Address address1 = new Address("349 Yellow St.", "Sedona", "AZ", "USA");
        Customer customer1 = new Customer("Sunny Shine", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Water Bottle", "WB123", 12.50, 2));
        order1.AddProduct(new Product("Notebook", "NB456", 5.00, 3));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice():0.00}\n");

        // the 2nd order which is a international customer
        Address address2 = new Address("88 Queen St", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Mr. King", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Headphones", "HD789", 45.99, 1));
        order2.AddProduct(new Product("Phone Case", "PC012", 10.00, 2));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice():0.00}");
    }
}

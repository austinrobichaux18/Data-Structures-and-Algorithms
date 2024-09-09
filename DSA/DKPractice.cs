namespace DSA;
internal class DKPractice
{
    public void Run()
    {
        var customers = new List<Customer>
        {
            new Customer(1, "Alice", 1200),
            new Customer(2, "Bob", 950),
            new Customer(3, "Charlie", 500)
        };

        var products = new List<Product>
        {
            new Product(1, "Product A", new List<double>{ 0.10, .30}),
            new Product(2, "Product B", new List<double>{ 0.10, .30}),
            new Product(3, "Product C", new List<double>{ 0.10, .30}),
        };

        DoThing(customers, products);

    }
    //No customer can have more than 3 discounts
    //Every discount should have one or more customers
    //No customer discount should be more than 20 percent of their yearly spend
    //Customer with more spending has more discounts
    private void DoThing(List<Customer> customers, List<Product> products)
    {
        var customerSpending = new HashSet<decimal>();
        foreach (var customer in customers)
        {
            _ = customerSpending.Add(customer.Spending);
        }
        //todo use merge sort for faster performance instead of orderby
        var orderedSpending = customerSpending.OrderBy(x => x).ToArray();
        var highSpending = orderedSpending[2 * orderedSpending.Length / 3];
        var mediumSpending = orderedSpending[orderedSpending.Length / 3];

        foreach (var customer in customers)
        {
            var maxDiscount = (double)customer.Spending * .2;
            var maxDiscounts = GetMaximumDiscountsQuantity(mediumSpending, highSpending, customer);
            while (customer.Discounts.Count < maxDiscounts)
            {
                var disc = GetDiscount(maxDiscount, customer.Discounts, products);
                customer.Discounts.Add(disc);
                //todo add null protection
            }
        }
    }

    private CustomerDiscount GetDiscount(double maxDiscount, List<CustomerDiscount> customerDiscounts, List<Product> products)
    {
        foreach (var product in products)
        {
            //use hashmap for O(1) lookup time
            if (!customerDiscounts.Any(x => x.ProductId == product.ID))
            {
                //todo can use binary search for faster performance, merge sort to get sorted, then BS to find value
                var discount = product.Discount.Where(x => x < maxDiscount).OrderByDescending(x => x).FirstOrDefault();
                return new CustomerDiscount { Discount = discount, ProductId = product.ID };
            }
        }
        return null;
    }

    private static int GetMaximumDiscountsQuantity(decimal mediumSpending, decimal highSpending, Customer customer)
    {
        if (customer.Spending >= highSpending)
        {
            return 3;
        }
        else if (customer.Spending >= mediumSpending)
        {
            return 2;
        }
        return 1;
    }
}

public class Customer
{
    public int ID { get; set; }
    public string Name { get; set; }
    public decimal Spending { get; set; }
    public List<CustomerDiscount> Discounts { get; set; }

    public Customer(int id, string name, decimal spending)
    {
        ID = id;
        Name = name;
        Spending = spending;
    }
}

public class Product
{
    public int ID { get; set; }
    public string Name { get; set; }
    public List<double> Discount { get; set; }

    public Product(int id, string name, List<double> discounts)
    {
        ID = id;
        Name = name;
        Discount = discounts;
    }
}

public class CustomerDiscount
{
    public int ProductId { get; set; }
    public double Discount { get; set; }
}

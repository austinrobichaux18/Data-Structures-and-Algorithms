namespace DSA;
internal class DKInterview
{
    //Draft kings interview question 8/1/24 
    private bool Validate(ICollection<DKDiscountAssignment> discountAssignments, ICollection<DKCustomer> customers, ICollection<DKDiscount> discounts)
    {
        //Validate that
        // 1- no customer has more than 3 discounts assigned to them
        // 2- every discount must be assigned to at least one customer
        // 3- no customer can havea total discount value more than 20% of their yearly spend
        // 4- customers must have a higher total discount value than other customers with lower yearly spends 

    }
}
internal class DKCustomer
{
    public int Id { get; set; }
    public decimal YearlySpending { get; set; }
}
internal class DKDiscount
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public decimal DollarValue { get; set; }
}
internal class DKDiscountAssignment
{
    public int CustomerId { get; set; }
    public int DiscountId { get; set; }
}


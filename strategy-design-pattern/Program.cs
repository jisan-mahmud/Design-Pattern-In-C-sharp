interface IPaymentStrategy
{
    void Pay(double amount);
}


class CreditCardPayment : IPaymentStrategy
{
    public void Pay(double amount)
    {
        Console.WriteLine($"Pay amount {amount} using credit card");
    }
}

class PaypalPayment : IPaymentStrategy
{
    public void Pay(double amount)
    {
        Console.WriteLine($"Pay amount {amount} using paypal");
    }
}

class BkashPayment : IPaymentStrategy
{
    public void Pay(double amount)
    {
        Console.WriteLine($"Pay amount {amount} using Bkash");
    }
}


class PaymentContext
{
    private IPaymentStrategy _paymentStrategy;

    public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    public void PayAmount(double amount)
    {
        _paymentStrategy.Pay(amount);
    }
}


class Program
{
    static void Main(string[] args)
    {
        PaymentContext paymentContext = new PaymentContext();
        paymentContext.SetPaymentStrategy(new BkashPayment());
        paymentContext.PayAmount(1000);

        paymentContext.SetPaymentStrategy(new CreditCardPayment());
        paymentContext.PayAmount(100);

        paymentContext.SetPaymentStrategy(new PaypalPayment());
        paymentContext.PayAmount(200);
    }
}
namespace ConsAppPayment;

internal interface IPayment
{
    bool Paga(decimal amount);
}
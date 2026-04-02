
class Account
{
    public delegate void AccountHandler(Account sender, AccountEventArgs e);
    public event AccountHandler? Notify;

    public Account(int sum) => Sum = sum;
    public int Sum{get; private set;}
    public void Put(int sum)
    {
        Sum += sum;
        Notify?.Invoke(this, new AccountEventArgs($"На счёт поступило: {sum}", sum));
    }
    public void Take(int sum)
    {
        if(Sum >= sum)
        {
            Sum -= sum;
            Notify?.Invoke(this, new AccountEventArgs($"Со счёта было снято: {sum}",sum));
        }
        else
        {
            Notify?.Invoke(this, new AccountEventArgs($"Недостаточно средств на счёте.",sum));
        }
    }
}
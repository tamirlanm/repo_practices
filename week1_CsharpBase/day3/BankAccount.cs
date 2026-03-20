
class BankAccount
{
    public string _owner;
    private int _balance;

    public BankAccount(string owner, int balance)
    {
        Owner = owner;
        Balance = balance;
    }

    public string Owner {get;set;}
    public int Balance
    {
        get{ return _balance;}
        set
        {
            if(value >= 0)
            {
                _balance = value;
            }
        }
    }
    
}
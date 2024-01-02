static void Withdraw(string accountName, decimal amount)
{
    // Instead of if else steament use this

    ArgumentException.ThrowIfNullOrEmpty(accountName, nameof(accountName)); 
    ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount, nameof(amount));


    if (string.IsNullOrWhiteSpace(accountName))
    {
        throw new ArgumentException();
    }
    if (amount <= 0)
    {
        throw new ArgumentOutOfRangeException(paramName: nameof(amount),
          message: $"{nameof(amount)} cannot be negative or zero.");
    }
    // process parameters
}



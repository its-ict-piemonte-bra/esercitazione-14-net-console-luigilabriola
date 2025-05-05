namespace lesson
{
    class Bank
    {
        public readonly string Name;

        private List<Account> Accounts;
        private List<Transaction> Transactions;

        public Bank(string Name)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentException("Bank name is invalid");
            }

            this.Name = Name;
            this.Accounts = new List<Account>();
            this.Transactions = new List<Transaction>();
        }

        public Account GetAccount(int index)
        {
            if (index < 0 || index >= this.Accounts.Count)
            {
                throw new IndexOutOfRangeException("Index is outside Account list");
            }

            return this.Accounts[index];
        }

        public Account? GetAccount(string IBAN)
        {
            if (!Account.CheckIBAN(IBAN))
            {
                throw new ArgumentException("IBAN is not valid");
            }

            foreach (Account account in this.Accounts)
            {
                if (account.IBAN == IBAN)
                {
                    return account;
                }
            }

            return null;
        }

        public bool IsRegistered(Account account)
        {
            return this.GetAccount(account.IBAN) != null;
        }

        public void RegisterAccount(Account account)
        {
            if (this.IsRegistered(account))
            {
                throw new InvalidOperationException("IBAN is already registered in the system");
            }

            this.Accounts.Add(account);
        }

        public override string ToString()
        {
            string result = $"Bank: {this.Name}\n";

            for (int i = 0; i < this.Accounts.Count; i++)
            {
                result += $"Accounts[{i}]: {this.Accounts[i]}\n";
            }

            for (int i = 0; i < this.Transactions.Count; i++)
            {
                result += $"Transactions[{i}]: {this.Transactions[i]}\n";
            }

            return result;
        }
    }
}

namespace lesson
{
    class Bank
    {
        public readonly string Name;

        private List<Account> Accounts;
        private List<Transaction> Transactions;

        private HashSet<string> set;
        private Dictionary<string, bool> dictionary;

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

            // aggiungi
            this.Accounts.Add(account);
            this.set.Add(account.IBAN);
        }
    }
}

namespace lesson
{
    class Transaction
    {
        public readonly Account Sender;
        public readonly Account Receiver;

        public readonly double Amount;
        public readonly string Currency;
        public readonly string Description;

        public readonly DateTime Date;

        public Transaction(
            Account Sender,
            Account Receiver,
            double Amount,
            string Currency,
            string Description,
            DateTime Date
        )
        {
            if (Sender == null)
            {
                throw new ArgumentException("Invalid sender account");
            }
            else if (Receiver == null)
            {
                throw new ArgumentException("Invalid receiver account");
            }
            else if (Amount <= 0)
            {
                throw new ArgumentException("Invalid transaction amount");
            }
            else if (string.IsNullOrWhiteSpace(Currency))
            {
                throw new ArgumentException("Invalid transaction currency");
            }
            else if (string.IsNullOrWhiteSpace(Description))
            {
                throw new ArgumentException("Invalid transaction description");
            }
            else if (DateTime.Now < Date)
            {
                throw new ArgumentException("Invalid transaction date and time (future)");
            }

            this.Sender = Sender;
            this.Receiver = Receiver;
            this.Amount = Amount;
            this.Currency = Currency;
            this.Description = Description;
            this.Date = Date;
        }

        public override bool Equals(object? obj)
        {
            if (this == obj)
            {
                return true;
            }
            else if (!(obj is Transaction))
            {
                return false;
            }

            Transaction transaction = (Transaction)obj;
            return this.Sender.Equals(transaction.Sender) &&
                this.Receiver.Equals(transaction.Receiver) &&
                this.Amount.Equals(transaction.Amount) &&
                this.Currency.Equals(transaction.Currency) &&
                this.Description.Equals(transaction.Description);
        }

        public override string ToString()
        {
            return this.ToString(false);
        }

        public string ToString(bool details)
        {
            if (details)
            {
                string result = "Transaction details:\n";

                result += $"From: {this.Sender}\n";
                result += $"To: {this.Receiver}\n";
                result += $"Amount: {this.Amount} {this.Currency}\n";
                result += $"Description: {this.Description}\n";
                result += $"Date: {this.Date}";

                return result;
            }
            else
            {
                return $"Sent {this.Amount} {this.Currency} from {this.Sender} to {this.Receiver}";
            }
        }
    }
}

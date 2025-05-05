using System.Security.Cryptography.X509Certificates;

namespace lesson
{
    /// <summary>
    /// Represents an account in a Bank.
    /// </summary>
    abstract class Account
    {
        public readonly string IBAN;

        public abstract string AccountName { get; }

        public Account(string IBAN)
        {
            if (string.IsNullOrWhiteSpace(IBAN))
            {
                throw new ArgumentException("IBAN is empty");
            }
            else if (!Account.CheckIBAN(IBAN))
            {
                throw new ArgumentException("IBAN is not valid");
            }

            this.IBAN = IBAN.ToUpper();
        }

        public static bool CheckIBAN(string IBAN)
        {
            if (string.IsNullOrWhiteSpace(IBAN))
            {
                return false;
            }
            else if (IBAN.Length != 27)
            {
                return false;
            }
            else if (IBAN[0] != 'I' || IBAN[1] != 'T')
            {
                return false;
            }
            else
            {
                // 2 control digits
                try
                {
                    string checkDigits = IBAN.Substring(2, 2);
                    Convert.ToInt32(checkDigits);
                }
                catch
                {
                    return false;
                }

                // 1 control character
                char controlChar = IBAN[4].ToString().ToUpper()[0];
                if (IBAN[4] < 'A' || IBAN[4] > 'Z')
                {
                    return false;
                }

                // 5 ABI control digits
                try
                {
                    string checkDigits = IBAN.Substring(5, 5);
                    Convert.ToInt32(checkDigits);
                }
                catch
                {
                    return false;
                }

                // 5 CAB control digits
                try
                {
                    string checkDigits = IBAN.Substring(10, 5);
                    Convert.ToInt32(checkDigits);
                }
                catch
                {
                    return false;
                }

                // 12 Account control digits
                try
                {
                    string checkDigits = IBAN.Substring(15, 12);
                    Convert.ToInt64(checkDigits);
                }
                catch
                {
                    return false;
                }

                return true;
            }
        }

        public override bool Equals(object? obj)
        {
            if (this == obj)
            {
                return true;
            }
            else if (!(obj is Account))
            {
                return false;
            }

            Account account = (Account)obj;
            return this.IBAN.Equals(account.IBAN);
        }

        public override string ToString()
        {
            return $"Account name: {this.AccountName}";
        }
    }
}

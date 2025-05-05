namespace lesson
{
    public class Program
    {
        /// <summary>
        /// The main entrypoint of your application.
        /// </summary>
        /// <param name="args">The arguments passed to the program</param>
        public static void Main(string[] args)
        {
            Bank bank;

            do
            {
                try
                {
                    Console.WriteLine("Insert the name of the bank:");
                    string name = Console.ReadLine()!;

                    bank = new Bank(name);

                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Invalid name, please try again. Error details: {ex.Message}");
                }
            } while (true);

            Console.WriteLine($"Welcome to the {bank.Name} automation service");

            int choice = Program.Menu();
            switch (choice)
            {
                case 1:
                    Program.RegisterNewPersonalAccount(bank);
                    break;
                case 2:
                    Program.RegisterNewCompanyAccount(bank);
                    break;
                case 3:
                    Program.PrintAccountDataFromIBAN(bank);
                    break;
                case 4:
                    Program.PrintAccountDataFromIndex(bank);
                    break;
                case 5:
                    Program.RegisterNewTransaction(bank);
                    break;
                case 6:
                    Program.PrintAccountBalance(bank);
                    break;
                case 7:
                    Program.PrintWealthiestAccount(bank);
                    break;
                case 8:
                    Program.PrintMostActiveAccount(bank);
                    break;
                case 9:
                    Program.PrintBankInformation(bank);
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again");
                    break;
            }
        }

        private static void PrintBankInformation(Bank bank)
        {
            if (bank == null)
            {
                throw new ArgumentNullException("bank must not be null");
            }

            Console.WriteLine(bank);
        }

        private static void PrintMostActiveAccount(Bank bank)
        {
            if (bank == null)
            {
                throw new ArgumentNullException("bank must not be null");
            }
        }

        private static void PrintWealthiestAccount(Bank bank)
        {
            if (bank == null)
            {
                throw new ArgumentNullException("bank must not be null");
            }
        }

        private static void PrintAccountBalance(Bank bank)
        {
            if (bank == null)
            {
                throw new ArgumentNullException("bank must not be null");
            }
            string IBAN;
            bool validIban;
            do
            {
                IBAN = ConsoleHelper.Ask("Insert the IBAN of the account:", "Invalid IBAN, try again", false);
                validIban = Account.CheckIBAN(IBAN);
                if (!validIban)
                {
                    Console.WriteLine("IBAN format is not valid, try again");
                }
            } while (!validIban);

            Account? account = bank.GetAccount(IBAN);
            if (account == null)
            {
                Console.WriteLine("Account not found");
            }
            else
            {
                Console.WriteLine($"Account balance for {account.AccountName} ({account.IBAN}): {account.Balance} EUR");
            }
        }

        private static void RegisterNewTransaction(Bank bank)
        {
            if (bank == null)
            {
                throw new ArgumentNullException("bank must not be null");
            }
            string IBAN;
            bool validIban;
            do
            {
                IBAN = ConsoleHelper.Ask("Insert the IBAN of the account:", "Invalid IBAN, try again", false);
                validIban = Account.CheckIBAN(IBAN);
                if (!validIban)
                {
                    Console.WriteLine("IBAN format is not valid, try again");
                }
            } while (!validIban);

            Account? account = bank.GetAccount(IBAN);
            if (account == null)
            {
                Console.WriteLine("Account not found");
                return;
            }

            string description = ConsoleHelper.Ask("Insert the transaction description:", "Invalid value, try again", false);

            decimal amount;
            while (true)
            {
                try
                {
                    amount = Convert.ToDecimal(ConsoleHelper.Ask("Insert the transaction amount:", "Invalid value, try again", false));
                    break;
                }
                catch
                {
                    Console.WriteLine("Amount is not in correct format, please insert a valid number (e.g., 123.45)");
                }
            }

            Transaction transaction = new Transaction(description, amount);
            account.RegisterTransaction(transaction);
            Console.WriteLine("Transaction registered successfully");
        }

        private static void RegisterNewPersonalAccount(Bank bank)
        {
            if (bank == null)
            {
                throw new ArgumentNullException("bank must not be null");
            }

            bool validIban = false;
            string IBAN;
            do
            {
                IBAN = ConsoleHelper.Ask("Insert the user IBAN:", "Invalid IBAN, try again", false);
                validIban = Account.CheckIBAN(IBAN);
                if (!validIban)
                {
                    Console.WriteLine("IBAN is not formatted correctly, try again");
                }
            } while (!validIban);

            string firstName = ConsoleHelper.Ask("Insert the user first name:", "Invalid value, try again", false);
            string lastName = ConsoleHelper.Ask("Insert the user last name:", "Invalid value, try again", false);

            try
            {
                PersonalAccount account = new PersonalAccount(IBAN, firstName, lastName);
                bank.RegisterAccount(account);
            }
            catch
            {
                Console.WriteLine("Cannot register account, try again");
            }
        }

        private static void RegisterNewCompanyAccount(Bank bank)
        {
            if (bank == null)
            {
                throw new ArgumentNullException("bank must not be null");
            }

            bool validIban = false;
            string IBAN;
            do
            {
                IBAN = ConsoleHelper.Ask("Insert the user IBAN:", "Invalid IBAN, try again", false);
                validIban = Account.CheckIBAN(IBAN);
                if (!validIban)
                {
                    Console.WriteLine("IBAN is not formatted correctly, try again");
                }
            } while (!validIban);

            string companyName = ConsoleHelper.Ask("Insert the company name:", "Invalid value, try again", false);

            try
            {
                CompanyAccount account = new CompanyAccount(IBAN, companyName);
                bank.RegisterAccount(account);
            }
            catch
            {
                Console.WriteLine("Cannot register account, try again");
            }
        }

        private static void PrintAccountDataFromIBAN(Bank bank)
        {
            if (bank == null)
            {
                throw new ArgumentNullException("bank must not be null");
            }

            bool validIban = false;
            string IBAN;
            do
            {
                IBAN = ConsoleHelper.Ask("Insert the user IBAN:", "Invalid IBAN, try again", false);
                validIban = Account.CheckIBAN(IBAN);
                if (!validIban)
                {
                    Console.WriteLine("IBAN is not formatted correctly, try again");
                }
            } while (!validIban);

            Account? account = bank.GetAccount(IBAN);
            if (account == null)
            {
                Console.WriteLine("Account not found in the system");
            }
            else
            {
                Console.WriteLine(account);
            }
        }

        private static void PrintAccountDataFromIndex(Bank bank)
        {
            if (bank == null)
            {
                throw new ArgumentNullException("bank must not be null");
            }

            int index;
            while (true)
            {
                try
                {
                    index = Convert.ToInt32(
                        ConsoleHelper.Ask("Insert the index of the account", "Invalid value, try again", false)
                    );

                    break;
                }
                catch
                {
                    Console.WriteLine("Value is not formatted correctly, please input a number");
                }
            }

            try
            {
                Account? account = bank.GetAccount(index);
                if (account == null)
                {
                    Console.WriteLine("Account not found");
                }
                else
                {
                    Console.WriteLine(account);
                }
            }
            catch
            {
                Console.WriteLine("Not found, out of index");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static int Menu()
        {
            Console.WriteLine("Please select one of the following operations to proceed");
            Console.WriteLine("1. Register new personal account");
            Console.WriteLine("2. Register new company account");
            Console.WriteLine("3. Print account data from IBAN");
            Console.WriteLine("4. Print account data from index");
            Console.WriteLine("5. Register new transaction");
            Console.WriteLine("6. Print account balance");
            Console.WriteLine("7. Print wealthiest account in the bank");
            Console.WriteLine("8. Print account with most transactions in the bank");
            Console.WriteLine("9. Print bank, account and transaction information");

            while (true)
            {
                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine()!);
                    return choice;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid choice, try again");
                }
            }
        }
    }
}

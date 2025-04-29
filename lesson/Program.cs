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
            //Transaction tx = new Transaction(null, null, 10, "EUR", "Esempio", DateTime.Parse("2025-11-11"));
            //Console.WriteLine(tx);

            Bank bank = new Bank("Bank of Testing");

            Account alessandro = new PersonalAccount("IT60X1234567890123456789012", "Alessandro", "Sanino");
            Account alessandro2 = new PersonalAccount("IT60X1234567890123456789012", "Aleandro", "Panino");

            Console.WriteLine($"Account non registrato => esiste ? {bank.IsRegistered(alessandro)}");

            bank.RegisterAccount(alessandro);

            Console.WriteLine($"Account registrato => esiste ? {bank.IsRegistered(alessandro)}");

            try
            {
                bank.RegisterAccount(alessandro2);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

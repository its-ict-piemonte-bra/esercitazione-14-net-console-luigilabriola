namespace lesson
{
    class CompanyAccount : Account
    {
        public readonly string CompanyName;

        public CompanyAccount(
            string IBAN,
            string CompanyName
        ) : base(IBAN)
        {
            if (string.IsNullOrWhiteSpace(CompanyName))
            {
                throw new ArgumentException("Company name is invalid");
            }

            this.CompanyName = CompanyName;
        }

        public override string AccountName
        {
            get
            {
                return this.CompanyName;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()} - Type: Company";
        }
    }
}

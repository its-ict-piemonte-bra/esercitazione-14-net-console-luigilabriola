namespace lesson
{
    class PersonalAccount : Account
    {
        public readonly string FirstName;
        public readonly string LastName;

        public PersonalAccount(
            string IBAN,
            string FirstName,
            string LastName
        ) : base(IBAN)
        {
            if (string.IsNullOrWhiteSpace(FirstName))
            {
                throw new ArgumentException("Invalid first name");
            }
            else if (string.IsNullOrWhiteSpace(LastName))
            {
                throw new ArgumentException("Invalid last name");
            }

            this.FirstName = FirstName;
            this.LastName = LastName;
        }

        public override string AccountName
        {
            get
            {
                return $"{this.LastName} {this.FirstName}";
            }
        }

        public override bool Equals(object? obj)
        {
            if (this == obj)
            {
                return true;
            }
            else if (!(obj is PersonalAccount))
            {
                return false;
            }

            PersonalAccount account = (PersonalAccount)obj;
            return base.Equals(obj) &&
                    this.FirstName.Equals(account.FirstName) &&
                    this.LastName.Equals(account.LastName);
        }

        public override string ToString()
        {
            return $"{base.ToString()} - Type: Personal";
        }
    }
}

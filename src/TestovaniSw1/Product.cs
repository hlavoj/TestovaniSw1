namespace TestovaniSw1
{
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsSocialProduct { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Price: {Price}";
        }

        protected bool Equals(Product other)
        {
            return string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Product)obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }
    }
}
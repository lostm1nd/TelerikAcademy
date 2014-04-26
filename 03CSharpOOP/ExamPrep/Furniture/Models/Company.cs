namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using FurnitureManufacturer.Interfaces;

    public class Company : ICompany
    {
        // Fields
        private string name;
        private string registrationNumber;
        private ICollection<IFurniture> furnitures;

        // Constructor
        public Company(string name, string regNumber)
        {
            this.Name = name;
            this.RegistrationNumber = regNumber;
            this.furnitures = new List<IFurniture>();
        }

        // Properties
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException("The name cannot be null or with less than 5 symbols");
                }

                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get { return this.registrationNumber; }
            private set
            {
                if (value.Length != 10)
                {
                    throw new ArgumentException("Registration number must be exactly 10 symbols");
                }

                foreach (var digit in value)
                {
                    if (!char.IsDigit(digit))
                    {
                        throw new ArgumentException("Registration number must contain only digits");
                    }
                }

                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get { return new List<IFurniture>(this.furnitures); }
        }

        // Methods
        public void Add(IFurniture furniture)
        {
            this.furnitures.Add(furniture);
            this.furnitures = this.furnitures.OrderBy(x => x.Price).ThenBy(y => y.Model).ToList();
        }

        public void Remove(IFurniture furniture)
        {
            IFurniture toRemove = this.Find(furniture.Model);

            if (toRemove != null)
            {
                this.furnitures.Remove(toRemove);
            }
        }

        public IFurniture Find(string model)
        {
            foreach (var furniture in this.furnitures)
            {
                if (furniture.Model.ToLower() == model.ToLower())
                {
                    return furniture;
                }
            };

            return null;
        }

        public string Catalog()
        {
            StringBuilder catalog = new StringBuilder();
            catalog.AppendFormat("{0} - {1} - {2} {3}",
            this.Name,
            this.RegistrationNumber,
            this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
            this.Furnitures.Count != 1 ? "furnitures" : "furniture");

            if (this.Furnitures.Count > 0)
            {
                catalog.Append(Environment.NewLine);
                foreach (var furniture in this.Furnitures)
                {
                    catalog.AppendLine(furniture.ToString());
                }
            }

            return catalog.ToString().TrimEnd();
        }
    }
}

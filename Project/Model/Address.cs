// File:    Address.cs
// Created: Tuesday, April 14, 2020 5:08:10 PM
// Purpose: Definition of Class Address

using System;
using System.Collections.Generic;
using Project.Repositories.Abstract;

namespace Project.Model
{
    public class Address : IIdentifiable<long>
    {
        public long Id { get; set; }
        public string Number { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }

        public List<User> User;

        public Address()
        { }
        public Address(long id)
        { 
            Id = id;
        }

        public Address(long id, string number, string street, string city, string country, string postCode)
        {
            Id = id;
            Number = number;
            Street = street;
            City = city;
            Country = country;
            PostCode = postCode;
        }
        public Address( string number, string street, string city, string country, string postCode)
        {
            Number = number;
            Street = street;
            City = city;
            Country = country;
            PostCode = postCode;
        }

        public override bool Equals(object obj)
        {
            return obj is Address address &&
                   Id == address.Id &&
                   Number == address.Number &&
                   Street == address.Street &&
                   City == address.City &&
                   Country == address.Country &&
                   PostCode == address.PostCode;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;

        public override int GetHashCode()
        {
            int hashCode = -1991195495;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Number);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Street);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(City);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Country);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PostCode);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<User>>.Default.GetHashCode(User);
            return hashCode;
        }
    }
}
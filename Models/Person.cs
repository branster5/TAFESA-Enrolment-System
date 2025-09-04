using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAFESA_Enrolment_System.Models
{
    /// <summary>
    /// An individual within the TAFE System, to store contact info including name, email, phone number and address. Currently only inherited by the Student model.
    /// </summary>
    internal class Person
    {
        const string DEFAULT_NAME = "No name provided";
        const string DEFAULT_EMAIL = "No email provided";
        //String instead of int for phone number to include special characters and spaces if required e.g. +61 432 123 456
        const string DEFAULT_PHONE_NUMBER = "No phone number provided";

        public Address Address { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        ///<summary>
        /// No arg constructor (defaults)
        /// </summary>
        public Person(): this(new Address(), DEFAULT_NAME, DEFAULT_EMAIL, DEFAULT_PHONE_NUMBER) { }

        /// <summary>
        /// All arg constructor
        /// </summary>
        /// <param name="address">Address object for where person lives</param>
        /// <param name="name">Name of person</param>
        /// <param name="email">Contact email</param>
        /// <param name="phoneNumber">Phone number (as string for formatting)</param>
        public Person(Address address, string name, string email, string phoneNumber)
        {
            this.Address = address;
            this.Name = name;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"Address: {Address}, Name: {Name}, Email: {Email}, PhoneNumber: {PhoneNumber}";
        }
    }
}

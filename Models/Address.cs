using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAFESA_Enrolment_System.Models
{
    /// <summary>
    /// Residential address for any person, as part of contact information
    /// </summary>
    public class Address
    {
        const int DEFAULT_STREET_NUM = 0;
        const string DEFAULT_STREET_NAME = "No street name given";
        const string DEFAULT_SUBURB = "No suburb given";
        const int DEFAULT_POSTCODE = 0;
        const string DEFAULT_STATE = "No state given";

        public int StreetNum { get; set; }
        public string StreetName { get; set; }
        public string Suburb { get; set; }
        public int Postcode { get; set; }
        public string State { get; set; }

        /// <summary>
        /// No arg constructor (defaults)
        /// </summary>
        public Address() : this(DEFAULT_STREET_NUM, DEFAULT_STREET_NAME, DEFAULT_SUBURB, DEFAULT_POSTCODE, DEFAULT_STATE) { }

        /// <summary>
        /// All arg constructor
        /// </summary>
        /// <param name="streetNum">Street number</param>
        /// <param name="streetName">Name of street</param>
        /// <param name="suburb">Suburb containing street</param>
        /// <param name="postcode">Postcode of suburb</param>
        /// <param name="state">State within Australia containing address</param>
        public Address(int streetNum, string streetName, string suburb, int postcode, string state)
        {
            this.StreetNum = streetNum;
            this.StreetName = streetName;
            this.Suburb = suburb;
            this.Postcode = postcode;
            this.State = state;
        }

        public override string ToString()
        {
            return $"StreetNum: {StreetNum}, StreetName: {StreetName}, Suburb: {Suburb}, Postcode: {Postcode}, State: {State}";
        }
    }
}

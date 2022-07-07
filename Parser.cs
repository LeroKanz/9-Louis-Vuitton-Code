using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouisVuittonCode
{
    public static class Parser
    {
        public static Country[] GetCountry(string factoryLocationCode)
        {
            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            List<Country> countriesCode = new List<Country>();

            switch (factoryLocationCode)
            {
                case "A0":
                case "A1":
                case "A2":
                case "AA":
                case "AH":
                case "AN":
                case "AR":
                case "AS":
                case "BA":
                case "BJ":
                case "BU":
                case "DR":
                case "DU":
                case "DT":
                case "CO":
                case "CT":
                case "CX":
                case "ET":
                case "MB":
                case "MI":
                case "NO":
                case "RA":
                case "RI":
                case "SF":
                case "SL":
                case "SN":
                case "SP":
                case "SR":
                case "TJ":
                case "TH":
                case "TR":
                case "TS":
                case "VI":
                case "VX":
                    countriesCode.Add(Country.France);
                    break;
                case "LP":
                case "OL":
                    countriesCode.Add(Country.Germany);
                    break;
                case "BC":
                case "BO":
                case "CE":
                case "FO":
                case "MA":
                case "OB":
                case "RC":
                case "RE":
                case "SA":
                case "TD":
                    countriesCode.Add(Country.Italy);
                    break;
                case "CA":
                case "LO":
                case "LB":
                case "LM":
                case "GI":
                    countriesCode.Add(Country.Spain);
                    break;
                case "DI":
                case "FA":
                    countriesCode.Add(Country.Switzerland);
                    break;
                case "FC":
                case "FH":
                case "LA":
                case "OS":
                    countriesCode.Add(Country.USA);
                    break;
                case "LW":
                    countriesCode.Add(Country.Spain);
                    countriesCode.Add(Country.France);
                    break;
                case "FL":
                case "SD":
                    countriesCode.Add(Country.France);
                    countriesCode.Add(Country.USA);
                    break;
                default:
                    throw new ArgumentException("Incorrect value");
            }

            return countriesCode.ToArray();
        }
    }
}

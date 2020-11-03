using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_GreenPlan_Repository
{
    public class GreenPlanContent
    {
        public string CarType { get; set; }
        public double PriceEstimate { get; set; }
        public double FuelCost { get; set; }
        public string Mileage { get; set; }
        public string CarName { get; set; }


        public GreenPlanContent() { }
        public GreenPlanContent(string cartype, double priceEstimate, double fuelCost, string mileage, string carName)
        {
            CarType = cartype;
            PriceEstimate = priceEstimate;
            FuelCost = fuelCost;
            Mileage = mileage;
            CarName = carName;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_GreenPlan_Repository
{
    public class GreenPlanContent_Repo
    {

        public List<GreenPlanContent> _contentDirectory = new List<GreenPlanContent>();

        public bool AddContentToDirectory(GreenPlanContent content)
        {
            int startingCount = _contentDirectory.Count;

            _contentDirectory.Add(content);

            bool wasAdded = (_contentDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public List<GreenPlanContent> GetContents()
        {
            return _contentDirectory;
        }
        public GreenPlanContent FindCarByName(string cartype)
        {
            foreach (GreenPlanContent content in _contentDirectory)
            {
                if (content.CarType == cartype)
                {
                    return content;
                }
            }
            return null;
        }
        public bool UpdateExistingContent(string originalcartype, GreenPlanContent newContent)
        {
            GreenPlanContent oldContent = FindCarByName(originalcartype);

            if (oldContent != null)
            {
                oldContent.CarType = newContent.CarType;
                oldContent.PriceEstimate = newContent.PriceEstimate;
                oldContent.FuelCost = newContent.FuelCost;
                oldContent.Mileage = newContent.Mileage;
                return true;
            }
            else
            {
                {
                    return false;
                }
            }
        }
        public bool DeleteVehicleByName(GreenPlanContent existingContent)
        {
            bool deleteResult = _contentDirectory.Remove(existingContent);
            return deleteResult;
        }
    }
}



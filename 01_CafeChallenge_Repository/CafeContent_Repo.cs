using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeChallenge_Repository
{
    public class CafeContent_Repo
    {
        public List<CafeContent> _contentDirectory = new List<CafeContent>();

        public bool AddContentToDirectory(CafeContent content)
        {
            int startingCount = _contentDirectory.Count;

            _contentDirectory.Add(content);

            bool wasAdded = (_contentDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public List<CafeContent> GetContents()
        {
            return _contentDirectory;
        }
        public CafeContent GetContentByItem(string mealname)
        {
            foreach (CafeContent content in _contentDirectory)
            {
                if (content.MealName == mealname)
                {
                    return content;
                }
            }
            return null;
        }

        public bool UpdateExistingContent(string originalmealname, CafeContent newContent)
        {
            CafeContent oldContent = GetContentByItem(originalmealname);

            if (oldContent != null)
            {
                oldContent.MealName = newContent.MealName;
                oldContent.Description = newContent.Description;
                oldContent.Ingredients = newContent.Ingredients;
                oldContent.MealId = newContent.MealId;
                oldContent.Price = newContent.Price;
                return true;
            }
            else
            {
                {
                    return false;
                }
            }
        }

        public bool DeleteContentByMealName(CafeContent existingContent)
        {
            bool deleteResult = _contentDirectory.Remove(existingContent);
            return deleteResult;
        }
    }
}
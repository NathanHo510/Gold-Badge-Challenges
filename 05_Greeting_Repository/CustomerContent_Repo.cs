using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Greeting_Repository
{
    public class CustomerContent_Repo
    {
        public List<CustomerContent> _contentDirectory = new List<CustomerContent>();

        public bool AddContentToDirectory(CustomerContent content)
        {
            int startingCount = _contentDirectory.Count;

            _contentDirectory.Add(content);

            bool wasAdded = (_contentDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public List<CustomerContent> GetContents()
        {
            return _contentDirectory;
        }
        public CustomerContent FindPersonByName(string firstName)
        {
            foreach (CustomerContent content in _contentDirectory)
            {
                if (content.FirstName == firstName)
                {
                    return content;
                }
            }
            return null;
        }
        public bool UpdateExistingContent(string originalfirstName, CustomerContent newContent)
        {
            CustomerContent oldContent = FindPersonByName(originalfirstName);

            if (oldContent != null)
            {
                oldContent.FirstName = newContent.FirstName;
                oldContent.LastName = newContent.LastName;
                oldContent.Type = newContent.Type;
                oldContent.Email = newContent.Email;
                return true;
            }
            else
            {
                {
                    return false;
                }
            }
        }
        public bool DeleteCustomerByName(CustomerContent existingContent)
        {
            bool deleteResult = _contentDirectory.Remove(existingContent);
            return deleteResult;
        }
    }
}

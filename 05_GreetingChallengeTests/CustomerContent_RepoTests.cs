using System;
using System.Collections.Generic;
using _05_Greeting_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _05_GreetingChallengeTests
{
    [TestClass]
    public class CustomerContent_RepoTests
    {

        [TestMethod]
        public void AddToDirectory_ShouldGetCorrectBoolean()
        {
            CustomerContent content = new CustomerContent();
            CustomerContent_Repo repository = new CustomerContent_Repo();

            bool addResult = repository.AddContentToDirectory(content);

            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void GetDirectory_ShouldReturnCorrectCollection()
        {
            CustomerContent content = new CustomerContent();
            CustomerContent_Repo repo = new CustomerContent_Repo();

            repo.AddContentToDirectory(content);

            List<CustomerContent> contents = repo.GetContents();

            bool directoryHasContent = contents.Contains(content);


            Assert.IsTrue(directoryHasContent);
        }
    }
}




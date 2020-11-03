using System;
using System.Collections.Generic;
using _01_CafeChallenge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_CafeChallenge_Tests
{
    [TestClass]
    public class CafeContent_RepoTests
    {
        [TestMethod]
        public void AddToDirectory_ShouldGetCorrectBoolean()
        {

            CafeContent content = new CafeContent();
            CafeContent_Repo repository = new CafeContent_Repo();


            bool addResult = repository.AddContentToDirectory(content);


            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void GetDirectory_ShouldReturnCorrectCollection()
        {

            CafeContent content = new CafeContent();
            CafeContent_Repo repo = new CafeContent_Repo();

            repo.AddContentToDirectory(content);


            List<CafeContent> contents = repo.GetContents();

            bool directoryHasContent = contents.Contains(content);


            Assert.IsTrue(directoryHasContent);
        }
        
    }
}

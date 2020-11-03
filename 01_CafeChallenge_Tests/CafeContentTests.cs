using System;
using _01_CafeChallenge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_CafeChallenge_Tests
{
    [TestClass]
    public class CafeContentTests
    {
        [TestMethod]
        public void SetMealName_ShouldReturnCorrectString()
        {
            CafeContent content = new CafeContent();

            content.MealName = "WumboCombo";

            Assert.AreEqual(content.MealName, "WumboCombo");
        }
    }
}

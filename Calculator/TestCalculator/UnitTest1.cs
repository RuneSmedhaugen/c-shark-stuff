using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KalkulatorTests
{
    [TestClass]
    public class KalkulatorTests
    {
        private Kalkulator kalkulator;

        [TestInitialize]
        public void Setup()
        {
            kalkulator = new Kalkulator();
        }

        [TestMethod]
        public void LeggSammen_GivenTwoNumbers_ReturnsSum()
        {
            int result = kalkulator.LeggSammen(3, 2);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void TrekkFra_GivenTwoNumbers_ReturnsDifference()
        {
            int result = kalkulator.TrekkFra(5, 3);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Multipliser_GivenTwoNumbers_ReturnsProduct()
        {
            int result = kalkulator.Multipliser(4, 3);
            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void Divider_GivenTwoNumbers_ReturnsQuotient()
        {
            int result = kalkulator.Divider(10, 2);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Cannot divide by zero.")]
        public void Divider_DivideByZero_ThrowsArgumentException()
        {
            kalkulator.Divider(10, 0);
        }
    }
}
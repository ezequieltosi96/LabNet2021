using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Ejercicio_3.Tests
{
    [TestClass()]
    public class LogicTests
    {
        [TestMethod()]
        public void DisminuirStockTest()
        {
            // arrange
            var controlStock = new Logic(30);
            var stockADisminuir = 10;
            var expectedResult = 20;

            // act
            var result = controlStock.DisminuirStock(stockADisminuir);

            // assert
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void DisminuirStock_StockInsuficioente_ThrowsException()
        {
            // arrange
            var controlStock = new Logic(30);
            var stockADisminuir = 31;

            // act
            var result = controlStock.DisminuirStock(stockADisminuir);
        }
    }
}
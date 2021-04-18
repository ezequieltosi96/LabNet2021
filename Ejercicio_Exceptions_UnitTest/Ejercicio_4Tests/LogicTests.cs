using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ejercicio_4.CustomExceptions;

namespace Ejercicio_4.Tests
{
    [TestClass()]
    public class LogicTests
    {
        [TestMethod()]
        public void DisminuirStockTest()
        {
            var controlStock = new Logic(30);
            var stockADisminuir = 10;
            var expectedResult = 20;

            // act
            var result = controlStock.DisminuirStock(stockADisminuir);

            // assert
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod()]
        [ExpectedException(typeof(StockInsuficienteException))]
        public void DisminuirStock_StockInsuficioente_ThrowsCustomException()
        {
            // arrange
            var controlStock = new Logic(30);
            var stockADisminuir = 31;

            // act
            var result = controlStock.DisminuirStock(stockADisminuir);
        }

        [TestMethod()]
        public void DisminuirStock_StockInsuficioente_ThrowsCustomExceptionMessage()
        {
            // arrange
            var controlStock = new Logic(30);
            var stockADisminuir = 31;

            try
            {
                // act
                var result = controlStock.DisminuirStock(stockADisminuir);
            }
            catch (StockInsuficienteException ex)
            {
                Assert.IsTrue(ex.Message.Contains("Stock insuficiente"));
            }
        }
    }
}
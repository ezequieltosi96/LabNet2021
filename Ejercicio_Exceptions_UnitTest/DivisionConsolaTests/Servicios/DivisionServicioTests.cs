using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DivisionConsola.Servicios.Tests
{
    [TestClass()]
    public class DivisionServicioTests
    {
        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZeroTest_ThrowsException()
        {
            // arrange
            var value = 10m;

            var divisionServicio = new DivisionServicio();

            // act 
            divisionServicio.DivideByZero(value);
        }

        [TestMethod()]
        public void DivideTest()
        {
            // arrange
            var dividend = 10m;
            var divider = 2m;
            var expectedResult = 5m;

            var divisionServicio = new DivisionServicio();

            // act
            var result = divisionServicio.Divide(dividend, divider);

            // assert
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Divide_DividerIsZero_ThrowsException()
        {
            // arrange
            var dividend = 10m;
            var divider = 0m;

            var divisionServicio = new DivisionServicio();

            // act
            var result = divisionServicio.Divide(dividend, divider);
        }

        [TestMethod()]
        public void Divide_DividerIsZero_ThrowsExceptionMessage()
        {
            // arrange
            var dividend = 10m;
            var divider = 0m;

            var divisionServicio = new DivisionServicio();

            try
            {
                // act
                var result = divisionServicio.Divide(dividend, divider);
            }
            catch (DivideByZeroException ex)
            {
                // assert
                Assert.IsTrue(ex.Message.Contains("Solo Chuck Norris puede dividir por cero!"));
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Divide_ArgumentsAreNotNumbers_ThrowsException()
        {
            // arrange
            var dividend = 10m;
            decimal? divider = null;

            var divisionServicio = new DivisionServicio();

            // act
            var result = divisionServicio.Divide(dividend, divider);
        }

        [TestMethod()]
        public void Divide_ArgumentsAreNotNumbers_ThrowsExceptionMessage()
        {
            // arrange
            var dividend = 10m;
            decimal? divider = null;

            var divisionServicio = new DivisionServicio();

            try
            {
                // act
                var result = divisionServicio.Divide(dividend, divider);
            }
            catch (InvalidOperationException ex)
            {
                // assert
                Assert.IsTrue(ex.Message.Contains("Seguro ingresó una letra ó no ingresó nada!"));
            }
        }
    }
}
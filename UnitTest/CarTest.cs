using Microsoft.VisualStudio.TestTools.UnitTesting;
using NunitTester.Models;
using System;

namespace UnitTest
{
    [TestClass]
    public class CarTest
    {
        public TestContext TestContext { get; set; }

        private static TestContext _testContext;

        private Car car;

        [ClassInitialize]
        public static void SetupTests(TestContext testContext)
        {
            _testContext = testContext;
        }

        [TestInitialize]
        public void SetupTest()
        {
            car = new Car
            {
                CarId = 1,
                Model = "Tesla Model S",
                Year = 2020,
                Manufacturer = "Tesla"
            };
        }

        [TestCleanup]
        public void CleanupTest()
        {
            car = null;
        }

        [TestMethod]
        public void ReturnsCarInfo()
        {
            Assert.IsNotNull(car.GetCarInfo());
        }

        [TestMethod]
        public void IsNewCar_ShouldReturnFalse_WhenCarIsNotNew()
        {
            var result = car.IsNewCar();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsNewCar_ShouldReturnTrue_WhenCarIsNew()
        {
            car.Year = DateTime.Now.Year;
            var result = car.IsNewCar();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetCarAge_ShouldReturnCorrectAge()
        {
            var result = car.GetCarAge();
            int expectedAge = DateTime.Now.Year - 2020;
            Assert.AreEqual(expectedAge, result);
        }

        [TestMethod]
        [DataRow("Tesla Model 3", 2021, "Tesla", "Model: Tesla Model 3, Manufacturer: Tesla, Year: 2021, CarId: 0")]
        [DataRow("Ford Mustang", 2018, "Ford", "Model: Ford Mustang, Manufacturer: Ford, Year: 2018, CarId: 0")]
        [DataRow("Toyota Corolla", 2022, "Toyota", "Model: Toyota Corolla, Manufacturer: Toyota, Year: 2022, CarId: 0")]
        public void ReturnsCarInfo_ForDifferentCars(string model, int year, string manufacturer, string expectedInfo)
        {
            var testCar = new Car
            {
                CarId = 0,
                Model = model,
                Year = year,
                Manufacturer = manufacturer
            };
            var carInfo = testCar.GetCarInfo();
            Assert.AreEqual(expectedInfo, carInfo);
        }

        [TestMethod]
        [DataRow(2024, true)]
        [DataRow(2019, false)]
        public void IsNewCar_ForDifferentYears(int year, bool expected)
        {
            car.Year = year;
            var result = car.IsNewCar();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(2020, 4)]
        [DataRow(2015, 9)]
        [DataRow(1999, 25)]
        public void GetCarAge_ForDifferentYears(int year, int expectedAge)
        {
            car.Year = year;
            var result = car.GetCarAge();
            Assert.AreEqual(expectedAge, result);
        }
    }
}

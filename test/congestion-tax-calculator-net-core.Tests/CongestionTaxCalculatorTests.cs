using congestion.calculator;
using congestion.calculator.Service;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xunit;

namespace congestion_tax_calculator_net_core.Tests
{
    public class CongestionTaxCalculatorTests :  IClassFixture<TaxCalculatorTestFixture>
    {
        private CongestionTaxCalculator calculator;
        private TaxCalculatorTestFixture _testFixture;
        public CongestionTaxCalculatorTests(TaxCalculatorTestFixture fixture)
        {
            _testFixture = fixture;
            calculator = new CongestionTaxCalculator(_testFixture.TollTaxRules, _testFixture.TollFreeVehicles);
        }
        [Theory]
        [InlineData(VehicleEnum.Car, "", 0)]
        [InlineData(VehicleEnum.Car, "2013-01-14 21:00:00", 0)]
        [InlineData(VehicleEnum.Car, "2013-01-15 8:00:00", 13)]
        public void GetTax_SinglePassWithinOneHour_ReturnsCorrectFee(VehicleEnum vehicle , string datesStr, int expectedFee)
        {
            // Arrange
            IVehicle v = VehicleFactory.Create(vehicle);
            var dateTimes = new List<DateTime>();
            string[] dates = datesStr.Split(";");
            foreach (string date in dates)
            {
                if(!string.IsNullOrWhiteSpace(date))
                    dateTimes.Add(DateTime.Parse(date));
            }
            // Act
            int result = calculator.GetTax(v, dateTimes.ToArray());

            // Assert
            Assert.Equal(expectedFee, result);
        }
        [Theory]
        [InlineData(VehicleEnum.Car, "2013-02-07 06:23:27;2013-02-07 15:27:00", 21)]
        [InlineData(VehicleEnum.Car, "2013-02-08 06:20:27;2013-02-08 06:27:00;2013-02-08 14:35:00;2013-02-08 15:29:00", 21)]
        [InlineData(VehicleEnum.Car, "2013-02-08 17:49:00;2013-02-08 18:29:00;2013-02-08 18:35:00", 13)]
        public void GetTax_MultiplePassesWithinOneHour_ReturnsCorrectTotalFee(VehicleEnum vehicle, string datesStr, int expectedFee)
        {
            // Arrange
            IVehicle v = VehicleFactory.Create(vehicle);
            var dateTimes = new List<DateTime>();
            string[] dates = datesStr.Split(";");
            foreach (string date in dates)
            {
                if (!string.IsNullOrWhiteSpace(date))
                    dateTimes.Add(DateTime.Parse(date));
            }

            // Act
            int result = calculator.GetTax(v, dateTimes.ToArray());

            // Assert
            Assert.Equal(expectedFee, result);
        }

        [Theory]
        [InlineData(VehicleEnum.Motorcycle, "2013-02-07 06:23:27", 0)]
        public void GetTax_TollFreeVehicle_ReturnsZero(VehicleEnum vehicle, string datesStr, int expectedFee)
        {
            // Arrange
            IVehicle v = VehicleFactory.Create(vehicle);
            var dateTimes = new List<DateTime>();
            string[] dates = datesStr.Split(";");
            foreach (string date in dates)
            {
                if (!string.IsNullOrWhiteSpace(date))
                    dateTimes.Add(DateTime.Parse(date));
            }

            // Act
            int result = calculator.GetTax(v, dateTimes.ToArray());

            // Assert
            Assert.Equal(expectedFee, result);
        }

        [Theory]
        [InlineData(VehicleEnum.Car, "2013-03-28 14:07:27", 0)]
        public void GetTax_TollFreeDate_ReturnsZero(VehicleEnum vehicle, string datesStr, int expectedFee)
        {
            // Arrange
            IVehicle v = VehicleFactory.Create(vehicle);
            var dateTimes = new List<DateTime>();
            string[] dates = datesStr.Split(";");
            foreach (string date in dates)
            {
                if (!string.IsNullOrWhiteSpace(date))
                    dateTimes.Add(DateTime.Parse(date));
            }

            // Act
            int result = calculator.GetTax(v, dateTimes.ToArray());

            // Assert
            Assert.Equal(expectedFee, result);
        }
        [Theory]
        [InlineData(VehicleEnum.Car, "2013-02-08 06:00:27;2013-02-08 07:01:00;2013-02-08 08:03:00;2013-02-08 14:35:00;2013-02-08 15:29:00;2013-02-08 15:47:00;2013-02-08 16:01:00;2013-02-08 16:48:00;2013-02-08 17:49:00;2013-02-08 18:29:00;2013-02-08 18:35:00", 60)]
        public void GetTax_ShouldReachMaxAmountPerDay_ReturnsMaxFee(VehicleEnum vehicle, string datesStr, int expectedFee)
        {
            // Arrange
            IVehicle v = VehicleFactory.Create(vehicle);
            var dateTimes = new List<DateTime>();
            string[] dates = datesStr.Split(";");
            foreach (string date in dates)
            {
                if (!string.IsNullOrWhiteSpace(date))
                    dateTimes.Add(DateTime.Parse(date));
            }

            // Act
            int result = calculator.GetTax(v, dateTimes.ToArray());

            // Assert
            Assert.Equal(expectedFee, result);
        }
        [Theory]
        [InlineData(VehicleEnum.Car, "2013-02-08 14:35:00;2013-02-08 15:29:00", 13)]
        public void GetTax_Passwithin60Min_ReturnMaxFee(VehicleEnum vehicle, string datesStr, int expectedFee)
        {
            // Arrange
            IVehicle v = VehicleFactory.Create(vehicle);
            var dateTimes = new List<DateTime>();
            string[] dates = datesStr.Split(";");
            foreach (string date in dates)
            {
                if (!string.IsNullOrWhiteSpace(date))
                    dateTimes.Add(DateTime.Parse(date));
            }

            // Act
            int result = calculator.GetTax(v, dateTimes.ToArray());

            // Assert
            Assert.Equal(expectedFee, result);
        }
    }
}

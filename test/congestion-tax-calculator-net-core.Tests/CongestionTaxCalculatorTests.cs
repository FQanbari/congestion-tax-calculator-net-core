using congestion.calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace congestion_tax_calculator_net_core.Tests
{
    public class CongestionTaxCalculatorTests
    {
        private CongestionTaxCalculator calculator;

        public CongestionTaxCalculatorTests()
        {
            calculator = new CongestionTaxCalculator();
        }
        [Theory]
        [InlineData(VehicleEnum.Car, "", 0)]
        [InlineData(VehicleEnum.Car, "2013-01-14 21:00:00", 0)]
        [InlineData(VehicleEnum.Car, "2013-01-15 8:00:00", 13)]
        public void GetTax_SinglePassWithinOneHour_ReturnsCorrectFee(VehicleEnum vehicle , string datesStr, int expectedFee)
        {
            // Arrange
            Vehicle v = VehicleFactory.Create(vehicle);
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
            Vehicle v = VehicleFactory.Create(vehicle);
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
            Vehicle v = VehicleFactory.Create(vehicle);
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
            Vehicle v = VehicleFactory.Create(vehicle);
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

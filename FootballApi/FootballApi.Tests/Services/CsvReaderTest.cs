using System;
using NUnit.Framework;
using FootballApi.Services;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace FootballApi.Tests.Services
{
    [TestFixture]
    public class CsvReaderTest
    {
        [Test]
        public void ReadDataFromCsv_NotCsv()
        {
            //Arrange
            var csvReader = new CsvReader();       


            //Assert
            var ex = Assert.Throws<Exception>(() => csvReader.ReadDataFromCsv("abc.txt"));
            Assert.That(ex.Message, Is.EqualTo("Not a csv file"));

        }

        [Test]
        public void ReadDataFromCsv_NotFound()
        {
            //Arrange
            var csvReader = new CsvReader();


            //Assert
            var ex = Assert.Throws<Exception>(() => csvReader.ReadDataFromCsv("abc.csv"));
            Assert.That(ex.Message, Is.EqualTo("File not found"));

        }


    }
}

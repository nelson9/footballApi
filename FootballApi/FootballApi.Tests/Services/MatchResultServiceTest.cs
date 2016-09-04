using System;
using NUnit.Framework;
using FootballApi.Services;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace FootballApi.Tests.Services
{
    [TestFixture]
    public class MatchResultServiceTest
    {
        [Test]
        public void GetMatchResultsFromCsv_ValidCsv_ReturnsList()
        {
            //Arrange
            string filePath = @"C:\Users\Niall\Documents\GitHub\footballApi\FootballApi\FootballApi\input.csv";
            var csvReader = new Mock<ICsvReader>();
            var matchResultService = new MatchResultService(csvReader.Object);
            var lines = new List<string>
            {                
                "1,Bournemouth,Aston Villa,0,1",
                "1,Chelsea,Swansea,2,2"
            };

            csvReader.Setup(x => x.ReadDataFromCsv(It.IsAny<string>())).Returns(lines);

            //Act
            var results = matchResultService.GetMatchResultsFromCsv(filePath).ToList();

            //Assert
            Assert.AreEqual(2, results.ToList().Count);
        }
        
        [Test]     
        public void GetMatchResultsFromCsv_InvalidCsv_FormatException()
        {
            //Arrange
            string filePath = @"C:\Users\Niall\Documents\GitHub\footballApi\FootballApi\FootballApi\input.csv";
            var csvReader = new Mock<ICsvReader>();
            var matchResultService = new MatchResultService(csvReader.Object);
            var lines = new List<string>
            {
                "Error,Bournemouth,Aston Villa,0"
            };

            csvReader.Setup(x => x.ReadDataFromCsv(It.IsAny<string>())).Returns(lines);

            //Act
            var ex = Assert.Throws<FormatException>(() => matchResultService.GetMatchResultsFromCsv(filePath).ToList());
         
        }       
    }
}

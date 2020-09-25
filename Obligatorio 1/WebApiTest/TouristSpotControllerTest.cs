using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Out;
using Moq;
using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.Domain;
using Obligatorio.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebApiTest
{
    [TestClass]
    public class TouristSpotControllerTest
    {
        [TestMethod]
        public void TestGetAllTouristSpotsOk()
        {
            IEnumerable<TouristSpot> touristSpotsToReturn = new List<TouristSpot>()
            {
                new TouristSpot()
                {
                    Id = 1,
                    Name = "Faro de La Paloma",
                    Description = "Very tall. Traditional.",
                    Image = "image",
                    Region = new Region(),
                },
                new TouristSpot()
                {
                    Id = 2,
                    Name = "Playa de los Pescadores",
                    Description = "Cozy, humble.",
                    Image = "image2",
                    Region = new Region(),
                }
            };

            var mock = new Mock<ITouristSpotLogic>(MockBehavior.Strict);
            mock.Setup(ts => ts.GetAll()).Returns(touristSpotsToReturn);
            var controller = new TouristSpotController(mock.Object);

            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var touristSpots = okResult.Value as IEnumerable<TouristSpotBasicInfoModel>;

            mock.VerifyAll();
            Assert.IsTrue(touristSpotsToReturn.Select(ts => new TouristSpotBasicInfoModel(ts)).SequenceEqual(touristSpots));
            //Assert.IsTrue(true);


        }
    }
}

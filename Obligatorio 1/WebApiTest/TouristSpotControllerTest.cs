using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Models.Out;
using Moq;
using Obligatorio.BusinessLogic.CustomExceptions;
using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.Domain;
using Obligatorio.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RepeatedObjectException = Obligatorio.BusinessLogic.CustomExceptions.RepeatedObjectException;

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
            var touristSpots = okResult.Value as IEnumerable<TouristSpotModel>;

            mock.VerifyAll();
            Assert.IsTrue(touristSpotsToReturn.Select(ts=>new TouristSpotModel(ts)).SequenceEqual(touristSpots));
        }

        [TestMethod]
        public void TestGetByIdNotFound()
        {
            var mock = new Mock<ITouristSpotLogic>(MockBehavior.Strict);
            mock.Setup(ts => ts.Get(3)).Throws(new ObjectNotFoundInDatabaseException());
            var controller = new TouristSpotController(mock.Object);

            var result = controller.Get(3) as NotFoundObjectResult;
            var expectedResult = new NotFoundObjectResult("There is no such tourist spot id.");

            mock.VerifyAll();
            Assert.AreEqual(expectedResult.Value, result.Value);
        }

        [TestMethod]
        public void TestGetByIdFound()
        {
            TouristSpot touristSpotToReturn = new TouristSpot()
            {
                Id = 1,
                Name = "Faro de La Paloma",
                Description = "Very tall. Traditional.",
                Image = "image",
                Region = new Region(),
            };
            TouristSpotModel modelToReturn = new TouristSpotModel(touristSpotToReturn);
            var mock = new Mock<ITouristSpotLogic>(MockBehavior.Strict);
            mock.Setup(ts => ts.Get(1)).Returns(touristSpotToReturn);
            var controller = new TouristSpotController(mock.Object);

            var result = controller.Get(1);
            var okResult = result as OkObjectResult;
            var touristSpot = okResult.Value as TouristSpotModel;

            mock.VerifyAll();
            Assert.IsTrue(touristSpot.Equals(modelToReturn));
        }

        [TestMethod]
        public void TestPostAlreadyExistingObject()
        {
            TouristSpot touristSpot = new TouristSpot()
            {
                Id = 1,
                Name = "Virgen del verdún",
            };
            TouristSpotModel touristSpotModel = new TouristSpotModel(touristSpot);
            var mock = new Mock<ITouristSpotLogic>(MockBehavior.Strict);
            mock.Setup(ts => ts.Add(touristSpot)).Throws(new RepeatedObjectException());
            var controller = new TouristSpotController(mock.Object);

            var result = controller.Post(touristSpotModel) as BadRequestObjectResult;
            var expectedResult = new BadRequestObjectResult("A tourist spot with such id has been already registered.");

            mock.VerifyAll();
            Assert.AreEqual(expectedResult.Value, result.Value);
        }

        [TestMethod]
        public void TestSuccessfulPost()
        {

        }
    }
}

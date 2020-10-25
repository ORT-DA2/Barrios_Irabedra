using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Models.In;
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
                },
                new TouristSpot()
                {
                    Id = 2,
                    Name = "Playa de los Pescadores",
                    Description = "Cozy, humble.",
                    Image = "image2",
                }
            };

            var mock = new Mock<ITouristSpotLogic>(MockBehavior.Strict);
            mock.Setup(ts => ts.GetAll()).Returns(touristSpotsToReturn);
            var controller = new TouristSpotController(mock.Object);

            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var touristSpots = okResult.Value as IEnumerable<TouristSpotModelOut>;

            mock.VerifyAll();
            Assert.IsTrue(touristSpotsToReturn.Select(ts => new TouristSpotModelOut(ts)).SequenceEqual(touristSpots));
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
            };
            TouristSpotModelOut modelToReturn = new TouristSpotModelOut(touristSpotToReturn);
            var mock = new Mock<ITouristSpotLogic>(MockBehavior.Strict);
            mock.Setup(ts => ts.Get(1)).Returns(touristSpotToReturn);
            var controller = new TouristSpotController(mock.Object);

            var result = controller.Get(1);
            var okResult = result as OkObjectResult;
            var touristSpot = okResult.Value as TouristSpotModelOut;

            mock.VerifyAll();
            Assert.IsTrue(touristSpot.Equals(modelToReturn));
        }
       

        [TestMethod]
        public void TestPostAlreadyExistingObject()
        {
            TouristSpot touristSpot = new TouristSpot()
            {
                Name = "Virgen del verdún",
            };
            TouristSpotModelIn touristSpotModel = new TouristSpotModelIn(touristSpot);
            var mock = new Mock<ITouristSpotLogic>(MockBehavior.Strict);
            mock.Setup(ts => ts.Add(touristSpot)).Throws(new RepeatedObjectException());
            var controller = new TouristSpotController(mock.Object);

            var result = controller.Post(touristSpotModel) as BadRequestObjectResult;
            var expectedResult = new BadRequestObjectResult("A tourist spot with such name has been already registered.");

            mock.VerifyAll();
            Assert.AreEqual(expectedResult.Value, result.Value);
        }

        [TestMethod]
        public void TestSuccessfulPost()
        {
            TouristSpot touristSpot = new TouristSpot()
            {
                Name = "Virgen del verdún",
            };
            TouristSpotModelIn touristSpotModel = new TouristSpotModelIn(touristSpot);
            var mock = new Mock<ITouristSpotLogic>(MockBehavior.Strict);
            mock.Setup(ts => ts.Add(touristSpot));
            var controller = new TouristSpotController(mock.Object);

            var result = controller.Post(touristSpotModel) as CreatedAtRouteResult;
            var expectedResult = new CreatedAtRouteResult(routeValues: new { id = touristSpotModel.Id },
                                                        value: new TouristSpotModelIn(touristSpot));

            mock.VerifyAll();
            Assert.AreEqual(expectedResult.Value, result.Value);
        }

        [TestMethod]
        public void TestSuccessfulDelete()
        {
            TouristSpot touristSpot = new TouristSpot()
            {
                Name = "Virgen del verdún",
                Id = 3
            };
            TouristSpotModelIn touristSpotModel = new TouristSpotModelIn(touristSpot);
            var mock = new Mock<ITouristSpotLogic>(MockBehavior.Strict);
            mock.Setup(ts => ts.Delete(3));
            var controller = new TouristSpotController(mock.Object);

            var result = controller.Delete(touristSpotModel.Id) as OkObjectResult;
            var expectedResult = new OkObjectResult("Success.");

            mock.VerifyAll();
            Assert.AreEqual(expectedResult.Value, result.Value);
        }

        [TestMethod]
        public void TestDeleteNotFoundObject()
        {
            TouristSpot touristSpot = new TouristSpot()
            {
                Name = "Virgen del verdún",
                Id = 3
            };
            TouristSpotModelIn touristSpotModel = new TouristSpotModelIn(touristSpot);
            var mock = new Mock<ITouristSpotLogic>(MockBehavior.Strict);
            mock.Setup(ts => ts.Delete(3)).Throws(new ObjectNotFoundInDatabaseException());
            var controller = new TouristSpotController(mock.Object);

            var result = controller.Delete(touristSpotModel.Id) as NotFoundObjectResult;
            var expectedResult = new NotFoundObjectResult("There is no tourist spot with such id.");

            mock.VerifyAll();
            Assert.AreEqual(expectedResult.Value, result.Value);
        }

        [TestMethod]
        public void TestPutSuccessful()
        {
            TouristSpot touristSpotToUpdate = new TouristSpot()
            {
                Name = "Virgen del verdún",
                Id = 3
            };
            TouristSpot newData = new TouristSpot()
            {
                Name = "The Green Roofs",
            };
            TouristSpotModelIn touristSpotModelToUpdate = new TouristSpotModelIn(touristSpotToUpdate);
            TouristSpotModelIn newDataModel = new TouristSpotModelIn(newData);
            var mock = new Mock<ITouristSpotLogic>(MockBehavior.Strict);
            mock.Setup(ts => ts.Update(touristSpotModelToUpdate.Id, newData));
            mock.Setup(ts => ts.Get(touristSpotToUpdate.Id)).Returns(touristSpotToUpdate);
            var controller = new TouristSpotController(mock.Object);

            var result = controller.Put(touristSpotModelToUpdate.Id, newDataModel) as OkObjectResult;
            var expectedResult = new OkObjectResult(new TouristSpotModelOut(touristSpotToUpdate));

            mock.VerifyAll();
            Assert.AreEqual(expectedResult.Value, result.Value);
        }

        [TestMethod]
        public void TestPutNotFoundObject()
        {
            TouristSpot touristSpotToUpdate = new TouristSpot()
            {
                Name = "Virgen del verdún",
                Id = 3
            };
            TouristSpot newData = new TouristSpot()
            {
                Name = "The Green Roofs",
            };
            TouristSpotModelIn touristSpotModelToUpdate = new TouristSpotModelIn(touristSpotToUpdate);
            TouristSpotModelIn newDataModel = new TouristSpotModelIn(newData);
            var mock = new Mock<ITouristSpotLogic>(MockBehavior.Strict);

            mock.Setup(ts => ts.Update(touristSpotModelToUpdate.Id, newData));
            mock.Setup(ts => ts.Get(touristSpotToUpdate.Id)).Throws(new ObjectNotFoundInDatabaseException());
            var controller = new TouristSpotController(mock.Object);

            var result = controller.Put(touristSpotModelToUpdate.Id, newDataModel) as NotFoundObjectResult;
            var expectedResult = new NotFoundObjectResult("There is no tourist spot with such id.");

            mock.VerifyAll();
            Assert.AreEqual(expectedResult.Value, result.Value);
        }
    }
}

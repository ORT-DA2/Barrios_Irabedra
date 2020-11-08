using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.Domain;
using Obligatorio.Domain.AuxiliaryObjects;
using Obligatorio.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebApiTest
{
    [TestClass]
    public class AccommodationControllerTest
    {
        [TestMethod]
        public void DeleteAccommodationOk()
        {
            Accommodation acc = new Accommodation()
            {
                Id = 1,
                Name = "Hotel Faro de La Paloma",
                Description = "Cozy.",
                Address = "Somewhere",
                FullCapacity = true,
                Images = new List<ImageWrapper>(),
                PricePerNight = 700,
                Rating = 5,
                TouristSpot = new TouristSpot()
            };
            

            var mock = new Mock<IAccommodationLogic>(MockBehavior.Strict);
            mock.Setup(ac => ac.Delete(acc.Name));
            var controller = new AccommodationController(mock.Object);
            var result = controller.Delete("Hotel Faro de La Paloma") as OkObjectResult;
            var expectedResult = new OkObjectResult("Success");

            mock.VerifyAll();
            Assert.AreEqual(result.Value, expectedResult.Value);
        }
    }

}

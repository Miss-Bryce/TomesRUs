using TomesRUs.Controllers;
using TomesRUs.Data;
using TomesRUs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AssignmentUnitTest
{
    [TestClass]
    public class AuthorControllerTest
    {
        List<Author> author = new List<Author>();
        AuthorsController controller;
        private ApplicationDbContext _context;

        [TestInitialize]
        public void AuthorInitialize()
        {

            //arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            _context = new ApplicationDbContext(options);

            author.Add(new Author { FirstName = "John", LastName = "Kindred", Origin = "Scotland", Status = Author.AuthorStatus.Active }); ;
            author.Add(new Author { FirstName = "Sally", LastName = "Samwain", Origin = "England", Status = Author.AuthorStatus.Deceased });
            author.Add(new Author { FirstName = "Anne", LastName = "Paltin", Origin = "Serbia", Status = Author.AuthorStatus.Retired });

            //act
            foreach (var x in author)
            {
                _context.Author.Add(x);
            }
            _context.SaveChanges();

            controller = new AuthorsController(_context);

            var resultsOne = (ViewResult)controller.Create();

            //assert
            Assert.IsNotNull(resultsOne);

        }

        [TestMethod]
        public void IndexLoadsIndexView()
        {
            // arrange is all done in TestInitialize

            // act
            var resultsTwo = (ViewResult)controller.Index().Result;
            // assert
            Assert.IsNotNull(resultsTwo);
        }

        [TestMethod]
        public void IndexReturnsList()
        {
            // act
            var resultsThree = (ViewResult)controller.Index().Result;
            List<Author> model = (List<Author>)resultsThree.Model;

            // compare the model from the Index method call to the list of mock products in our in-memory db
            CollectionAssert.AreEqual(author.ToList(), model);
        }


        [TestMethod]
        public void DetailsNull()
        {
            // act - Get invalid detail
            var resultsFour = (ViewResult)controller.Details(null).Result;
            Console.WriteLine(resultsFour);

            // assert - return null
            Assert.AreEqual(null, resultsFour.ViewName);
        }

        [TestMethod]
        public void DetailsLoad()
        {
            // act - use any Id but 37, 64, 56 as these are all valid ids in the in-memory db
            var resultsFive = (ViewResult)controller.Details(1).Result;
            Console.WriteLine(resultsFive);

            // assert - could also be "Error" expected instead of 404 depending on logic in Details() 
            Assert.AreEqual("Details", resultsFive.ViewName);
        }

        [TestMethod]
        public void DetailsReturnMatch()
        {
            // act - Select detail
            var resultSix = (ViewResult)controller.Details(1).Result;
            var model = (Author)resultSix.Model;

            // assert - get the matching detail
            Assert.AreEqual(author[0], model);
        }

    }
}

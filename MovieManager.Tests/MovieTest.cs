using Moq;
using MovieManager.Logic;
using MovieManager.Models;
using MovieManager.Repository;
using NUnit.Framework;

namespace MovieManager.Tests
{
    [TestFixture]
    public class MovieTest
    {
        MovieLogic logic;
        
        [SetUp]
        public void Init()
        {
            var movies = new List<Movie>()
            {
                new Movie(1, "A", 1000, 2, new DateTime(2002, 1,1), 8),
                new Movie(2, "B", 1000, 2, new DateTime(2003, 1,1), 6),
                new Movie(3, "C", 1000, 2, new DateTime(2002, 1,1), 7),
                new Movie(4, "D", 1000, 2, new DateTime(2004, 1,1), 5),
            };

            Mock<IMovieRepository> mockrepo = new Mock<IMovieRepository>();

            mockrepo.Setup(m => m.ReadAll()).Returns(movies.AsQueryable());
            
            logic = new MovieLogic(mockrepo.Object);
        }

        [Test]
        public void LinqTest01()
        {
            var result = logic.GetAverageRatePerYear(2002);
            Assert.That(result == 7.5);
        }


    }
}

using Moq;
using MovieManager.Logic;
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
            Mock<IMovieRepository> mockrepo = new Mock<IMovieRepository>();
            logic = new MovieLogic(mockrepo.Object);
        }
    }
}

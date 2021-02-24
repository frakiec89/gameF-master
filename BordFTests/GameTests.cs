using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace BordF.Tests
{
    [TestClass()]
    public class GameTests
    {
        [TestMethod()]
        public void StartTest()
        {
            Game game = new Game(4);
            game.Start();
            Assert.AreEqual(1, game.GetDigitAt(0, 0));
            Assert.AreEqual(2, game.GetDigitAt(1, 0));
            Assert.AreEqual(5, game.GetDigitAt(0, 1));
        }
        
    }
}
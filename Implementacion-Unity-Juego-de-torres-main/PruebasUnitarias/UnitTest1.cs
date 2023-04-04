using System.Diagnostics;

namespace PruebasUnitarias
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Player player = new Player();

            Enemy strongerEnemy = new Enemy();
            Enemy weakerEnemy = new Enemy();

            player.Poder = 2;
            weakerEnemy.Poder = 1;
            strongerEnemy.Poder = 3;

            Assert.IsTrue(player.DefeatEnemy(weakerEnemy.Poder));
            Assert.IsFalse(player.DefeatEnemy(strongerEnemy.Poder));
        }
    }
}
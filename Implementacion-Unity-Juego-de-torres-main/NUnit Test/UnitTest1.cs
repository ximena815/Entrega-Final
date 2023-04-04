namespace NUnit_Test
{
    public class Tests
    {
        [SetUp]
        public void Setup() { }        

        [Test]
        public void PlayerRandomPower() //Se le inicializa un poder aleatorio al player
        {
            Player player1 = new Player();
            Player player2 = new Player();
            Player player3 = new Player();

            player1.GenerarPoder();
            player2.GenerarPoder();
            player3.GenerarPoder();

            bool isOneDifferent = false;

            if (player1.Poder != player2.Poder || player1.Poder != player3.Poder || player2.Poder != player3.Poder)
                isOneDifferent = true;

            Assert.IsTrue(isOneDifferent);
        }

        public void EnemyHasArbitraryPower() //Se le puede asignar un valor arbitrario al poder del enemigo
        {
            Enemy enemy = new Enemy();
            int poder = 5;
            enemy.GenerarPoder(poder);
            Assert.That(poder.Equals(enemy.Poder));
        }

        [Test]
        public void PlayerWinsToWeakerEnemy() //Player le gana a enemigo más debil
        {
            Player player = new Player();
            Enemy weakerEnemy = new Enemy();

            player.Poder = 2;
            weakerEnemy.Poder = 1;

            Assert.IsTrue(player.DefeatEnemy(weakerEnemy.Poder));          
        }

        [Test]
        public void PlayerLoseToStrongerEnemy() //Player pierde contra enemigo más fuerte
        {
            Player player = new Player();
            Enemy strongerEnemy = new Enemy();

            player.Poder = 2;
            strongerEnemy.Poder = 3;

            Assert.IsFalse(player.DefeatEnemy(strongerEnemy.Poder));
        }

        [Test]
        public void PlayerCanLose() //La vida del player baja y llega a 0
        {
            Player player = new Player();
            Enemy strongerEnemy = new Enemy();

            player.Poder = 2;
            player.Vidas = 3;
            strongerEnemy.Poder = 3;

            player.DefeatEnemy(strongerEnemy.Poder);
            player.DefeatEnemy(strongerEnemy.Poder);
            player.DefeatEnemy(strongerEnemy.Poder);

            bool playerCanLose = false;
            if (player.Vidas <= 0) playerCanLose = true;

            Assert.IsTrue(playerCanLose);
        }

        [Test]
        public void PlayerLoseToEqualStrenghtEnemy() //Player pierde contra enemigo con mismo poder
        {
            Player player = new Player();
            Enemy enemy = new Enemy();

            player.Poder = 3;
            enemy.GenerarPoder(3);

            Assert.IsFalse(player.DefeatEnemy(enemy.Poder));
        }
    }
}
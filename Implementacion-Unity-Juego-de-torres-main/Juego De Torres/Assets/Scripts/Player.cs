using UnityEngine;

public class Player
{
    private int vidas = 3;
    public int Vidas { get => vidas; set => vidas = value; }

    private int poder = 5;
    public int Poder { get => poder; set => poder = value; }

    public bool DefeatEnemy(int poderEnemigo)
    {
        if (poderEnemigo >= poder)
        {
            vidas--;
            return false;
        }
        else
        {
            poder += poderEnemigo;
            return true;
        }
    }
}

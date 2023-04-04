using System.Net;
using UnityEngine;

public class Player
{
    private int vidas = 3;
    public int Vidas { get => vidas; set => vidas = value; }

    private int poder = 5;
    public int Poder { get => poder; set => poder = value; }

    private int nivelTorre = 1;
    public int NivelTorre { get => nivelTorre; set => nivelTorre = value; }

    public void GenerarPoder()
    {
        System.Random random = new System.Random();
        poder = random.Next(5,20);
    }
    
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

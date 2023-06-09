using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameWinUI;
    public GameObject gameOverUI;
    
    [SerializeField]
    private int EnemyCount;

    void Start()
    {
        gameOverUI.SetActive(false);
        gameWinUI.SetActive(false);
        PlayerManager.Instance.EnemyDestroy += ReduceEnemyCount;
    }

    void Update()
    {
        if (PlayerManager.Instance.Player.Vidas <= 0 )
        {
            gameOverUI.SetActive(true);
        }
        if (EnemyCount == 0)
        {
            gameWinUI.SetActive(true);
        }

    }

    private void ReduceEnemyCount()
    {
        EnemyCount--;
    }
}
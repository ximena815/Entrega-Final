using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerManager : MonoBehaviour
{
    // Este player se usa en las pruebas unitarias
    private Player player;
    public Player Player { get => player; }

    private static PlayerManager instance;
    public static PlayerManager Instance { get => instance; }

    public event Action EnemyDestroy;

    public Text vidasText;
    private TextMesh poderText;
    public int playerpower;
    public int playerlife;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
       player = new Player();
       //poderText.text = player.Poder.ToString();
       poderText= this.GetComponentInChildren<TextMesh>();
    }
   
    void Update()
    {
        playerpower = player.Poder;
        playerlife = player.Vidas;
        vidasText.text = "Vidas: " + player.Vidas.ToString();
        poderText.text = player.Poder.ToString();
        if (player.Vidas <= 0)
        {
            gameObject.SetActive(false);
        }

    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")&& Draggable.isDragged== false)
        {
            int poderEnemigo = collision.gameObject.GetComponent<EnemyController>().Enemy.Poder;
            if (player.DefeatEnemy(poderEnemigo)) 
            {
                collision.GetComponent<EnemyController>().DestroyEnemy();
                //EnemyDestroy?.Invoke();
            }
            else
            {
                Draggable.isDragged = true;
                RestartPos();
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AttackPoint"))
        {
            RestartPos();
        }
    }
  
    public void RestartPos()
    {
        GetComponent<Draggable>().RestartPosition();      
    } 
}

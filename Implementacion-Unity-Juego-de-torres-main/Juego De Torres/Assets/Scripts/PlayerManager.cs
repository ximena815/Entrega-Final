using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerManager : MonoBehaviour
{
    private Player player;
    public Player Player { get => player; }

    private static PlayerManager instance;
    public static PlayerManager Instance { get => instance; }

    public event Action EnemyDestroy;

    public Text vidasText;
    private TextMesh poderText;

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
            int poderEnemigo = collision.gameObject.GetComponent<Enemy>().Poder;
            if (player.DefeatEnemy(poderEnemigo)) 
            {
                collision.GetComponent<Enemy>().DestroyEnemy();
                EnemyDestroy?.Invoke();
            }
            else
            {
                Draggable.isDragged = true;
                Invoke("RestartPos", 2f);
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Support"))
        {
            int valorSupp = collision.gameObject.GetComponent<Support>().Valor;
            player.Poder += valorSupp;
            Destroy(collision.gameObject);
        }
    }
    
    public void RestartPos()
    {
        this.GetComponent<Draggable>().RestartPosition();      
    } 
}

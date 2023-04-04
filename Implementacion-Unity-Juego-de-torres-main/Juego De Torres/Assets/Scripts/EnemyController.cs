using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Este enemy se usa en las pruebas unitarias
    private Enemy enemy;
    public Enemy Enemy { get => enemy; set => enemy = value; }

    [SerializeField] private int poderInicial;

    private TextMesh poderText;
    
    void Start()
    {
        enemy = new Enemy();
        poderText = GetComponentInChildren<TextMesh>();
        enemy.GenerarPoder(poderInicial);
    }
    void Update()
    {
        poderText.text = enemy.Poder.ToString();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            transform.localPosition = collision.transform.localPosition;
        }
    }
    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}

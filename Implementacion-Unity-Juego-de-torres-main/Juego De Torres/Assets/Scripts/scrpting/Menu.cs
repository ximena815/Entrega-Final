using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPausa;

    [SerializeField]
    private GameObject botonDePausa;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PaNivel1()
    {
        SceneManager.LoadScene("Nivel_2");
    }

    public void Pause()
    {
        menuPausa.SetActive(true);
        botonDePausa.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Replay()
    {
        menuPausa.SetActive(false);
        botonDePausa.SetActive(true);
        Time.timeScale = 1f;
    }

    public void exit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Next()
    {
        SceneManager.LoadScene("Nivel_3");
    }

}

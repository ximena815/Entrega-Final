using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GLnivel1 : MonoBehaviour
{
    [SerializeField] private GameObject uiVictory;
    [SerializeField] private GameObject uiLose;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.Instance.playerpower >= 91)
        {
            uiVictory.SetActive(true);
        }
        if (PlayerManager.Instance.playerlife <= 0)
        {
            uiLose.SetActive(true);
        }
    }
}

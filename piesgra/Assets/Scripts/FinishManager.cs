using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishManager : MonoBehaviour
{

    public LayerMask playerLayer;
    public PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.5f, playerLayer))
        {
            NextLevel();
        }
    }

    void NextLevel()
    {
        pc.WinMessage();
        if(SceneManager.GetActiveScene().buildIndex >= 5)
        {
            Debug.Log("Loading credits...");
            SceneManager.LoadScene(6);
        }
        else
        {
            Debug.Log("Loading next scene...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

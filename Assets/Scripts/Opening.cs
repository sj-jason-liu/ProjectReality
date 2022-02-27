using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Opening : MonoBehaviour
{
    public void StartGame()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //int currentIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(1);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //int currentIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(1);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("You have passed the game!");
            //Stop the game and enter game clear sprite in 2 sec
            StartCoroutine(GamePass());
        }
    }

    IEnumerator GamePass()
    {
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(2);
    }
}

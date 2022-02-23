using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealityStone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameManager.Instance.ShowReality();
            //destroy stone
            //set coroutine to return virtual after 10 second
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.Instance.DisableReality();
        }
    }
}

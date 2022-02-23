using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("GameManager is NULL!");
            }
            return _instance;
        }
    }

    [SerializeField]
    private GameObject _virtualPlatform;
    [SerializeField]
    private GameObject _realityPlatform;
    [SerializeField]
    private GameObject _virtualGround;
    [SerializeField]
    private GameObject _realityGround;

    void Awake()
    {
        _instance = this;
    }

    public void ShowReality()
    {
        //if reality stone has been activated
        //reveal the reality map
        Debug.Log("Player collected reality stone!");
        _realityGround.SetActive(true);
        _realityPlatform.SetActive(true);
        _virtualGround.SetActive(false);
        _virtualPlatform.SetActive(false);
    }

    public void DisableReality()
    {
        //if reveal-time has ended
        //recover the reality to static map
        Debug.Log("Player leave reality stone!");
        _virtualGround.SetActive(true);
        _virtualPlatform.SetActive(true);
        _realityGround.SetActive(false);
        _realityPlatform.SetActive(false);
    }
}

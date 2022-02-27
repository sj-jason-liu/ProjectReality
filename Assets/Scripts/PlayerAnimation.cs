using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        {
            if(_anim == null)
            {
                Debug.LogError("Animator is NULL!");
            }
        }
    }

    public void Move(float moveValue)
    {
        _anim.SetFloat("Move", Mathf.Abs(moveValue));
    }
}

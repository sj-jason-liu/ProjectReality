using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _movingSpeed = 3f;
    [SerializeField]
    private float _jumpForce = 5f;

    private bool _isGrounded;

    private Rigidbody2D _rb;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float move = horizontalInput * _movingSpeed;
        _isGrounded = IsGrounded();

        if(_isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            }
        }
       
        _rb.velocity = new Vector2(move, _rb.velocity.y);
    }

    bool IsGrounded() //check if Player is on the ground
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, 1 << 8);
        if(hit.collider != null) //if Player is actually hit something
        {
            return true;
        }
        return false;
    }
}

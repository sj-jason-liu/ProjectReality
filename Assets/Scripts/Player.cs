using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _movingSpeed = 3f;
    [SerializeField]
    private float _jumpForce = 5f;
    [SerializeField]
    private float _doubleJumpForce = 1.2f;

    private bool _isGrounded, _hasDoubleJumped;

    private Rigidbody2D _rb;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }

    void Moving()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float move = horizontalInput * _movingSpeed;
        _isGrounded = IsGrounded();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(_isGrounded)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            }
            else if(!_isGrounded && !_hasDoubleJumped)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce * _doubleJumpForce);
                _hasDoubleJumped = true;
            }
        }

        //if Player is jumping, ignore collision
        if (_rb.velocity.y > 0)
        {
            Physics2D.IgnoreLayerCollision(9, 8, true);
        }
        else
        {
            Physics2D.IgnoreLayerCollision(9, 8, false);
        }

        _rb.velocity = new Vector2(move, _rb.velocity.y);
    }

    bool IsGrounded() //check if Player is on the ground
    {
        RaycastHit2D groundHit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, 1 << 8);
        RaycastHit2D platformHit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, 1 << 10);
        if (groundHit.collider != null || platformHit.collider != null) //if Player is actually hit something
        {
            _hasDoubleJumped = false;
            return true;
        }
        return false;
    }
}

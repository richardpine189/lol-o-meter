using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private  float _jumpForce;

    [SerializeField] private Rigidbody2D _playerRB;

    [SerializeField] private float _playerSpeed;

    private float _horizontalMovement;
    private float _jumpInput;

    private bool _isGrounded = true;

    // Update is called once per frame
    void Update()
    {
        _jumpInput = Input.GetAxis("Jump");
        _horizontalMovement = Input.GetAxis("Horizontal");
        if (_horizontalMovement != 0)
            transform.Translate(Vector2.right * _horizontalMovement * Time.deltaTime * _playerSpeed);
    }
    private void FixedUpdate()
    {
        if (_jumpInput != 0 && _isGrounded == true)
            _playerRB.AddForce(Vector2.up * _jumpForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Platform"))
            _isGrounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
            _isGrounded = false;
    }
}

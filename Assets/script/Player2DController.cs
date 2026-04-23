using UnityEngine;
using UnityEngine.InputSystem;

public class Player2DController : MonoBehaviour
{
    public float speed = 5.0f;
    public float Jumpforce = 450;
    private Rigidbody2D _rb;
    private float _moveInputValue;
    private bool _isGrounded;
    private SpriteRenderer _spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current != null)
        {
            _moveInputValue = (Keyboard.current.dKey.isPressed ? 1 : 0) - (Keyboard.current.aKey.isPressed ? 1 : 0);
        }
        _rb.linearVelocity = new Vector2(_moveInputValue * speed, _rb.linearVelocity.y);
        if (_moveInputValue < 0 ) {_spriteRenderer.flipX = true; }
        else if (_moveInputValue > 0) { _spriteRenderer.flipX = false; }
        if (Keyboard.current.spaceKey.wasPressedThisFrame && _isGrounded)
        {
            _rb.AddForce(new Vector2(_rb.linearVelocity.x, Jumpforce));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isGrounded = true;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        _isGrounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        _isGrounded= false;
    }
   
}

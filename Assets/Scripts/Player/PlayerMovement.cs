using System;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] 
    private Rigidbody2D _rigidbody;
    [SerializeField] 
    private float _speed;
    [SerializeField] 
    private float _jumpForce;
    [SerializeField] 
    private bool _movementVerticalNotJump;
    
    [SerializeField, Space] 
    private Animator _animator;

    private bool _isPlatform
    {
        get
        {
            RaycastHit2D hit = Physics2D.Raycast(_rigidbody.position, Vector2.down, _rayDistance, _layerPlatform);

            return hit.collider != null;
        }
    }
    private int _layerPlatform;
    
    public float _rayDistance = 1.6f;

    private void Awake() => 
        _layerPlatform = 1 << LayerMask.NameToLayer("Platform");

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = _movementVerticalNotJump ? 
            Input.GetAxis("Vertical") : 
            _rigidbody.velocity.y / _speed;

        Vector2 moveTo = new Vector2(x, y);

        if(moveTo.y > Mathf.Abs(moveTo.x))
            _animator.Play("Up");
        else if(Mathf.Abs(moveTo.y) > Mathf.Abs(moveTo.x))
            _animator.Play("Bottom");
        else if(moveTo.x > 0)
            _animator.Play("Right");
        else if(moveTo.x < 0)
            _animator.Play("Left");
        else
            _animator.Play("Stand");

        Move(moveTo);
        
        if(Input.GetKeyDown(KeyCode.Space) && !_movementVerticalNotJump && _isPlatform)
            Jump();
    }

    private void Jump() => 
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode2D.Impulse);
        // _rigidbody.velocity = (Vector2) Vector3.up * _jumpForce;

    private void Move(Vector2 moveTo)
    {
        // transform.Translate(moveTo * Time.deltaTime * _speed);
        //_rigidbody.AddForce(moveTo * _speed);
        //_rigidbody.MovePosition(_rigidbody.position + moveTo * _speed * Time.deltaTime);
        _rigidbody.velocity = moveTo * _speed;
        
        // transform.position = new Vector2();
    }
}
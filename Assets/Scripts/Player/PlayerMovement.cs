using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _runningSpeed;

    [SerializeField, Space]
    private Animator _animator;

    public bool IsRunning { get; private set; }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 moveTo = new Vector2(x, y);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (_animator != null)
            {
                RunningAnimation(moveTo);
            }
            _rigidbody.velocity = moveTo * _runningSpeed;
            IsRunning = true;
        }
        else
        {
            if (_animator != null)
            {
                WalkAnimation(moveTo);
            }
            _rigidbody.velocity = moveTo * _speed;
            IsRunning = false;
        }
    }

    private void WalkAnimation(Vector2 moveTo)
    {
        if (moveTo.y > Mathf.Abs(moveTo.x))
            _animator.Play("Up");
        else if (Mathf.Abs(moveTo.y) > Mathf.Abs(moveTo.x))
            _animator.Play("Bottom");
        else if (moveTo.x > 0)
            _animator.Play("Right");
        else if (moveTo.x < 0)
            _animator.Play("Left");
        else
            _animator.Play("Stand");
    }

    private void RunningAnimation(Vector2 moveTo) =>
        WalkAnimation(moveTo);
}
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _powerJump;
    [SerializeField] private PlayerFoots _foots;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move(GetForce());

        if (Input.GetKeyDown(KeyCode.W) && _foots.IsStay)
        {
            Jump(_powerJump);
        }
    }

    private void FixedUpdate()
    {
        float xClamped = Mathf.Clamp(_rigidbody.velocity.x, -_maxSpeed, _maxSpeed);
        _rigidbody.velocity = new Vector2(xClamped, _rigidbody.velocity.y);
    }

    private float GetForce()
    {
        float force = 0;
        if (Input.GetKey(KeyCode.A))
        {
            force -= _speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            force += _speed;
        }
        return force;
    }

    private void Move(float force)
    {
        _rigidbody.AddForce(new Vector2(force, 0));
    }

    private void Jump(float power)
    {
        _rigidbody.AddForce(new Vector2(0, power));
    }
}

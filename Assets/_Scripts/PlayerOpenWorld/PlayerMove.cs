using UnityEngine;
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speedPlayer;
    [SerializeField][Range(1,2)] private float speedAcceleration;
    private float minMagnitude = 0.5f;
    private float _speedBase;
    private PlayerReferences _playerReferences;

    private void Start()
    {
        _speedBase = speedPlayer;
        _playerReferences = FindObjectOfType<PlayerReferences>();
    }

    private void Update()
    {
        speedPlayer = GetSpeedFromJoystickMagnitude();
        Move();
    }

    private void Move()
    {
        Debug.Log("condition: " + _playerReferences.IsMovingJoystick());
        _playerReferences.Rigidbody.velocity =
            _playerReferences.IsMovingJoystick() ? GetVelocityMove() : StopVelocityPlayer();
    }

    private Vector3 GetVelocityMove()
    {
        Joystick joystick = _playerReferences.Joystick;
        Rigidbody referencesRigidbody = _playerReferences.Rigidbody;
        Vector3 direction = new Vector3( joystick.Horizontal, referencesRigidbody.velocity.y, joystick.Vertical);
        Vector3 finalVelocity = direction * (speedPlayer * Time.deltaTime);
        return finalVelocity;
    }

    private Vector3 StopVelocityPlayer()
    {
        Vector3 temp = Vector3.zero;
        float velocityPlayerY = _playerReferences.Rigidbody.velocity.y;
        temp.y = velocityPlayerY;
        return temp;
    }

    private float GetSpeedFromJoystickMagnitude()
    {
        Joystick joystick = _playerReferences.Joystick;
        if (joystick.Direction.magnitude <= minMagnitude) return _speedBase;
        float newSpeed = _speedBase * speedAcceleration;
        return newSpeed;
    }
}

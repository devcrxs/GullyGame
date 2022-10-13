using UnityEngine;
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speedPlayer;
    private PlayerReferences _playerReferences;

    private void Start()
    {
        _playerReferences = FindObjectOfType<PlayerReferences>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _playerReferences.Rigidbody.velocity =
            _playerReferences.IsMovingJoystick() ? GetVelocityMove() : StopVelocityPlayer();
    }

    private Vector3 GetVelocityMove()
    {
        Joystick joystick = _playerReferences.Joystick;
        Rigidbody rigidbody = _playerReferences.Rigidbody;
        Vector3 direction = new Vector3( joystick.Horizontal, rigidbody.velocity.y, joystick.Vertical);
        Vector3 finalVelocity = direction * (speedPlayer * Time.deltaTime);
        return finalVelocity;
    }

    private Vector3 StopVelocityPlayer()
    {
        Vector3 temp = Vector3.zero;
        //temp.y =
        return temp;
    }
}

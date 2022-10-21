using DG.Tweening;
using UnityEngine;
public class RotatePlayer : MonoBehaviour
{
    [SerializeField] private Transform spriteDirecctionPlayer;
    private PlayerReferences _playerReferences;
    public float turnSmoothTime = 0.1f;
    private float turnSmootVelocity;
    private void Start()
    {
        _playerReferences = FindObjectOfType<PlayerReferences>();
    }
    private void LateUpdate()
    {
        Rotate();
    }

    private void Rotate()
    {
        if (_playerReferences.IsMovingJoystick())
        {
            float targetAngle =
                Mathf.Atan2(-_playerReferences.Joystick.Direction.x, -_playerReferences.Joystick.Direction.y) *
                Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmootVelocity,
                turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f,angle,0f);
        }
    }

    private Vector3 GetDirectionView()
    {
        Joystick joystick = _playerReferences.Joystick;
        var position = transform.position;
        var tempX = -joystick.Horizontal + position.x;
        var tempZ = -joystick.Vertical + position.z;
        Vector3 directionView = new Vector3(tempX, -1.09f, tempZ);
        return directionView;
    }
}

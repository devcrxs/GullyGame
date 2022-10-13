using UnityEngine;
public class RotatePlayer : MonoBehaviour
{
    private PlayerReferences _playerReferences;

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
            transform.LookAt(GetDirectionView());
        }
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }

    private Vector3 GetDirectionView()
    {
        Joystick joystick = _playerReferences.Joystick;
        var tempX = -joystick.Horizontal + transform.position.x;
        var tempZ = -joystick.Vertical + transform.position.z;
        Vector3 directionView = new Vector3(tempX, 0, tempZ);
        return directionView;
    }
}

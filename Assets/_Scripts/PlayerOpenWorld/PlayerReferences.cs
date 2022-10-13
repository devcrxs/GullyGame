using UnityEngine;
public class PlayerReferences : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private Joystick joystick;
    public Rigidbody Rigidbody => rigidbody;
    public Joystick Joystick => joystick;

    public bool IsMovingJoystick()
    {
        return joystick.Horizontal != 0 || joystick.Vertical != 0;
    }
}

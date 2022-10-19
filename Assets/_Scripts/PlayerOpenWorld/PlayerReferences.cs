using UnityEngine;
public class PlayerReferences : MonoBehaviour
{
    [SerializeField] private new Rigidbody rigidbody;
    [SerializeField] private Joystick joystick;
    [SerializeField] private Animator animator;
    public Rigidbody Rigidbody => rigidbody;
    public Joystick Joystick => joystick;
    public Animator Animator => animator;

    public bool IsMovingJoystick()
    {
        return (joystick.Horizontal != 0 || joystick.Vertical != 0) && joystick.IsTouchJoystick;
    }
}

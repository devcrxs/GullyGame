using UnityEngine;
public class RotatePlayer : MonoBehaviour
{
    private void LateUpdate()
    {
        Rotate();
    }

    private void Rotate()
    {
        /*if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.LookAt(new Vector3( -joystick.Horizontal + transform.position.x,0,(-joystick.Vertical + transform.position.z)));
        }
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);*/
    }
}

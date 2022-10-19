using UnityEngine;
public class PlayerAnimations : MonoBehaviour
{
    private float storageSpeed;
    [SerializeField] [Range(1,5)]private float deceleration;
    private PlayerReferences _playerReferences;

    private void Start()
    {
        _playerReferences = FindObjectOfType<PlayerReferences>();
    }

    private void Update()
    {
        _playerReferences.Animator.SetFloat("Speed", GetSpeedPlayer());
    }

    private float GetSpeedPlayer()
    {
        if (_playerReferences.IsMovingJoystick())
        {
            float speed = _playerReferences.Joystick.Direction.magnitude;
            storageSpeed = speed;
            return speed;
        }
        storageSpeed = Mathf.Lerp(storageSpeed, 0, deceleration * Time.deltaTime);
        return storageSpeed;
    }
}

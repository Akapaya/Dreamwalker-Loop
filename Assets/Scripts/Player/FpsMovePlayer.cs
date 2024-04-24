using System.Collections;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.Events;

public class FpsMovePlayer : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigitBody;

    [SerializeField] private float _movementSpeed;

    private float _axisX;

    private float _axisY;

    private bool lockMovement = false;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private bool isGrounded;

    [SerializeField] private PlayAudioByTime playAudioByTime;

    #region Update Methods
    private void Update()
    {
        if (!lockMovement)
        {
            _axisX = Input.GetAxisRaw("Horizontal");
            _axisY = Input.GetAxisRaw("Vertical");
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (_axisX != 0 && isGrounded || _axisY != 0 && isGrounded)
        {
            playAudioByTime.SetIsPlayingTrue();
        }
        else
        {
            playAudioByTime.SetIsPlayingFalse();
        }
    }

    private void FixedUpdate()
    {
        if (lockMovement)
        {
            return;
        }
        Vector3 F = base.transform.forward * _axisY;
        Vector3 R = base.transform.right * _axisX;
        Vector3 C;
            if (_rigitBody.velocity.y > 1f)
            {
                _rigitBody.velocity = new Vector3(_rigitBody.velocity.x, 1f, _rigitBody.velocity.z);
            }
            C = new Vector3(0f, _rigitBody.velocity.y, 0f);
        _rigitBody.velocity = Vector3.ClampMagnitude(F + R, 1f) * _movementSpeed + C;
    }
    #endregion

    #region LockMethods
    public void LockMovement()
    {
        lockMovement = true;
    }

    public void UnlockMovement()
    {
        lockMovement = false;
    }
    #endregion
}
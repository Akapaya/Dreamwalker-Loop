using System.Collections;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.Events;

public class FpsMovePlayer : MonoBehaviour
{
    public Rigidbody Corpse;

    public float vel;

    public float eixoX;

    public float eixoY;

    private bool lockMovement = false;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private bool isGrounded;

    [SerializeField] private PlayAudioByTime playAudioByTime;

    private void Update()
    {
        if (!lockMovement)
        {
            eixoX = Input.GetAxisRaw("Horizontal");
            eixoY = Input.GetAxisRaw("Vertical");
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (eixoX != 0 && isGrounded || eixoY != 0 && isGrounded)
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
        Vector3 F = base.transform.forward * eixoY;
        Vector3 R = base.transform.right * eixoX;
        Vector3 C;
            if (Corpse.velocity.y > 1f)
            {
                Corpse.velocity = new Vector3(Corpse.velocity.x, 1f, Corpse.velocity.z);
            }
            C = new Vector3(0f, Corpse.velocity.y, 0f);
        Corpse.velocity = Vector3.ClampMagnitude(F + R, 1f) * vel + C;
    }

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
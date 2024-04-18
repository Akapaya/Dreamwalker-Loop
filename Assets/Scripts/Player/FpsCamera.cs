using UnityEngine;

public class FpsCamera : MonoBehaviour
{
    private float rotationOnX;

    private float mouseSensitivity = 90f;

    public Transform player;

    private bool lockCamera = false;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if(!lockCamera)
        {
            float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;
            float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;
            rotationOnX -= mouseY;
            rotationOnX = Mathf.Clamp(rotationOnX, -90f, 90f);
            base.transform.localEulerAngles = new Vector3(rotationOnX, 0f, 0f);
            player.Rotate(Vector3.up * mouseX);
        }
    }

    #region LockMethods
    public void LockCamera()
    {
        lockCamera = true;
    }

    public void UnlockCamera()
    {
        lockCamera = false;
    }
    #endregion
}
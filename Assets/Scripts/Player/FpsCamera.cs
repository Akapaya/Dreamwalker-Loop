using UnityEngine;

public class FpsCamera : MonoBehaviour
{
    private float _rotationOnX;

    private float _mouseSensitivity = 90f;

    [SerializeField] private Transform _player;

    private bool _lockCamera = false;

    #region Start Methods
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    #endregion

    #region Update Methods
    private void Update()
    {
        if(!_lockCamera)
        {
            float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * _mouseSensitivity;
            float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * _mouseSensitivity;
            _rotationOnX -= mouseY;
            _rotationOnX = Mathf.Clamp(_rotationOnX, -90f, 90f);
            base.transform.localEulerAngles = new Vector3(_rotationOnX, 0f, 0f);
            _player.Rotate(Vector3.up * mouseX);
        }
    }
    #endregion

    #region LockMethods
    public void LockCamera()
    {
        _lockCamera = true;
    }

    public void UnlockCamera()
    {
        _lockCamera = false;
    }
    #endregion
}
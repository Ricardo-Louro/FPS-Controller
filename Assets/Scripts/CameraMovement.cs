using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField] private float cameraHeight;

    private float mouseX;
    private float mouseY;

    [SerializeField] private float mouseSensitivity;

    Vector3 rotation;

    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        rotation = playerTransform.eulerAngles;
    }

    // Update is called once per frame
    private void Update()
    {
        UpdatePosition();
        ReceiveInput();
        UpdateRotation();
        UpdatePlayerRotation();
    }

    private void UpdatePosition()
    {
        Vector3 pos = playerTransform.position;
        pos.y += cameraHeight;
        transform.position = pos;
    }

    private void ReceiveInput()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
    }

    private void UpdateRotation()
    {
        rotation.x -= mouseY * (mouseSensitivity * Time.deltaTime);
        rotation.y += mouseX * (mouseSensitivity * Time.deltaTime);

        rotation.x = Mathf.Clamp(rotation.x, -70, 70);

        transform.eulerAngles = rotation;
    }

    private void UpdatePlayerRotation()
    {
        Vector3 playerRotation = playerTransform.eulerAngles;
        playerRotation.y = rotation.y;
        playerTransform.eulerAngles = playerRotation;
    }
}

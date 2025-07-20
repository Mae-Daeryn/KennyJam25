using UnityEngine;

public class playerCamera : MonoBehaviour
{

    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;
    public GameObject pausemenu;
    public GameObject gameover;
    public Vector2 hotspot = Vector2.zero;
    public UnityEngine.CursorMode cursorMode = UnityEngine.CursorMode.Auto;
    public Texture2D customCursor;

    void Start()
    {
        gameover.SetActive(false);
        pausemenu.SetActive(false);
        Cursor.SetCursor(customCursor, hotspot, cursorMode);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (!EscapeMenu.isPaused && !nextLevel.isnext)
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

            yRotation += mouseX;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }
}

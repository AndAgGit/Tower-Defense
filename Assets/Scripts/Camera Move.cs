using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Header("Panning")]
    public float panSpeed = 30f;


    [Header("Zooming")]
    public float zoomSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;

    private bool canMove = true;
    private float panBorderThiccness;

    private void Start()
    {
        panBorderThiccness = Screen.height * 0.05f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canMove = !canMove;
        }

        if (!canMove)
        {
            return;
        }

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThiccness)
        {
            transform.Translate(panSpeed * Time.deltaTime * Vector3.forward, Space.World);
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThiccness)
        {
            transform.Translate(panSpeed * Time.deltaTime * Vector3.back, Space.World);
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThiccness)
        {
            transform.Translate(panSpeed * Time.deltaTime * Vector3.left, Space.World);
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThiccness)
        {
            transform.Translate(panSpeed * Time.deltaTime * Vector3.right, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * zoomSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }
}

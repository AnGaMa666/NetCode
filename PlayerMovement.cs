using UnityEngine;
using Unity.Netcode;

[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : NetworkBehaviour
{
    public float speed = 10.0f;
    [SerializeField] float mouseSensitivity = 20.0f;
    [SerializeField] Camera playerCamera;
    private Vector3 targetPosition;
    private CharacterController characterController;
    private Vector3 cameraOffset = new Vector3(0, 5f, -5f);
    private Vector3 lockedMousePosition;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        if (!playerCamera) playerCamera = Camera.main;

        playerCamera.transform.position = transform.position + cameraOffset;
        playerCamera.transform.rotation = Quaternion.Euler(new Vector3(-30, 0, 0));

        lockedMousePosition = Input.mousePosition;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, mouseX * mouseSensitivity * Time.deltaTime);
        cameraOffset = Quaternion.Euler(0, mouseX * mouseSensitivity * Time.deltaTime, 0) * cameraOffset;
        playerCamera.transform.position = transform.position + cameraOffset;
        playerCamera.transform.rotation = Quaternion.Euler(new Vector3(-30, 0, 0));
        playerCamera.transform.LookAt(transform.position);

        lockedMousePosition = Input.mousePosition;  // Aktualisierung der lockedMousePosition

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            Ray ray = playerCamera.ScreenPointToRay(lockedMousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                targetPosition = hit.point;
            }
        }

        if (targetPosition != Vector3.zero)
        {
            Vector3 movement = (targetPosition - transform.position).normalized * speed * Time.deltaTime;
            characterController.Move(movement);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                targetPosition = Vector3.zero;
            }
        }
    }


    public override void OnNetworkSpawn()
    {
        if (!IsOwner) this.enabled = false;
    }
}

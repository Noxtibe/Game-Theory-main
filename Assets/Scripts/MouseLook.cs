using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    private Controls controls;

    [Header("Camera controls")]
    [SerializeField] float mouseSensitivity = 100f;

    private Vector2 mouseLook;
    private float xRotation = 0f;
    private Transform playerBody;

    void Awake()
    {
        playerBody = transform.parent;
        controls = new Controls();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // Use with Look function
        //Look();
    }

    // Working without callback

    /*private void Look()
    {
        mouseLook = controls.PlayerController.Mouse.ReadValue<Vector2>();

        float mouseX = mouseLook.x * mouseSensitivity * Time.deltaTime;
        float mouseY = mouseLook.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }*/

    // Working with callback
    public void ReceiveInput(InputAction.CallbackContext mouseInput)
    {
        mouseLook = mouseInput.ReadValue<Vector2>();

        float mouseX = mouseLook.x * mouseSensitivity * Time.deltaTime;
        float mouseY = mouseLook.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    // TO TEST LATER


    /*[SerializeField] float sensitivityX;
    [SerializeField] float sensitivityY;*/

    /*public void ReceiveInput(InputAction.CallbackContext mouseInput)
    {
        Vector2 mousePos = mouseInput.ReadValue<Vector2>();
        mousePos.x *=  sensitivityX;
        transform.Rotate(Vector3.up, mousePos.x);
    }*/
}

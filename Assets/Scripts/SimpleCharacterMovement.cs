using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;

public class SimpleCharacterMovement : MonoBehaviour
{
    [Header("Move")]
    public float movingSpeed = 5;
    public float runningSpeedFactor = 1.5f;
    public float rotationSpeed = 3;
    public bool holdShiftToRun = false;
    private bool isRunning = false;
    private Vector2 direction;

    private Animator _animator;

    /*[Header("Camera")]
    [SerializeField] Transform playerBody;
    public float mouseSensitivity;
    public float minViewDistance;
    private float xRotation;*/

    void Start()
    {
        _animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (direction.magnitude != 0)
        {
            _animator.SetFloat("Speed", isRunning?5:3);
            float speed = movingSpeed * (isRunning ? runningSpeedFactor : 1);
            transform.Translate(0, 0, speed*direction.y*Time.deltaTime);
            transform.Rotate( 0,rotationSpeed*direction.x*Time.deltaTime, 0);
        }
        else
        {
            _animator.SetFloat("Speed", 0);
        }


        /*float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, minViewDistance);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0);
        playerBody.Rotate(Vector3.up * mouseX);*/
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        direction = ctx.ReadValue<Vector2>();
    }

    public void Run(InputAction.CallbackContext ctx)
    {
        isRunning = holdShiftToRun && ctx.ReadValueAsButton();
    }

    /*public void MouseX(InputAction.CallbackContext ctx)
    {
        x = Mouse.current.delta.x.ReadValue();
    }*/

    /*public void MouseY(InputAction.CallbackContext ctx)
    {
        y = Mouse.current.delta.y.ReadValue();
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Zoom : MonoBehaviour
{
    [Header("Zoom options")]
    [SerializeField] int zoom = 20;
    [SerializeField] int normal = 65;
    [SerializeField] float smooth = 5f;

    public bool clickRightToZoom = false;
    public bool isZoomed = false;
    

    private void Update()
    {
        if (isZoomed)
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth);
        }

        if (!isZoomed)
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth);
        }
    }

    public void ZoomInput(InputAction.CallbackContext zoomInput)
    {
        isZoomed = clickRightToZoom && zoomInput.ReadValueAsButton();
    }
}


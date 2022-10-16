using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2D : MonoBehaviour
{
    [Header("Camera options")]
    [SerializeField] float height = 20f;
    [SerializeField] float distance = 15f;
    public Transform player;

    void Update()
    {
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float MoveSpd = 5.0f;

    [SerializeField] private InputAction MoveInput;
    private Vector2 Movement;
    private Rigidbody2D Rb;
    
    
    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        MoveInput.Enable();
        Rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Movement = MoveInput.ReadValue<Vector2>() * MoveSpd;
    }

    private void FixedUpdate()
    {
        Rb.MovePosition(Rb.position + Movement * Time.fixedDeltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float MoveSpd = 5.0f;

    [SerializeField] private InputAction MoveInput;
    
    
    private void Start()
    {
        MoveInput.Enable();
    }

    private void Update()
    {
        Vector2 Movement = MoveInput.ReadValue<Vector2>() * MoveSpd;

        transform.position += new Vector3(Movement.x, Movement.y, 0f) * Time.deltaTime;
    }
}

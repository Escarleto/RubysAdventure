using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private readonly float MoveSpd = 5.0f;

    private void Start()
    {
        
    }

    private void Update()
    {
        float HorInput = 0.0f;
        if (Keyboard.current.aKey.isPressed)
            HorInput = -1.0f;
        else if (Keyboard.current.dKey.isPressed)
            HorInput = 1.0f;

        float VerInput = 0.0f;
        if (Keyboard.current.wKey.isPressed)
            VerInput = 1.0f;
        else if (Keyboard.current.sKey.isPressed)
            VerInput = -1.0f;

        transform.position += new Vector3(HorInput, VerInput, 0f) * Time.deltaTime * MoveSpd;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    // Movimento   
    [SerializeField] private InputAction MoveInput;
    private Vector2 Movement;
    [SerializeField] private float MoveSpd = 3.5f;
    private Rigidbody2D Rb;

    // Vida
    public int MaxHP = 5;
    public int HP { get { return CurrentHP; } }
    private int CurrentHP;
    
    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        MoveInput.Enable();
        Rb = GetComponent<Rigidbody2D>();

        CurrentHP = MaxHP;
    }

    private void Update()
    {
        Movement = MoveInput.ReadValue<Vector2>() * MoveSpd;
    }

    private void FixedUpdate()
    {
        Rb.MovePosition(Rb.position + Movement * Time.fixedDeltaTime);
        Rb.MovePosition(Rb.position + Movement * Time.fixedDeltaTime);
    }

    public void ChangeHP(int Amount)
    {
        CurrentHP = Mathf.Clamp(CurrentHP + Amount, 0, MaxHP);
        /*if (CurrentHP <= 0)
        {
            
        }*/
    }
}

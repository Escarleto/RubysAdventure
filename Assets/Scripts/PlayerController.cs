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

    // I-frames
    private readonly float IFramesDuration = 2.0f;
    private bool IsInvulnerable = false;
    private float DamageCooldown;

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

        if (IsInvulnerable)
        {
            DamageCooldown -= Time.deltaTime;
            if (DamageCooldown <= 0)
                IsInvulnerable = false;
        }
    }

    private void FixedUpdate()
    {
        Rb.MovePosition(Rb.position + Movement * Time.fixedDeltaTime);
    }

    public void ChangeHP(int Amount)
    {
        if (IsInvulnerable && Amount < 0) return;

        CurrentHP = Mathf.Clamp(CurrentHP + Amount, 0, MaxHP);
        
        UIManager.Instance.UpdateHPBar((float)CurrentHP / MaxHP);

        if (Amount < 0 && !IsInvulnerable)
        {
            IsInvulnerable = true;
            DamageCooldown = IFramesDuration;
        }

        /*if (CurrentHP <= 0)
        {
            
        }*/
    }
}

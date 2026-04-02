using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    // Movimento   
    [SerializeField] private InputAction MoveInput;
    [SerializeField] private InputAction TalkInput;
    private Vector2 Movement;
    private Vector2 LastMoveDir;
    [SerializeField] private float MoveSpd = 3.5f;
    
    // Vida
    public int MaxHP = 5;
    public int HP { get { return CurrentHP; } }
    private int CurrentHP;

    // I-frames
    private readonly float IFramesDuration = 2.0f;
    private bool IsInvulnerable = false;
    private float DamageCooldown;

    // Componentes
    private Rigidbody2D Rb;
    private Animator AnimationPlayer;
    [SerializeField] private GameObject Projectile;
    private AudioSource Audio;

    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        MoveInput.Enable();
        TalkInput.Enable();
        Rb = GetComponent<Rigidbody2D>();
        AnimationPlayer = GetComponent<Animator>();
        Audio = GetComponent<AudioSource>();
        LastMoveDir = Vector2.down;

        CurrentHP = MaxHP;
    }

    private void Update()
    {
        Movement = MoveInput.ReadValue<Vector2>() * MoveSpd;

        if (Movement != Vector2.zero)
            LastMoveDir = Movement.normalized;

        if (Input.GetKeyDown(KeyCode.C))
            Shoot();
        if (Input.GetKeyDown(KeyCode.X))
            FindNPC();

        if (IsInvulnerable)
        {
            DamageCooldown -= Time.deltaTime;
            if (DamageCooldown <= 0)
                IsInvulnerable = false;
        }

        AnimationPlayer.SetFloat("DirX", LastMoveDir.x);
        AnimationPlayer.SetFloat("DirY", LastMoveDir.y);
        AnimationPlayer.SetFloat("Speed", Movement.sqrMagnitude);
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
            AnimationPlayer.SetTrigger("Hit");
        }

        /*if (CurrentHP <= 0)
        {
            
        }*/
    }
    
    private void Shoot()
    {
        GameObject ProjectileInstance = Instantiate(Projectile, transform.position, Quaternion.identity);
        ProjectileInstance.GetComponent<ProjectilePlayer>().Launch(LastMoveDir, 10f);
        AnimationPlayer.SetTrigger("Launch");
    }

    private void FindNPC()
    {
        RaycastHit2D Hit = Physics2D.Raycast(Rb.position + Vector2.up * 0.2f, LastMoveDir, 1.5f, LayerMask.GetMask("NPC"));

        if (Hit.collider != null)
        {
            NPCBehavior Character = Hit.collider.GetComponent<NPCBehavior>();
            if (Character != null)
            {
                UIManager.Instance.DisplayDialogueBox();
            }
        }
    }

    public void PlaySound(AudioClip Clip)
    {
        Audio.PlayOneShot(Clip);
    }
}

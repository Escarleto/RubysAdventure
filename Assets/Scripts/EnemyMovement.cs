using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float MoveSpd;
    private int MoveDir = 1;
    [SerializeField] private bool VerticalMove;
    [SerializeField] private float ChangeTime = 3.0f;
    private float Timer;
    private bool IsDead = false;

    private Rigidbody2D Rb;
    private Animator AnimationPlayer;
    
    private void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        AnimationPlayer = GetComponent<Animator>();
        Timer = ChangeTime;
    }

    private void Update()
    {
        Timer -= Time.deltaTime;

        if (Timer < 0)
        {
            MoveDir = -MoveDir;
            Timer = ChangeTime;
        }
    }

    private void FixedUpdate()
    {
        if (IsDead) return;

        Vector2 Movement = Rb.position;

        if (VerticalMove)
        {
            Movement.y = Movement.y + MoveSpd * MoveDir * Time.deltaTime;
            AnimationPlayer.SetFloat("MoveX", 0);
            AnimationPlayer.SetFloat("MoveY", MoveDir);
        }
        else
        {
            Movement.x = Movement.x + MoveSpd * MoveDir * Time.deltaTime;
            AnimationPlayer.SetFloat("MoveX", MoveDir);
            AnimationPlayer.SetFloat("MoveY", 0);
        }

        Rb.MovePosition(Movement);
    }

    public void Die()
    {
        IsDead = true;
        Rb.simulated = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
        AnimationPlayer.SetTrigger("Died");
    }
}


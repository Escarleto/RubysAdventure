using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleHealth : MonoBehaviour
{
    [SerializeField] private AudioClip CollectSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.GetComponent<PlayerController>()) return;

        PlayerController Player = collision.GetComponent<PlayerController>();

        if (Player.HP < Player.MaxHP)
        {
            Player.ChangeHP(1);
            Player.PlaySound(CollectSound);
            Destroy(gameObject);
        }      
    }
}

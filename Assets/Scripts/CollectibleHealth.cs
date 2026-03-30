using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleHealth : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("Player")) return;

        PlayerController Player = collision.GetComponent<PlayerController>();

        if (Player.HP < Player.MaxHP)
        {
            Player.ChangeHP(1);
            Destroy(gameObject);
        }
                
    }
}

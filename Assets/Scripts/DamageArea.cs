using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.GetComponent<PlayerController>()) return;

        collision.GetComponent<PlayerController>().ChangeHP(-1);
    }
}

using UnityEngine;

public class DamageZone : MonoBehaviour 
{
    void OnTriggerStay2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            //the controller will take care of ignoring the damage during the invincibility time.
            controller.ChangeHealth(-1);
        }
    }
}

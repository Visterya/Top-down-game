using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent<IAttackable>(out IAttackable attackable))
        {
            attackable.TakeDamage(1);
        }
    }
}

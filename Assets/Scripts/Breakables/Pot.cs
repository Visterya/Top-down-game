using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour, IAttackable
{
    private int health = 1;


    void IAttackable.TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy();
        }
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }
}

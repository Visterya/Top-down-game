using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxPlayerHealth;
    private int _currentPlayerHealth;

    private void Start()
    {
        _currentPlayerHealth = maxPlayerHealth;
    }
}

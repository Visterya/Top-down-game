using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Attack : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject HitBoxDown;
    [SerializeField] private GameObject HitBoxUp;
    [SerializeField] private GameObject HitBoxLeft;
    [SerializeField] private GameObject HitBoxRight;

    private Animator _animator;
    private Movement _playerMovement;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _playerMovement = GetComponent<Movement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && _playerMovement.currentState != PlayerState.attack)
        {
            StartCoroutine(AttackCo());
        }
    }

    private IEnumerator AttackCo()
    {
        _animator.SetBool("attacking", true);
        _playerMovement.currentState = PlayerState.attack;
        SwitchHitbox();
        yield return null;
        _animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.5f);
        _playerMovement.currentState = PlayerState.walk;
        HitBoxDown.SetActive(false);
        HitBoxUp.SetActive(false);
        HitBoxLeft.SetActive(false);
        HitBoxRight.SetActive(false);
    }

    private void SwitchHitbox()
    {
        switch (_playerMovement.currentFace)
        {
            case PlayerFace.Down:
                HitBoxDown.SetActive(true);
                break;
            case PlayerFace.Up:
                HitBoxUp.SetActive(true);
                break;
            case PlayerFace.Left:
                HitBoxLeft.SetActive(true);
                break;
            case PlayerFace.Right:
                HitBoxRight.SetActive(true);
                break;
        }
    }
}

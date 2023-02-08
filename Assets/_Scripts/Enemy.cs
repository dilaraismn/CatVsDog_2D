using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    private Animator _animator;
    private float health;
    

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        healthBar = healthBar.GetComponent<Image>();
    }

    void Start()
    {
        health = 100;
    }

    void Update()
    {
        if (health <= 0)
        {
            _animator.Play("Dead");
            StartCoroutine(Dead());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bone"))
        {
            _animator.Play("Hurt");
            health -= 40; //20
            healthBar.fillAmount = (health / 100);
        }
    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(.5f);
        this.enabled = false;
        //TO DO: WIN UI
        //TO DO: GAME END
    }
}

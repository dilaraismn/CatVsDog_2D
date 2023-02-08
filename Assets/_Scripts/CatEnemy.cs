using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatEnemy : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    private Animator _animator;
    private float catHealth;
    

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        healthBar = healthBar.GetComponent<Image>();
    }

    void Start()
    {
        catHealth = 100;
    }

    void Update()
    {
        if (catHealth <= 0)
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
            catHealth -= 20; //20
            healthBar.fillAmount = (catHealth / 100);
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

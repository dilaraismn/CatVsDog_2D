using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogEnemy : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    private Animator _animator;
    private float dogHealthealth;
    public static bool dogIsDead;
    private GameManager _gameManager;
    

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        healthBar = healthBar.GetComponent<Image>();
        _gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        dogHealthealth = 100;
        dogIsDead = false;
    }

    void Update()
    {
        if (dogHealthealth <= 0)
        {
            _animator.Play("Dead");
            StartCoroutine(Dead());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CatBone"))
        {
            _animator.Play("Hurt");
            dogHealthealth -= 20; //20
            healthBar.fillAmount = (dogHealthealth / 100);
            _gameManager.ChangePlayer();
        }
    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(.5f);
        this.enabled = false;
        dogIsDead = true;
        _gameManager.GameOver();
    }
}

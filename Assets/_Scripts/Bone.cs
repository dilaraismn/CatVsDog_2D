using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bone : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public static bool canRespawnBone;
    private GameManager _gameManager;
    protected float parabolAnim;

    private void Awake()
    {
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnEnable()
    {
        canRespawnBone = false;
        this._rigidbody2D.isKinematic = true;
    }

    private void Update()
    {
        if (DogEnemy.dogIsDead)
        {
            Destroy(this.gameObject);
        }
    }

    public void ThrowBone(float jumpPower, float posIncrease)
    {
        //gravity: 100 & throw power: 1500f
        /*_rigidbody2D.isKinematic = false;
        var direction = Vector2.up + Vector2.left;
        _rigidbody2D.velocity = direction * force; */
        
        /*parabolAnim += Time.deltaTime;
        parabolAnim = parabolAnim % 5f;
        transform.position = MathParabola.Parabola(Vector2.zero, Vector2.left  * 10f, 5f, parabolAnim / 5f);*/

        Vector2 currentPos = this.transform.position;
        Vector2 endPos = new Vector2(currentPos.x - posIncrease, 0);
        _rigidbody2D.DOJump(endPos, jumpPower, 1, 1.5f);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            canRespawnBone = true;
            _gameManager.ChangePlayer();
            Destroy(this.gameObject);
        }

        if (other.CompareTag("Cat"))
        {
            canRespawnBone = true;
            //_gameManager.ChangePlayer();
            Destroy(this.gameObject);
        }

        if (other.CompareTag("MiddleWall"))
        {
            this._rigidbody2D.isKinematic = false;
            _rigidbody2D.DOKill();
        }
    }
}

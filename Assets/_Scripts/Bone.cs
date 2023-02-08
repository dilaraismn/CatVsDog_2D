using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : MonoBehaviour
{
 //   private Rigidbody2D _rigidbody2D;
    public static bool canRespawnBone;
    private GameManager _gameManager;
    protected float parabolAnim;

    private void Awake()
    {
       // _rigidbody2D = this.GetComponent<Rigidbody2D>();
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnEnable()
    {
        canRespawnBone = false;
        //this._rigidbody2D.isKinematic = true;
    }

    private void Update()
    {
        if (DogEnemy.dogIsDead)
        {
            Destroy(this.gameObject);
        }
    }

    public void ThrowBone()
    {
        /*_rigidbody2D.isKinematic = false;
        var direction = Vector2.up + Vector2.left;
        _rigidbody2D.velocity = direction * force;*/
        
        /*parabolAnim += Time.deltaTime;
        parabolAnim = parabolAnim % 5f;
        transform.position = MathParabola.Parabola(Vector2.zero, Vector2.left  * 10f, 5f, parabolAnim / 5f);*/

        this.GetComponent<Rigidbody2D>().velocity = (-transform.right + transform.up) * 1000;

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
            _gameManager.ChangePlayer();
            Destroy(this.gameObject);
        }
    }
}

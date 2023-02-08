using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishbone : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public static bool canRespawnFishbone;
    
    private void Awake()
    {
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        canRespawnFishbone = false;
        this._rigidbody2D.isKinematic = true;
    }

    private void Update()
    {
        if (CatEnemy.catIsDead)
        {
            Destroy(this.gameObject);
        }
    }

    public void ThrowFishbone(float force)
    {
        _rigidbody2D.isKinematic = false;
        var direction = Vector2.up + Vector2.right;
        _rigidbody2D.velocity = direction * force;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            canRespawnFishbone = true;
            Destroy(this.gameObject);
        }

        if (other.CompareTag("Dog"))
        {
            canRespawnFishbone = true;
            Destroy(this.gameObject);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Bone : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public static bool canRespawnBone;

    private void Awake()
    {
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
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

    public void ThrowBone(float force)
    {
        _rigidbody2D.isKinematic = false;
        var direction = Vector2.up + Vector2.left;
        _rigidbody2D.velocity = direction * force;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            canRespawnBone = true;
            Destroy(this.gameObject);
        }

        if (other.CompareTag("Cat"))
        {
            canRespawnBone = true;
            Destroy(this.gameObject);
        }
    }
}

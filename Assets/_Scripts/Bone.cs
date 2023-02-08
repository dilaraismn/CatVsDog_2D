using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Bone : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public static bool canRespawn;

    private void Awake()
    {
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        canRespawn = false;
        this._rigidbody2D.isKinematic = true;
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
            canRespawn = true;
            Destroy(this.gameObject);
        }

        if (other.CompareTag("Enemy"))
        {
            canRespawn = true;
            Destroy(this.gameObject);
        }
    }
}

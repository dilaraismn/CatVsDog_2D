using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Bone : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void Update()
    {
       
        
    }

    public void ThrowBone(float force)
    {
        print("oldu");
        var direction = Vector2.up + Vector2.left;
        _rigidbody2D.velocity = direction * force * 75;
    }
}

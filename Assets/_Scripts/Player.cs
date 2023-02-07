using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float maxMouseHoldTime = 3;
    private float throwForce;
    
    void Start()
    {
        
    }

    void Update()
    {
        //TO DO: COUNTER IF DOESN'T PRESS IN 3 SECS CANT THROW
        if (Input.GetMouseButtonUp(0))
        {
            throwForce = 0;
            return;
        }
        
        if (Input.GetMouseButton(0))
        {
            if (throwForce >= maxMouseHoldTime)
            {
                //MAX VALUE
                //TO DO: AUTO THROW
                return;
            }
            throwForce += Time.deltaTime;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    Rigidbody rb;
    bool started;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        started = false;
        
    }

    
    void FixedUpdate()
    {
        
        if (Input.GetMouseButton(0))
        {
            if (!started)
            {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;
            }
            SwitchDirection();
        }
    }

    public void SwitchDirection()
    {
        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed,0,0);
        }
        else if(rb.velocity.x>0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }
}

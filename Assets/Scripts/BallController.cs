using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    Rigidbody rb;
    bool started,gameOver;
    public GameObject Particle;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        started = false;
        gameOver = false;
        
    }

    
    void Update()
    {
        if (!started)
        {
            if (Input.GetMouseButton(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;
            }
        }
        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameOver = true;
            rb.constraints =  RigidbodyConstraints.None;
            rb.velocity = new Vector3(0, -25f, 0);
            GameObject.Find("Main Camera").GetComponent<CameraFollow>().gameOver = true;
        }

        if (Input.GetMouseButtonDown(0) && !gameOver)
        {
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Diamond")
        {
            GameObject Part =  Instantiate(Particle, other.gameObject.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(Part,1f);
             
        }
    }
}

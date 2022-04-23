using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
   
    public Rigidbody rb;
    [SerializeField]
    float power;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 200;
    }

    // Update is called once per frame
    void Update()
    {
        //
        //if(ball.transform.position.z > 0.4)
        //{
        
        //rb.AddForce(Vector3.forward * 5000);
        AudioSource source = GetComponent<AudioSource>();
        source.Play();
        //}
    }
}

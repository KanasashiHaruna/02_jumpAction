using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerjump : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb=gameObject.GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0,-9.8f, 0);
    }

    // Update is called once per frame
    private Vector3 clickPosition;
    private float jumpPower = 10;
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space)) { 
        //     rb.velocity = new Vector3(0,10,0);
        //}
        if (Input.GetMouseButton(0))
        {
            clickPosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 dist =clickPosition-Input.mousePosition;
            if (dist.sqrMagnitude == 0) { return; }
            rb.velocity=dist.normalized*jumpPower;
        }
    }
}

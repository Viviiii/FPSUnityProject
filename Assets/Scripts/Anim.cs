    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour
{
    public Animator anim;
    public Rigidbody rbody;

    private float inputH;
    private float inputV;
    private bool Running;
    private bool Jumping;
    private bool Sliding;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();
        Running = false;
        Jumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown("1"))
        {
           
            anim.Play("WAIT02",-1,0f);   
        }

       if(Input.GetKey(KeyCode.LeftShift))
        {
            Running = true;
        }
       else
        {
            Running = false;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Jumping = true;
        }
        else
        {
            Jumping = false;
        }

        if (Input.GetKey(KeyCode.C))
        {
            Sliding = true;
        }
        else
        {
            Sliding = false;
        }


        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);
        anim.SetBool("Running", Running);
        anim.SetBool("Jumping", Jumping);
        anim.SetBool("Sliding", Sliding);


        float moveX = inputH * 20f * Time.deltaTime;
       float moveZ = inputV * 50f * Time.deltaTime;

        if(moveZ <=0f)
        {
            moveX = 0f;
        }
        else if(Running)
        {
            moveX*= 3f;
            moveZ*= 3f;
        }

        rbody.velocity = new Vector3(moveX, 0f, moveZ);
    }
}

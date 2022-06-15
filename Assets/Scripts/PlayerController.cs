using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//RUNAWAY

public class PlayerController : MonoBehaviour
{

    private float horizontal;
    private Rigidbody rb;
    private float raPosition;
    private float caPosition;

    private float tActive;
    private float tWait = 5.0f;




    public Vector3 movement;


    public float speed;
    public GameObject CubeExplosion;

    void Start()
    {
        tActive = 0.0f;
        rb = GetComponent<Rigidbody>();

    }


   void OnCollisionEnter(Collision collision)      
    {
        if (collision.gameObject.tag == "SlowDown")
        {
            Destroy(collision.gameObject);
            if (speed >= 2)
            {
                speed = speed - 1f;
            }
        
        }


        if (collision.gameObject.tag == "Player2")
        {
            speed = 0;


        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Booster")
        {
            Instantiate(CubeExplosion, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            if (speed < 10)
            {
                speed = speed + 2f;
            }

        
        }
    }
    private void Update()
    {
        //COUNTDOWN TIMER
        tActive += Time.deltaTime;
        if (tActive < tWait)
        {
            rb.constraints = RigidbodyConstraints.FreezePosition;
            return;
        }
        else
        {
          
            rb.constraints = RigidbodyConstraints.None;
        }
   

    }

    private void FixedUpdate()
    {
        //movement

        
        horizontal = Input.GetAxis("Horizontal second");
        movement = new Vector3(horizontal, 0, 1f);
        rb.AddForce(movement * speed);
 


    }

 

    





        //GameEnd CHECK
        //if runaway --> you win
        //if catcher --> you lose
        //if  z(catcher)>z(runaway) 

    //Bist du der Runaway musst du so schnell wie möglich ins Ziel kommen. 
    //Wenn du der Catcher bist, musst du versuchen den Runaway zu fangen. 
    //Überholt der eine den Anderen, tauschen sich die Rollen.
    

   
  
}


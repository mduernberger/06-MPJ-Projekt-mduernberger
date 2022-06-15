using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//CATCHER

public class PlayerController2 : MonoBehaviour
{
    private float vertical;
    private float horizontal;
    private Rigidbody rb;
    private float raPosition;
    private float caPosition;
    private float addableSpeed;
    private float zeroSpeed = 0;

    private float tActive;
    private float tWait = 5.0f;
    private SoRuntimeData runtimeData;
    private string winner;


    public float speed;
    public GameObject runaway;
    public GameObject catcher;
    public GameObject CubeExplosion;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        runtimeData = Resources.Load<SoRuntimeData>("GameEnd");

    }

    void OnCollisionEnter(Collision collision)                //  ??
    {
        if (collision.gameObject.tag == "SlowDown")
        {
            Destroy(collision.gameObject);
            
               
           if (speed > 2)
             {
                speed = speed - 1f;
             }

            
        }
        if (collision.gameObject.tag == "Player")
        {
            //speed = 0;
            if (caPosition<raPosition)
            {
                winner = "Right Player won!";
              
                SceneManager.LoadScene("End_Scene");

            }
            else
            {
                winner = "Left Player won!";
              
                SceneManager.LoadScene("End_Scene");
            }

            runtimeData.winnerName = winner;
            runtimeData.SaveToFile();
        }


    }

    // Start is called before the first frame update


    // Update is called once per frame
    private void FixedUpdate()
    {
        //vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontal, 0, 1f);
        rb.AddForce(movement * speed);
        
    }

    private void Update()
    {
        raPosition = GameObject.FindGameObjectWithTag("Player").transform.position.z;
        caPosition = GameObject.FindGameObjectWithTag("Player2").transform.position.z;

       //COUNTDOWN TIMERo
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




        //if (caPosition >= raPosition)
        //{

            

        //}
        //else
        //{
         
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Booster2")
        {
            Instantiate(CubeExplosion, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            if (speed < 10)
            {
                speed = speed + 2f;
            }
        }
    }
    }
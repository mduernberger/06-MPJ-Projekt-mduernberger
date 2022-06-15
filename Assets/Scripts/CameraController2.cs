using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CATCHER CAM

public class CameraController2 : MonoBehaviour
{
    public GameObject player2;

    private Vector3 offset;



    // Start is called before the first frame update
    void Start()

        //Camera Movement
    {
      //  player2 = GameObject.FindGameObjectWithTag("Player2");

        offset = transform.position - player2.transform.position;

       
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = player2.transform.position + offset;
    }
}
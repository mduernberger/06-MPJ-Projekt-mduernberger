using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//RUNAWAY

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    private GameObject boost;

    // Start is called before the first frame update
    void Start()
    {
       // player = GameObject.FindGameObjectWithTag("Player");

        offset = transform.position - player.transform.position;

        //Hide Boost-Cubes

        boost = GameObject.FindGameObjectWithTag("Booster");
        MeshRenderer render = boost.GetComponentInChildren<MeshRenderer>();
        render.enabled = true;

    }

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
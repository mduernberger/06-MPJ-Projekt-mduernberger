using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private float raPosition;
    private float caPosition;

    public TextMeshProUGUI roleL;
    public TextMeshProUGUI roleR;


    // Start is called before the first frame update
    void Start()
    {
        roleL.text = "";
        roleR.text = "";

    }

    // Update is called once per frame
    void Update()
    {
        raPosition = GameObject.FindGameObjectWithTag("Player").transform.position.z;
        caPosition = GameObject.FindGameObjectWithTag("Player2").transform.position.z;





        if (caPosition >= raPosition)
        {

            roleL.text = "CATCHER";
            roleR.text = "RUNAWAY";
        }
        else
        {
            roleL.text = "RUNAWAY";
            roleR.text = "CATCHER";
        }
    }

    public void BackToMenu ()
    {
        SceneManager.LoadScene(0);
    }
}
//Countdown bei Fänger
//Ziel
//fangen
//Speedboost
//Bremsen bei Hinderniskollision

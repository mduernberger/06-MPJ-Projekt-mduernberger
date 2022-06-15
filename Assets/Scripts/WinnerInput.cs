using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinnerInput : MonoBehaviour
{
    public TMP_Text displayWinnerName;

    private SoRuntimeData runtimeData;

    // Start is called before the first frame update
    void Start()
    {
        runtimeData = Resources.Load<SoRuntimeData>("GameEnd");
        runtimeData.LoadDataFromFile();
        displayWinnerName.text = runtimeData.winnerName;
    }

  



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene(0);
        }
    }
}

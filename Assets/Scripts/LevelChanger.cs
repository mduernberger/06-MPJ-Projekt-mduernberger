using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
   

    private SoRuntimeData runtimeData;
    private string winner;

    
    // Update is called once per frame
    void Update()
    {
       
    }
    private void Start()
    {
        runtimeData = Resources.Load<SoRuntimeData>("GameEnd");
       
    }
    void OnCollisionEnter(Collision collision)
    {
       
        
        if (collision.gameObject.tag == "Player")
        {
            winner = "Left Player won!";
            FadeToLevel(1);
       
        }


        if (collision.gameObject.tag == "Player2")
        {
            winner = "Right Player won!";
            FadeToLevel(1);
        }
        runtimeData.winnerName = winner;
         runtimeData.SaveToFile();
    }
    public void FadeToLevel(int levelIndex)
    {
       
        animator.SetTrigger("FadeOut");

    }

     public void OnFadeComplete()
    {
        SceneManager.LoadScene(1);
      


    }

}

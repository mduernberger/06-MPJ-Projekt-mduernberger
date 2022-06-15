using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PfxDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyPfx());
    }

    private IEnumerator DestroyPfx()
    {
        yield return new WaitForSeconds(3.0f);
   
    }
}

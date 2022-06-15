using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectScript : MonoBehaviour
{
    public GameObject theEnemy;
  
    public GameObject theBooster, theBooster2;
    public List<GameObject> spawnedObjects;
    public float minDistance = 10;

    public float yPos;

    public int maxEnemys = 20;
    public Vector2 minMaxPositionX;
    public Vector2 minMaxPositionZ;

    public int maxBooster = 20;
    public float minBoosterDistance = 10;
   

    private int enemyCount;
    private int boosterCount;
    private float xPos;
    private float zPos;
    private float randomY;
    public float scale;
    private Vector3 enemyScale;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
        StartCoroutine(BoosterDrop());
        StartCoroutine(Booster2Drop());
    }


  
    IEnumerator EnemyDrop()
        {

        GameObject spawnedObject;
        float spawnDistance;
        while (enemyCount < maxEnemys)

          
        {
           xPos = Random.Range(minMaxPositionX.x, minMaxPositionX.y);
            zPos = Random.Range(minMaxPositionZ.x, minMaxPositionZ.y);
            Vector3 newPos = new Vector3(xPos, yPos, zPos);
          
           
        
           

            float randomY = Random.Range(-360f, 360f);
            Vector3 newRot = new Vector3(0, randomY, 0);
            Quaternion rotation = Quaternion.Euler(newRot);
            

            bool tooClose = false;

            foreach (GameObject obstacle in spawnedObjects)
            {
                spawnDistance = Vector3.Distance(newPos, obstacle.transform.position);

                if (spawnDistance < minDistance)
                {
                    tooClose = true;
                }
            }
            if (!tooClose) {
                spawnedObject = Instantiate(theEnemy, newPos, rotation);
                yield return new WaitForSeconds(0.1f);
                enemyCount += 1;
                spawnedObjects.Add(spawnedObject); 
            }
        }
    }

    IEnumerator BoosterDrop()
    {

        GameObject spawnedObject;
        float spawnDistance;

        while (boosterCount < maxBooster)
        {
            xPos = Random.Range(17, 58);
            zPos = Random.Range(34, 3500);
            //Instantiate(theBooster, new Vector3(xPos, 0.81f, zPos), Quaternion.identity);
            Vector3 newPos = new Vector3(xPos, 2.18f, zPos);

            bool tooClose = false;

            foreach (GameObject obstacle in spawnedObjects)
            {
                spawnDistance = Vector3.Distance(newPos, obstacle.transform.position);
                if (spawnDistance < minBoosterDistance)
                {
                    tooClose = true;
                }
            }
            if (!tooClose)
            {
                spawnedObject = Instantiate(theBooster, newPos, Quaternion.identity);
                yield return new WaitForSeconds(0.1f);
                boosterCount += 1;
                spawnedObjects.Add(spawnedObject);
            }
        }
    }

    IEnumerator Booster2Drop()
    {

        GameObject spawnedObject;
        float spawnDistance;

        while (boosterCount < maxBooster)
        {
            xPos = Random.Range(17, 58);
            zPos = Random.Range(34, 3500);
            //Instantiate(theBooster, new Vector3(xPos, 0.81f, zPos), Quaternion.identity);
            Vector3 newPos = new Vector3(xPos, 2.18f, zPos);

            bool tooClose = false;

            foreach (GameObject obstacle in spawnedObjects)
            {
                spawnDistance = Vector3.Distance(newPos, obstacle.transform.position);
                if (spawnDistance < minBoosterDistance)
                {
                    tooClose = true;
                }
            }
            if (!tooClose)
            {
                spawnedObject = Instantiate(theBooster2, newPos, Quaternion.identity);
                yield return new WaitForSeconds(0.1f);
                boosterCount += 1;
                spawnedObjects.Add(spawnedObject);
            }
        }
    }
}

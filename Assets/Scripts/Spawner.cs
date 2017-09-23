using UnityEngine;
using System.Collections;

public class Spawner : GameControllerInterface {

    public GameObject[] prefabs;
    public float delay = 2.0f; //placeholder for testing. Will spawn much slower, and respawn counter will only restart when picked up.
    public bool cloudsOn = true;
    public bool itemsOn = true;
    public bool pickedUp = true;
    public int delayMin = 30;
    public int delayMax = 60;

	// Use this for initialization
	void Start () {

       
        if(gameObject.tag.Equals("CloudSpawner"))
        {
            delayMax = 25;
            delayMin = 5;
        }
        if (gameObject.tag.Equals("SpikeSpawner"))
        {
            delay = Random.Range(35, 50);
            delayMin = 10;
            delayMax = 20;
        }
        StartCoroutine(ItemGenerator());

    }


    IEnumerator ItemGenerator()
    {
        if (itemsOn && gameObject.tag.Equals("ItemSpawner"))
        {
            while (true)
            {
                yield return new WaitUntil(() => pickedUp == true);
                if (pickedUp)
                {
                    yield return new WaitForSeconds(delay);
                    var newTransform = transform;

                    GameObject o = (GameObject) Instantiate(prefabs[Random.Range(0, prefabs.Length)], newTransform.position, Quaternion.identity);
                    o.GetComponent<GameControllerInterface>().gameController = gameController;
                    //o.gameController = gameController;
                    
                    pickedUp = false;
                    yield return new WaitForSeconds(30);
                    pickedUp = true;
                }
            }
        }
        else if((cloudsOn && gameObject.tag.Equals("CloudSpawner")) || gameObject.tag.Equals("SpikeSpawner"))
        {
            while(true)
            {
               // yield return new WaitUntil(() => pickedUp == true);
                
                    yield return new WaitForSeconds(delay);
                    var newTransform = transform;
                if (gameObject.tag.Equals("SpikeSpawner"))
                {
                    GameObject o = (GameObject)Instantiate(prefabs[Random.Range(0, prefabs.Length)], newTransform.position, Quaternion.Euler(0, 0, 180));
                    o.GetComponent<GameControllerInterface>().gameController = gameController;
                }
                else
                {
                    Instantiate(prefabs[Random.Range(0, prefabs.Length)], newTransform.position, Quaternion.identity);
                }
                    
                    newDelay();
                
            }
        }
        
    }
    void newDelay()
    {
        delay = Random.Range(delayMin, delayMax);
    }
}

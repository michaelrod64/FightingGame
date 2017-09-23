using UnityEngine;
using System.Collections;

public class Move_Cloud : MonoBehaviour {

    public float speed;
    
    public float size;
    public float randomSize;
    public bool sizeCalculated;

	// Use this for initialization
	void start () {
        sizeCalculated = false;
        



    }
	
	// Update is called once per frame
	void Update () {


        if(!sizeCalculated)
        randomSize = Random.Range((float).1, (float).25);



        GetComponent<Transform>().localScale = new Vector3(randomSize, randomSize, 1);

        if(!sizeCalculated)
        {
            size = GetComponent<Transform>().localScale.y;
            sizeCalculated = true;
        }
        
        speed = 5 * (size * 10);


        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
    }
}

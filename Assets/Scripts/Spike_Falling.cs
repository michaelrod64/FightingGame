using UnityEngine;
using System.Collections;

public class Spike_Falling : MonoBehaviour {

    public bool fallen = false;
    //public float speed = 1;


    // Use this for initialization
    void Start () {
        StartCoroutine(Fall());
    }

    void OnTriggerEnter2D(Collider2D other)
    {


        if(fallen || ((other.GetComponent<Player1Input>() != null) && other.GetComponent<Player2Input>() != null))
        Destroy(gameObject);
    }


    IEnumerator Fall()
    {
        

        if (!fallen) {
            float fallTime = Random.Range(10, 30);

            yield return new WaitForSeconds(fallTime);


                    transform.Rotate(0, 0, 15);
            yield return new WaitForSeconds(.1f);
                    transform.Rotate(0, 0, -15);
            yield return new WaitForSeconds(.1f);
                    transform.Rotate(0, 0, -15);
            yield return new WaitForSeconds(.1f);
            transform.Rotate(0, 0, 15);
                    
                
                GetComponent<Rigidbody2D>().velocity = new Vector3(0, -25, 0);
                fallen = true;
            }
        }

	
	}


using UnityEngine;
using System.Collections;

public class AddBlockVelocity : MonoBehaviour {

    public float currentVelocity;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "P1")
        {
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            //rb.velocity = rb.velocity + new Vector2(currentVelocity * Time.deltaTime * 10, 0);
            rb.velocity = new Vector2(currentVelocity, 0);
           // if()
        }
    }
}

/*using UnityEngine;
using System.Collections;
//To be worked on when player is created
public class Destroy_On_Consumed : MonoBehaviour {

    private bool collected;
    private BoxCollider2D collider;


    void Awake()
    {
        collider = GetComponent<BoxCollider2D>();

    }


    void fixedUpdate()
    {
        if (collider.IsTouching(GetComponent<PlayerInput>().GetComponent<Collider>()))
        {

        }
    }
   
}

*/
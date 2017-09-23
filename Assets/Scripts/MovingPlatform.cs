using UnityEngine;
using System.Collections;

public class MovingPlatform : GameControllerInterface {

    public AddBlockVelocity platform;

    public Transform goalPosition;

    public Transform[] positions;
    

    public int endPosition;

	// Use this for initialization
	void Start()
    {
        endPosition = 1;
        goalPosition = positions[endPosition];
    }

	
	void Update () {

        platform.transform.position = Vector3.MoveTowards(platform.transform.position, goalPosition.position, Time.deltaTime * platform.currentVelocity);

        if(platform.transform.position == goalPosition.position)
        {
            goalPosition = (positions[++endPosition % positions.Length]);
        }
        
	}

 

        //in oncollisionstay2d if it's a player colliding: player.velocity = player.velocity + currentVelocity
   }

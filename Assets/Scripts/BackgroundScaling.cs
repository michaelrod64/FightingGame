using UnityEngine;
using System.Collections;

public class  BackgroundScaling : MonoBehaviour {

    public float textureSize = 32; 
    public float newWidth;
    public float newHeight;
     
	// Use this for initialization
	void start () {

        transform.localScale = new Vector3(Screen.width, Screen.height, 1);
        /*
        newWidth = Mathf.Ceil(Screen.width / (textureSize * PixelPerfectCamera.scale));
        newHeight = Mathf.Ceil(Screen.height / (textureSize * PixelPerfectCamera.scale));
        transform.localScale = new Vector3(newWidth * textureSize, newHeight * textureSize, 1);

        GetComponent<Renderer>().material.mainTextureScale = new Vector3(newWidth, newHeight, 1);
        */
	}
	
	
}

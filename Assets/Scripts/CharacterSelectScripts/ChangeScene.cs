using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour {

    GameObject PersistentDataObject;
    PersistentData data;



    // Use this for initialization
    void Start () {
        PersistentDataObject = GameObject.Find("PersistentDataObject");
        data = PersistentDataObject.GetComponent<PersistentData>();

    }
	
	// Update is called once per frame
	void Update () {

        if(data.GetPlayer2Confirm() && data.GetPlayer2Confirm())
        {
            SceneManager.LoadScene(2);
        }
	



	}
}

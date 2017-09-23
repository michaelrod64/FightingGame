using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ClickPlay : MonoBehaviour {


    GameObject persistentData;

	public void LoadCharacterSelect(bool multiplayer)
    {
        persistentData = GameObject.Find("CrossSceneData");
        persistentData.GetComponent<PersistentData>().setMultiplayer(true);

        if (multiplayer)
        {

            persistentData.GetComponent<PersistentData>().setMultiplayer(true);
            if (!GetComponentInParent<ArrowKeys>().getSelectNone())
                SceneManager.LoadScene(1);
        }
        else
        {
            persistentData.GetComponent<PersistentData>().setMultiplayer(false);
            if (!GetComponentInParent<ArrowKeys>().getSelectNone())
                SceneManager.LoadScene(3);
        }
    }
    



}

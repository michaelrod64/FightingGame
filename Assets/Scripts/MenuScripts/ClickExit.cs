using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class ClickExit : MonoBehaviour {




	public void Exit()
    {
        SceneManager.LoadScene(0);
    }



}

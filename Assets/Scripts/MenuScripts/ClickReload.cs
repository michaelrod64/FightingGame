using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;

public class ClickReload : MonoBehaviour {
    void Awake()
    {

        DontDestroyOnLoad(this);

    }


    public void restart()
    {
     

        string sceneName = EditorSceneManager.GetActiveScene().name;
        
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
        SceneManager.LoadScene(sceneName);
            //EditorApplication.currentScene);
    }

}

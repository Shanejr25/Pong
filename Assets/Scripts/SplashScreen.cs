using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {

    public string sceneToLoad;

    public int secTillSceneLoad;

	// Use this for initialization
	void Start () {

        // delayed start of scene
        Invoke("OpenNextScene", secTillSceneLoad);
	}
	
	// load the scene
	void OpenNextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}

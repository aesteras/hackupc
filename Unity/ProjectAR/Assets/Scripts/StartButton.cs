using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {

    public Button myButton;

	// Use this for initialization
	void Start () {
        Debug.Log("Button started");
        Button btn = myButton.GetComponent<Button>();
        btn.onClick.AddListener(() => LoadScene());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadScene()
    {
        Debug.Log("Button clicked");
        //Application.LoadLevel(SceneToChangeTo);
        SceneManager.LoadScene(1);
    }
}

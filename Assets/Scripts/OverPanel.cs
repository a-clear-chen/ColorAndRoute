using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OverPanel : MonoBehaviour {

    private Button againBtn;
    private Button returnBtn;

	// Use this for initialization
	void Start () {

        againBtn = transform.Find("BeginAgain").GetComponent<Button>();
        againBtn.onClick.AddListener(OnAgainClick);
        returnBtn = transform.Find("Return").GetComponent<Button>();
        returnBtn.onClick.AddListener(OnReturnClick);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnAgainClick()
    {
        SceneManager.LoadScene("One");
    }

    private void OnReturnClick()
    {
        SceneManager.LoadScene("Game");
    }
}

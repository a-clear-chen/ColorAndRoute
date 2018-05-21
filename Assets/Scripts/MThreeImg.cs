using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MThreeImg : MonoBehaviour {

    private GameObject threePre;

    // Use this for initialization
    void Start () {

        threePre = GameObject.Find("ThreePre");
        threePre.SetActive(false);
        

        gameObject.GetComponent<Button>().onClick.AddListener(OnThreeClick);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseOver()
    {
        threePre.SetActive(true);
    }
    void OnMouseExit()
    {
        threePre.SetActive(false);
    }

    void OnThreeClick()
    {
        GameLevel.Instance.gameLevel = 3;
        SceneManager.LoadScene("Three");
    }
}

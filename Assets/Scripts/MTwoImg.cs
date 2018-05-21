using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MTwoImg : MonoBehaviour {

    private GameObject twoPre;

    // Use this for initialization
    void Start () {

        twoPre = GameObject.Find("TwoPre");
        twoPre.SetActive(false);
        

        gameObject.GetComponent<Button>().onClick.AddListener(OnTwoClick);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseOver()
    {
        twoPre.SetActive(true);
    }
    void OnMouseExit()
    {
        twoPre.SetActive(false);
    }

    void OnTwoClick()
    {
        GameLevel.Instance.gameLevel = 2;
        SceneManager.LoadScene("Two");
    }
}

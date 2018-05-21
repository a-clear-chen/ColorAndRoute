using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class MPlaneImg : MonoBehaviour {

    private GameObject planePre;

	// Use this for initialization
	void Start () {

        planePre = GameObject.Find("PlanePre");
        planePre.SetActive(false);

        gameObject.GetComponent<Button>().onClick.AddListener(OnExitClick);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseEnter()
    {
        AudioManager.Instance.PlayNormalSound(AudioManager.Sound_Quit);
    }

    void OnMouseOver()
    {
        planePre.SetActive(true);
    }
    void OnMouseExit()
    {
        planePre.SetActive(false);
    }

    void OnExitClick()
    {
        Application.Quit();
    }
}

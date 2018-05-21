using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MReturnImg : MonoBehaviour {

    private GameObject returnPre;

	// Use this for initialization
	void Start () {

        returnPre = GameObject.Find("ReturnPre");
        returnPre.SetActive(false);

        gameObject.GetComponent<Button>().onClick.AddListener(OnReturnClick);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseEnter()
    {
        AudioManager.Instance.PlayNormalSound(AudioManager.Sound_Return);
    }

    void OnMouseOver()
    {
        returnPre.SetActive(true);
    }
    void OnMouseExit()
    {
        returnPre.SetActive(false);
    }

    private void OnReturnClick()
    {
        SceneManager.LoadScene("Game");
    }
}

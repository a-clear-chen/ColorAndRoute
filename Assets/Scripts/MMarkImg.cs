using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class MMarkImg : MonoBehaviour {

    private GameObject markPre;

	// Use this for initialization
	void Start () {

        markPre = GameObject.Find("MarkPre");
        markPre.SetActive(false);

        gameObject.GetComponent<Button>().onClick.AddListener(OnMarkClick);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseEnter()
    {
        AudioManager.Instance.PlayNormalSound(AudioManager.Sound_Help);
    }

    void OnMouseOver()
    {
        markPre.SetActive(true);
    }
    void OnMouseExit()
    {
        markPre.SetActive(false);
    }

    private void OnMarkClick()
    {
        AudioManager.Instance.PlayNormalSound(AudioManager.Sound_HowToPlay);
    }
}

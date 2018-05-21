using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MOneImg : MonoBehaviour {

    private GameObject onePre;

	// Use this for initialization
	void Start () {

        onePre = GameObject.Find("OnePre");
        onePre.SetActive(false);

        gameObject.GetComponent<Button>().onClick.AddListener(OnOneClick);

        AudioManager.Instance.PlayNormalSound(AudioManager.Sound_Start);
        Invoke("PlaySound", 3.5f);

	}

    private void PlaySound()
    {
        AudioManager.Instance.PlayNormalSound(AudioManager.Sound_Selectionleveldifficulty);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseOver()
    {
        onePre.SetActive(true);
    }
    void OnMouseExit()
    {
        onePre.SetActive(false);
    }

    void OnOneClick()
    {
        GameLevel.Instance.gameLevel = 1;
        SceneManager.LoadScene("One");
    }
}

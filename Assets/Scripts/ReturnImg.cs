using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnImg : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseEnter()
    {
        AudioManager.Instance.PlayNormalSound(AudioManager.Sound_Return);
    }
}

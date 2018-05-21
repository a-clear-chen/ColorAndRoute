using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel : MonoBehaviour {

    private static GameLevel _instance;
    public static GameLevel Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.Find("GameLevel").GetComponent<GameLevel>();
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }

    public int gameLevel = 0;

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

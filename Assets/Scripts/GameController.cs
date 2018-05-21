using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class GameController : MonoBehaviour {
    
    private static GameController _instance;
    public static GameController Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.Find("Canvas").GetComponent<GameController>();
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }


    //public int gameLevel = GameLevel.Instance.gameLevel;
    public bool isDrag = false;

    public int colorNum = 0;

    private Button startBtn;
    private Button musicPlayBtn;
    private Button musicStopBtn;

    private GameObject panel;
    private GameObject pblue;
    private GameObject pred;
    private GameObject pyellow;
    private GameObject blue;
    private GameObject red;
    private GameObject yellow;

    private GameObject grassDoor;
    private GameObject overPanel;
    private GameObject dog;
    private GameObject panelTwo;
    

    public Vector3 animalPos;

    public GameObject[] animal;

    private float isGameOver = 0;
    private bool isDo = true;

    // Use this for initialization
    void Start () {
        

        startBtn = transform.Find("StartButton").GetComponent<Button>();
        startBtn.onClick.AddListener(OnStartBtnClick);

        panel = transform.Find("Panel").gameObject;

        pblue = transform.Find("GamePanel/Pblue").gameObject;
        pblue.SetActive(false);
        pred = transform.Find("GamePanel/Pred").gameObject;
        pred.SetActive(false);
        pyellow = transform.Find("GamePanel/Pyellow").gameObject;
        pyellow.SetActive(false);

        blue = transform.Find("Blue").gameObject;
        blue.SetActive(false);
        red = transform.Find("Red").gameObject;
        red.SetActive(false);
        yellow = transform.Find("Yellow").gameObject;
        yellow.SetActive(false);

        grassDoor = GameObject.Find("GrassDoor");
        grassDoor.SetActive(true);

        overPanel = transform.Find("OverPanel").gameObject;
        overPanel.SetActive(false);

        dog = GameObject.Find("Dog");
        dog.SetActive(false);

        panelTwo = transform.Find("PanelTwo").gameObject;
        panelTwo.SetActive(false);

        AudioManager.Instance.PlayBGSound(AudioManager.Sound_HowToPlayCompleteEdition);

        musicPlayBtn = transform.Find("GamePanel/MusicPlayImg").gameObject.GetComponent<Button>();
        musicPlayBtn.onClick.AddListener(OnMusicPlayClick);
        musicPlayBtn.gameObject.SetActive(true);
        musicStopBtn = transform.Find("GamePanel/MusicStopImg").gameObject.GetComponent<Button>();
        musicStopBtn.onClick.AddListener(OnMusicStopClick);
        musicStopBtn.gameObject.SetActive(false);

        MoveToTarget();

    }
	
	// Update is called once per frame
	void Update () {
		if(isGameOver>=3)
        {
            isDrag = false;
            OverPanel();
        }
	}

    private void OnStartBtnClick()
    {
        isDrag = true;
        AudioManager.Instance.PlayBGSound(AudioManager.Sound_BGM);
        panel.SetActive(false);
        startBtn.gameObject.SetActive(false);
    }

    private void OnMusicPlayClick()
    {
        musicPlayBtn.gameObject.SetActive(false);
        musicStopBtn.gameObject.SetActive(true);
        AudioManager.Instance.StopBGSound();
    }

    private void OnMusicStopClick()
    {
        musicStopBtn.gameObject.SetActive(false);
        musicPlayBtn.gameObject.SetActive(true);
        AudioManager.Instance.PlayBGSound(AudioManager.Sound_BGM);
    }

    private void MoveToTarget()
    {
        if (isDo == false)
            return;
        if(GameLevel.Instance.gameLevel==1)
        {
            OneLevel();
        }
        else if(GameLevel.Instance.gameLevel == 2)
        {
            TwoLevel();
        }
        else if(GameLevel.Instance.gameLevel == 3)
        {
            ThreeLevel();
        }
        else
        {
            print(GameLevel.Instance.gameLevel);
        }
    }

    private void OneLevel()
    {
        float randomAnimal = Random.Range(0, 3);
        float randomColor = Random.Range(0, 3);
        //随机选择动物出现
        if (randomAnimal <= 0.8f)
        {
            GameObject go = Instantiate(animal[0], animalPos, Quaternion.Euler(0, 180, 0));
            //go.transform.SetParent(animals);
            StartCoroutine(Move_Time(go, go.transform.position, new Vector3(-0.343f, 0.469f, 90), 2f));
            //Destroy(go, 3);
        }
        else if (randomAnimal > 0.8f && randomAnimal < 2)
        {
            GameObject go = Instantiate(animal[1], animalPos, Quaternion.Euler(0, 180, 0));
            //go.transform.SetParent(animals);
            StartCoroutine(Move_Time(go, go.transform.position, new Vector3(-0.343f, 0.469f, 90), 2f));
            //Destroy(go, 3);
        }
        else
        {
            GameObject go = Instantiate(animal[2], animalPos, Quaternion.Euler(0, 180, 0));
            //go.transform.SetParent(animals);
            StartCoroutine(Move_Time(go, go.transform.position, new Vector3(-0.343f, 0.469f, 90), 2f));
            //Destroy(go, 3);
        }
        //随机选择颜色
        if (randomColor <= 0.8f)
        {
            colorNum = 1;
            blue.SetActive(true);
            pblue.SetActive(true);
            StartCoroutine(Move_Time(pblue, pblue.transform.localPosition, new Vector3(-163.9329f, 244f, 0), 2f));
        }
        else if (randomColor > 0.8f && randomColor < 2)
        {
            colorNum = 2;
            red.SetActive(true);
            pred.SetActive(true);
            StartCoroutine(Move_Time(pred, pred.transform.localPosition, new Vector3(-163.9329f, 244f, 0), 2f));
        }
        else
        {
            colorNum = 3;
            yellow.SetActive(true);
            pyellow.SetActive(true);
            StartCoroutine(Move_Time(pyellow, pyellow.transform.localPosition, new Vector3(-163.9329f, 244f, 0), 2f));
        }
    }

    private void TwoLevel()
    {
        float randomAnimal = Random.Range(0, 3);
        float randomColor = Random.Range(0, 3);
        //随机选择动物出现
        if (randomAnimal <= 0.8f)
        {
            GameObject go = Instantiate(animal[0], animalPos, Quaternion.Euler(0, 180, 0));
            //go.transform.SetParent(animals);
            StartCoroutine(Move_Time(go, go.transform.position, new Vector3(-0.343f, 0.469f, 90), 2f));
            //Destroy(go, 3);
        }
        else if (randomAnimal > 0.8f && randomAnimal < 2)
        {
            GameObject go = Instantiate(animal[1], animalPos, Quaternion.Euler(0, 180, 0));
            //go.transform.SetParent(animals);
            StartCoroutine(Move_Time(go, go.transform.position, new Vector3(-0.343f, 0.469f, 90), 2f));
            //Destroy(go, 3);
        }
        else
        {
            GameObject go = Instantiate(animal[2], animalPos, Quaternion.Euler(0, 180, 0));
            //go.transform.SetParent(animals);
            StartCoroutine(Move_Time(go, go.transform.position, new Vector3(-0.343f, 0.469f, 90), 2f));
            //Destroy(go, 3);
        }
        //随机选择颜色
        if (randomColor <= 0.8f)
        {
            colorNum = 1;
            blue.SetActive(true);
            pblue.SetActive(true);
            red.SetActive(true);
            StartCoroutine(Move_Time(pblue, pblue.transform.localPosition, new Vector3(-163.9329f, 244f, 0), 2f));
        }
        else if (randomColor > 0.8f && randomColor < 2)
        {
            colorNum = 2;
            red.SetActive(true);
            pred.SetActive(true);
            yellow.SetActive(true);
            StartCoroutine(Move_Time(pred, pred.transform.localPosition, new Vector3(-163.9329f, 244f, 0), 2f));
        }
        else
        {
            colorNum = 3;
            yellow.SetActive(true);
            pyellow.SetActive(true);
            blue.SetActive(true);
            StartCoroutine(Move_Time(pyellow, pyellow.transform.localPosition, new Vector3(-163.9329f, 244f, 0), 2f));
        }
    }

    private void ThreeLevel()
    {
        float randomAnimal = Random.Range(0, 3);
        float randomColor = Random.Range(0, 3);
        //随机选择动物出现
        if (randomAnimal <= 0.8f)
        {
            GameObject go = Instantiate(animal[0], animalPos, Quaternion.Euler(0, 180, 0));
            //go.transform.SetParent(animals);
            StartCoroutine(Move_Time(go, go.transform.position, new Vector3(-0.343f, 0.469f, 90), 2f));
            //Destroy(go, 3);
        }
        else if (randomAnimal > 0.8f && randomAnimal < 2)
        {
            GameObject go = Instantiate(animal[1], animalPos, Quaternion.Euler(0, 180, 0));
            //go.transform.SetParent(animals);
            StartCoroutine(Move_Time(go, go.transform.position, new Vector3(-0.343f, 0.469f, 90), 2f));
            //Destroy(go, 3);
        }
        else
        {
            GameObject go = Instantiate(animal[2], animalPos, Quaternion.Euler(0, 180, 0));
            //go.transform.SetParent(animals);
            StartCoroutine(Move_Time(go, go.transform.position, new Vector3(-0.343f, 0.469f, 90), 2f));
            //Destroy(go, 3);
        }
        //随机选择颜色
        if (randomColor <= 0.8f)
        {
            colorNum = 1;
            blue.SetActive(true);
            pblue.SetActive(true);
            red.SetActive(true);
            yellow.SetActive(true);
            StartCoroutine(Move_Time(pblue, pblue.transform.localPosition, new Vector3(-163.9329f, 244f, 0), 2f));
        }
        else if (randomColor > 0.8f && randomColor < 2)
        {
            colorNum = 2;
            red.SetActive(true);
            pred.SetActive(true);
            yellow.SetActive(true);
            blue.SetActive(true);
            StartCoroutine(Move_Time(pred, pred.transform.localPosition, new Vector3(-163.9329f, 244f, 0), 2f));
        }
        else
        {
            colorNum = 3;
            yellow.SetActive(true);
            pyellow.SetActive(true);
            blue.SetActive(true);
            red.SetActive(true);
            StartCoroutine(Move_Time(pyellow, pyellow.transform.localPosition, new Vector3(-163.9329f, 244f, 0), 2f));
        }
    }

    private static IEnumerator Move_Time(GameObject go,Vector3 start,Vector3 end,float time)
    {
        float due = 0;
        while(due<time)
        {
            due += Time.deltaTime;
            go.transform.localPosition = Vector3.Lerp(start, end, due / time);
            yield return null;
        }
    }

    public void OverPanel()
    {
        isDo = false;
        panelTwo.SetActive(true);
        grassDoor.SetActive(false);
        dog.SetActive(true);
        overPanel.SetActive(true);
    }

    public void GameNext()
    {
        isGameOver += 1;
        blue.SetActive(false);
        red.SetActive(false);
        yellow.SetActive(false);
        pblue.SetActive(false);
        pblue.transform.localPosition = new Vector3(-163.9329f, 341f, 0);
        pred.SetActive(false);
        pred.transform.localPosition = new Vector3(-163.9329f, 341f, 0);
        pyellow.SetActive(false);
        pyellow.transform.localPosition = new Vector3(-163.9329f, 341f, 0);
        MoveToTarget();
    }
}

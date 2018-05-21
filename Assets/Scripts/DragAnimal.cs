using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAnimal : MonoBehaviour {

    private Vector3 _vec3TargetScreenSpace;// 目标物体的屏幕空间坐标  
    private Vector3 _vec3TargetWorldSpace;// 目标物体的世界空间坐标  
    private Transform _trans;// 目标物体的空间变换组件  
    private Vector3 _vec3MouseScreenSpace;// 鼠标的屏幕空间坐标  
    private Vector3 _vec3Offset;// 偏移  

    private Animator anim;
    private int isHappyID = Animator.StringToHash("IsHappy");
    private int isWalkID = Animator.StringToHash("IsWalk");
    private int isMoveID = Animator.StringToHash("IsMove");

    void Awake()
    {
        _trans = transform;
    }

    // Use this for initialization
    void Start () {

        anim = GetComponent<Animator>();
        Invoke("IsHappy", 2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void IsHappy()
    {
        anim.SetBool(isHappyID, true);
        anim.SetBool(isMoveID, false);
        anim.SetBool(isWalkID, false);
    }

    IEnumerator OnMouseDown()
    {
        if (GameController.Instance.isDrag)
        {
            // 把目标物体的世界空间坐标转换到它自身的屏幕空间坐标   

            _vec3TargetScreenSpace = Camera.main.WorldToScreenPoint(_trans.position);

            // 存储鼠标的屏幕空间坐标（Z值使用目标物体的屏幕空间坐标）   

            _vec3MouseScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _vec3TargetScreenSpace.z);

            // 计算目标物体与鼠标物体在世界空间中的偏移量   

            _vec3Offset = _trans.position - Camera.main.ScreenToWorldPoint(_vec3MouseScreenSpace);

            // 鼠标左键按下   

            while (Input.GetMouseButton(0))
            {
                anim.SetBool(isHappyID, false);
                anim.SetBool(isWalkID, true);
                anim.SetBool(isMoveID, false);

                // 存储鼠标的屏幕空间坐标（Z值使用目标物体的屏幕空间坐标）  

                _vec3MouseScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _vec3TargetScreenSpace.z);

                // 把鼠标的屏幕空间坐标转换到世界空间坐标（Z值使用目标物体的屏幕空间坐标），加上偏移量，以此作为目标物体的世界空间坐标  

                _vec3TargetWorldSpace = Camera.main.ScreenToWorldPoint(_vec3MouseScreenSpace) + _vec3Offset;

                // 更新目标物体的世界空间坐标   

                _trans.position = _vec3TargetWorldSpace;

                // 等待固定更新   

                yield return new WaitForFixedUpdate();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(GameController.Instance.colorNum==1)
        {
            if (other.gameObject.name == "BTop" && Input.GetMouseButtonUp(0))
            {
                AudioManager.Instance.PlayNormalSound(AudioManager.Sound_Praise1);
                StartCoroutine(Move_Time(this.gameObject, this.transform.position, new Vector3(-0.489f, -0.612f, 90), 2f));
                Invoke("GameNext", 3f);
                Destroy(this.gameObject, 3);
                anim.SetBool(isWalkID, false);
                anim.SetBool(isMoveID, true);
                anim.SetBool(isHappyID, false);
            }
            else if(other.gameObject.name != "BTop" && Input.GetMouseButtonUp(0))
            {
                AudioManager.Instance.PlayNormalSound(AudioManager.Sound_Fail);
            }
        }
        else if(GameController.Instance.colorNum==2)
        {
            if (other.gameObject.name == "RTop" && Input.GetMouseButtonUp(0))
            {
                AudioManager.Instance.PlayNormalSound(AudioManager.Sound_Praise2);
                StartCoroutine(Move_Time(this.gameObject, this.transform.position, new Vector3(0.006f, -0.635f, 90), 2f));
                Invoke("GameNext", 3f);
                Destroy(this.gameObject, 3);
                anim.SetBool(isWalkID, false);
                anim.SetBool(isMoveID, true);
                anim.SetBool(isHappyID, false);
            }
            else if (other.gameObject.name != "RTop" && Input.GetMouseButtonUp(0))
            {
                AudioManager.Instance.PlayNormalSound(AudioManager.Sound_Fail);
            }
        }
        else if(GameController.Instance.colorNum==3)
        {
            if (other.gameObject.name == "YTop" && Input.GetMouseButtonUp(0))
            {
                AudioManager.Instance.PlayNormalSound(AudioManager.Sound_Praise3);
                StartCoroutine(Move_Time(this.gameObject, this.transform.position, new Vector3(0.728f, -0.323f, 90), 2f));
                Invoke("GameNext", 3f);
                Destroy(this.gameObject, 3);
                anim.SetBool(isWalkID, false);
                anim.SetBool(isMoveID, true);
                anim.SetBool(isHappyID, false);
            }
            else if (other.gameObject.name != "YTop" && Input.GetMouseButtonUp(0))
            {
                AudioManager.Instance.PlayNormalSound(AudioManager.Sound_Fail);
            }
        }
        
    }

    private static IEnumerator Move_Time(GameObject go, Vector3 start, Vector3 end, float time)
    {
        float due = 0;
        while (due < time)
        {
            due += Time.deltaTime;
            go.transform.localPosition = Vector3.Lerp(start, end, due / time);
            yield return null;
        }
    }

    /*
    private void OverPanel()
    {
        GameController.Instance.OverPanel();
    }
    */

    private void GameNext()
    {
        GameController.Instance.GameNext();
    }
}

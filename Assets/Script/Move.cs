using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class Move : MonoBehaviour, IPointerDownHandler
{
    [Header("매니저 리스트")]
    public UIManager muiManager;
    public TrunManager mtrunManager;
    [Header("오브젝트")]
    public GameObject player;
    float targetDis;
    float moveSpeed = 2;

    // pt
    bool playtrun;
    [Header("카메라 제어")]
    public Camera cam;
    public Camera cam1;
    public Camera cam2;

    [Header("이동 확인")]
    public bool colbool;

    bool btn;
    RaycastHit hit;

    GameObject btna;
    GameObject btnb;
    GameObject btnc;
    GameObject btnd;

    void Start()
    {
        btna = GameObject.Find("skilla");
        btnb = GameObject.Find("skillb");
        btnc = GameObject.Find("skillc");
        btnd = GameObject.Find("skilld");
        muiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        mtrunManager = GameObject.Find("TrunManager").GetComponent<TrunManager>();
    }

    // Update is called once per frame
    void Update()
    {
        btn = muiManager.mvok;
        if (btn)
        {
            cam2.GetComponent<Camera>().enabled = false;
            cam = cam1; 
            btna.SetActive(true);
            btnb.SetActive(true);
            btnc.SetActive(true);
            btnd.SetActive(true);

        }
        else
        {
            cam = null;
            cam2.GetComponent<Camera>().enabled = true;
            btna.SetActive(false);
            btnb.SetActive(false);
            btnc.SetActive(false);
            btnd.SetActive(false);

        }
        playtrun = mtrunManager.playertrun;
         
    }
 
    public void OnPointerDown(PointerEventData eventData)
    {
        if (playtrun)
        {
            
            Ray ray = cam.ScreenPointToRay(eventData.position);
            Physics.Raycast(ray, out hit);
            colbool = GameObject.Find(hit.transform.gameObject.name).GetComponent<MoveFloor>().mvok;
            if (colbool) {
                mtrunManager.playertrun = false;
                StopCoroutine("PlayerMove");
                StartCoroutine("PlayerMove");
                
            }


        }
    }

    IEnumerator PlayerMove()
    {
        

        while (true)
        {
            
            
            Vector3 gopoint = GameObject.Find(hit.transform.gameObject.name).transform.localPosition;
            gopoint.y = 0.1f;
            targetDis = (gopoint - player.transform.position).magnitude;
            
            if (colbool)
            {
                
                player.transform.LookAt(gopoint);
                player.GetComponent<Animator>().SetBool("Move", true);
                player.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }

            if(targetDis <= 0.1f)
            {
                
                GameObject.Find("Player").transform.localRotation = Quaternion.Euler(0, 0, 0);
                StopCoroutine("PlayerMove");
               


                //플레이어 턴 종료


                print("1.플레이어 이동 턴 종료");
                
                mtrunManager.Reset2 = true;
                colbool = false;
                if (colbool == false)
                {
                    player.GetComponent<Animator>().SetBool("Move", false);
                    //player.GetComponent<Animator>().SetTrigger("Idle_Battle");
                    break;
                }
            }

            yield return null;
        }

        
    }
}

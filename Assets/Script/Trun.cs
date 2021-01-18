using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trun : MonoBehaviour
{
    int t = 1 ; //턴 변수
    int tt = 0; // 턴 확인 변수

    // 턴 저장 변수
    int ta = 0; 
    int tb = 0; 
    int tc = 0;
    int td = 0; 

    public bool pt = true; // 플레이어의 턴 상태
    public bool mt = false;// 몬스터의 턴 상태
    public bool set = false;
    public bool set1 = false; // 플레이어 턴 종료 딜레이 변수

    bool sa = false; //a 스킬 입력 확인
    bool sb = false; //b 스킬 입력 확인
    bool sc = false; //c 스킬 입력 확인
    bool sd = false; //d 스킬 입력 확인

    int da = 1; //a 스킬의 쿨타임
    int db = 3; //b 스킬의 쿨타임
    int dc = 2; //c 스킬의 쿨타임
    int dd = 4; //d 스킬의 쿨타임
    
    Button btna;
    Button btnb;
    Button btnc;
    Button btnd;

    GameObject player;
    GameObject monster;
    Text t2;
    // Start is called before the first frame update
    void Start()
    {
        btna = GameObject.Find("skilla").GetComponent<Button>();
        btnb = GameObject.Find("skillb").GetComponent<Button>();
        btnc = GameObject.Find("skillc").GetComponent<Button>();
        btnd = GameObject.Find("skilld").GetComponent<Button>();
        player = GameObject.Find("Player");
        monster = GameObject.Find("Monster");
        t2 = GameObject.Find("Trunum").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        t2.text = t.ToString();
        if (ta == t)
        {
            ta = 0;
            btna.interactable = true;
            sa = false;

        }        
        if (tb == t)
        {
            tb = 0;
            btnb.interactable = true;
            sb = false;

        }      
        if (tc == t)
        {
            tc = 0;
            btnc.interactable = true;
            sc = false;

        }        
        if (td == t)
        {
            td = 0;
            btnd.interactable = true;
            sd = false;

        }

        if (tt != t)
        {
            tt = t;
        }



       if (set)
        {
            //하나의 턴이 끝나고 턴수 정리, 턴 시작
            
            StartCoroutine("DTime");
        }
       if (set1)
        {
            
            StartCoroutine("DPTime");
        }
    }
    IEnumerator DTime()
    {
        //딜레이
        yield return new WaitForSeconds(1f);
        mt = false;
        set = false;
        t += 1;
        pt = true;
        StopCoroutine("DTime");
    }    
    IEnumerator DPTime()
    {
        pt = false;
        //딜레이
        yield return new WaitForSeconds(1f);
        
        set1 = false;
        mt = true;
        StopCoroutine("DPTime");
    }
    public void onbtna()
    {
        sa = true;
        skilla(sa);
    }
    public void onbtnb()
    {
        sb = true;
        skillb(sb);
    }
    public void onbtnc()
    {
        sc = true;
        skillc(sc);
                    
    }
    public void onbtnd()
    {
        sd = true;
        skilld(sd);
    }


    public void skilla(bool sa)
    {
        if (sa)
        {
            if (pt) {
                // 행동
                set1 = true;
                player.GetComponent<Animator>().SetTrigger("Attack1");
                player.GetComponent<Animator>().SetTrigger("Idle_Battle");
                btna.interactable = false;

                

                if (ta == 0)
                {
                    ta = t + da;
                }

            }
        }
    }
    public void skillb(bool sb)
    {
        if (sb)
        {
            if (pt) {
                // 행동
                player.GetComponent<Animator>().SetTrigger("Attack2-1");
                player.GetComponent<Animator>().SetTrigger("Attack2-2");
                btnb.interactable = false;

                set1 = true;

                if (tb == 0)
                {
                    tb = t + db;
                }
                player.GetComponent<Animator>().SetTrigger("Idle_Battle"); 
   
            }
        }
    }
    public void skillc(bool sc)
    {
        if (sc)
        {
            if (pt)
            {
                //행동
                player.GetComponent<Animator>().SetTrigger("Attack1");
                btnc.interactable = false;

                set1 = true;

                if (tc == 0)
                {
                    tc = t + dc;
                }
                player.GetComponent<Animator>().SetTrigger("Idle_Battle");
  
                
            }
        }
    }
    public void skilld(bool sd)
    {
        if (sd)
        {
            if (pt) {
                //행동
                player.GetComponent<Animator>().SetTrigger("Defend"); 
                btnd.interactable = false;
                set1 = true;
                if (td == 0)
                {
                    td = t + dd;
                }
                player.GetComponent<Animator>().SetTrigger("Idle_Battle"); 

            }
        }
    }

}

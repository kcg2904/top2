using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterTrun : MonoBehaviour
{
    [Header("매니저 리스트")]
    public TrunManager mtrunManager;
    public SkillManager mskillManager;
    public UIManager muiManager;

    public int hp;
    public int ad;
    public int de;

    GameObject player;
    GameObject monster;

    public bool MoveCheck = false;

    public bool monstertrun;

    public bool playerCheck = false;

    float moveSpeed = 2;
    float targetDis;
    Vector3 coPosition;
    Vector3 MfPosition;

    // Start is called before the first frame update
    void Start()
    {
        mtrunManager = GameObject.Find("TrunManager").GetComponent<TrunManager>();
        mskillManager = GameObject.Find("SkillManager").GetComponent<SkillManager>();
        muiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        player = GameObject.Find("Player");
        monster = GameObject.Find("Monster");

    }

    // Update is called once per frame
    void Update()
    {

        Setting();
        Monsterbehavior();
 
    }
    IEnumerable Delay()
    {
        yield return new WaitForSeconds(0.5f);
    }
    private void Setting()
    {
        monstertrun = mtrunManager.monstertrun;
        hp = int.Parse(muiManager.MonsterHp.text);
        ad = int.Parse(muiManager.MonsterAd.text);
        de = int.Parse(muiManager.MonsterDefense.text);
        monster.transform.LookAt(player.transform.localPosition);

    }
    // 몬스터 로직
    private void Monsterbehavior()
    {
        if (playerCheck == false)
        {
            MtMoveTurn();
        }
        else if (playerCheck)
        {


                if (hp >= 70)
                {
                    mskillManager.onMonstera = true;
                }
                else if (hp <= 70 && hp > 30)
                {
                    if (mskillManager.monsterb == 0)
                    {
                        mskillManager.onMonsterb = true;
                    }
                    else
                    {
                        mskillManager.onMonstera = true;
                    }
                }
                else if (hp < 30)
                {
                    if (mskillManager.monsterc == 0)
                    {
                        mskillManager.onMonsterc = true;
                    }
                    else if (mskillManager.monsterb == 0 && mskillManager.monsterc != 0)
                    {
                        mskillManager.onMonsterb = true;
                    }
                    else
                    {
                        mskillManager.onMonstera = true;
                    }
                
            }
        }
    }
    public void MtMoveTurn()
    {
        if (monstertrun)
        {
            print("MtMoveTurn mt= true");
            MfPosition = coPosition;
            StopCoroutine("Move");
            StartCoroutine("Move");
        }

    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (MoveCheck == false)
            {
                playerCheck = true;
            }
        }
        else if (collision.gameObject.tag == "MoveFloor")
        {
            coPosition = GameObject.Find(collision.gameObject.name).transform.localPosition;
            coPosition.y = 0.5f;
            playerCheck = false;
        }

    }


    IEnumerator Move()
    {

        mtrunManager.monstertrun = false;

        while (true)
        {
            //남은 거리
            targetDis = (MfPosition - monster.transform.position).magnitude;


            mskillManager.monster.SetTrigger("WalkFWD");
            monster.transform.LookAt(MfPosition);
            monster.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            mskillManager.monster.SetTrigger("Idle");

            if (targetDis <= 0.1f)
            {
                //monster.transform.localRotation = Quaternion.Euler(0, 180, 0);
                mtrunManager.Reset1 = true;
                MoveCheck = true;
                //this.gameObject.GetComponent<BoxCollider>().enabled = false;
                StopCoroutine("Move");
            }

            yield return null;

        }
    }
}

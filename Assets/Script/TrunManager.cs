using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunManager : MonoBehaviour
{

    public bool playertrun;
    public bool monstertrun;

    [HideInInspector] public bool Reset1;
    [HideInInspector] public bool Reset2;

    public int trun;

    public int mExp = 0;

    // Start is called before the first frame update
    void Start()
    {
        SaveDataLoad();
        playertrun = true;
        monstertrun = false;
        trun = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (Reset1)
        {
            StartCoroutine("DelayTime1");
        }
        if (Reset2)
        {
            StartCoroutine("DelayTime2");
        }
    }
    //몬스터의 턴 종료시 실행
    IEnumerator DelayTime1() {
        monstertrun = false;
        yield return new WaitForSeconds(2f);
        Reset1 = false;
        trun += 1;
        playertrun = true;
        StopCoroutine("DelayTime1");
    }
    //플레이어의 턴 종료시 실행
    IEnumerator DelayTime2() {
        playertrun = false;
        GameObject.Find("MoveM").GetComponent<MonsterTrun>().MoveCheck = false;
        yield return new WaitForSeconds(2f);
        GameObject.Find("Player").transform.localRotation = Quaternion.Euler(0, 0, 0);
        monstertrun = true;
        Reset2 = false;
        StopCoroutine("DelayTime2");
    }

    public void SaveDataLoad()
    {
        mExp = GetPlayerExp();
    }

    public void SetPlayerExp(int _mExp)
    {
        mExp = _mExp;
        PlayerPrefs.SetInt(GlobalValue.mExp, _mExp);
    }

    public int GetPlayerExp()
    {
        mExp = PlayerPrefs.GetInt(GlobalValue.mExp);
        return mExp;
    }
}

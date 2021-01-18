using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("매니저 리스트")]
    public TrunManager mTrunManager;
    public SkillManager mSkillManager;

    [Header("턴 UI")]
    public Text TrunText;

    //상태창
    Text PlayerHp;
    Image Hpbar;
    [HideInInspector] public Text MonsterHp;
    [HideInInspector] public Text MonsterAd;
    [HideInInspector] public Text MonsterDefense;
    //버튼
    [HideInInspector] public Button btna;
    [HideInInspector] public Button btnb;
    [HideInInspector] public Button btnc;
    [HideInInspector] public Button btnd;
    [HideInInspector] public Button btnm;

    [HideInInspector] public bool mvok = false;
    //스킬 입력확인
    [HideInInspector] public bool onSkilla = false;
    [HideInInspector] public bool onSkillb = false;
    [HideInInspector] public bool onSkillc = false;
    [HideInInspector] public bool onSkilld = false;


    [HideInInspector] public int playerHP;
    [HideInInspector] public int playerAD;
    [HideInInspector] public int playerDF;
    [HideInInspector] public int monsterHP;
    [HideInInspector] public int monsterAD;
    [HideInInspector] public int monsterDF;
    [HideInInspector] public int mExp;


    //턴 확인
    int trun;
    // Start is called before the first frame update
    void Start()
    {
        StartSetting();
        SaveDataLoad();
    }
    public void StartSetting()
    {
        mTrunManager = GameObject.Find("TrunManager").GetComponent<TrunManager>();
        mSkillManager = GameObject.Find("SkillManager").GetComponent<SkillManager>();

        btna = GameObject.Find("skilla").GetComponent<Button>();  
        btnb = GameObject.Find("skillb").GetComponent<Button>();  
        btnc = GameObject.Find("skillc").GetComponent<Button>();  
        btnd = GameObject.Find("skilld").GetComponent<Button>();
        btnm = GameObject.Find("Movebtn").GetComponent<Button>();

        TrunText = GameObject.Find("Trunum").GetComponent<Text>();
        PlayerHp = GameObject.Find("Hpnum").GetComponent<Text>();
        Hpbar = GameObject.Find("Hpbar").GetComponent<Image>();
        MonsterHp = GameObject.Find("HPnum").GetComponent<Text>();
        MonsterAd = GameObject.Find("ADnum").GetComponent<Text>();
        MonsterDefense = GameObject.Find("DEnum").GetComponent<Text>();

        playerAD = GlobalValue.playeAD;
        playerDF = GlobalValue.playeDF;
        playerHP = GlobalValue.playerHP;
        monsterHP = GlobalValue.monsterHP;
        monsterAD = GlobalValue.monsterAD;
        monsterDF = GlobalValue.monsterDF;
        

        PlayerHp.text = playerHP.ToString();
        MonsterHp.text = monsterHP.ToString();
        MonsterAd.text = monsterAD.ToString();
        MonsterDefense.text = monsterDF.ToString();

    }
    public void setScore(int _value)
    {
        mExp += _value;
        PlayerPrefs.SetInt(GlobalValue.GetExp, _value);
    }
    public int getScore()
    {
        mExp = PlayerPrefs.GetInt(GlobalValue.GetExp);
        return mExp;
    }
    public void onScore()
    {
        setScore(1);
        print("클릭됨");
    }
    public void SaveDataLoad()
    {
        mExp = getScore();
    }

    // Update is called once per frame
    void Update()
    {
        SaveDataLoad();
        print(getScore());
        Setting();
        
    }

    void Setting()
    {
        trun = mTrunManager.trun;
        TrunText.text = trun.ToString();
        
        PlayerHp.text = playerHP.ToString();
        MonsterHp.text = monsterHP.ToString();
        MonsterAd.text = monsterAD.ToString();
        MonsterDefense.text = monsterDF.ToString();
        Hpbar.fillAmount = playerHP * 0.01f;

    }
    public void onbtnm()
    {
        if (mvok)
        {
            mvok = false;
        }
        else
        {
            mvok = true;
        }
    }
    public void onbtna()
    {
        onSkilla = true;
    }    
    public void onbtnb()
    {
        onSkillb = true;
    }   
    public void onbtnc()
    {
        onSkillc = true;
    }   
    public void onbtnd()
    {
        onSkilld = true;
    }
}

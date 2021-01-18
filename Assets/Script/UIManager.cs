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
    Text PlyerHp;
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
    




    //턴 확인
    int trun;
    // Start is called before the first frame update
    void Start()
    {
        mTrunManager = GameObject.Find("TrunManager").GetComponent<TrunManager>();
        mSkillManager = GameObject.Find("SkillManager").GetComponent<SkillManager>();

        btna = GameObject.Find("skilla").GetComponent<Button>();  
        btnb = GameObject.Find("skillb").GetComponent<Button>();  
        btnc = GameObject.Find("skillc").GetComponent<Button>();  
        btnd = GameObject.Find("skilld").GetComponent<Button>();
        btnm = GameObject.Find("Movebtn").GetComponent<Button>();

        TrunText = GameObject.Find("Trunum").GetComponent<Text>();
        PlyerHp = GameObject.Find("Hpnum").GetComponent<Text>();
        Hpbar = GameObject.Find("Hpbar").GetComponent<Image>();
        MonsterHp = GameObject.Find("HPnum").GetComponent<Text>();
        MonsterAd = GameObject.Find("ADnum").GetComponent<Text>();
        MonsterDefense = GameObject.Find("DEnum").GetComponent<Text>();  
        
    }

    // Update is called once per frame
    void Update()
    {
        Setting();
        
    }

    void Setting()
    {
        trun = mTrunManager.trun;
        TrunText.text = trun.ToString();
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

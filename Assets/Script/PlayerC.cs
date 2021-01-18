using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC : MonoBehaviour
{
    public MonsterTrun mMonsterTrun;
    // Start is called before the first frame update
    void Start()
    {
        mMonsterTrun = GameObject.Find("MoveM").GetComponent<MonsterTrun>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            mMonsterTrun.playerCheck = true;
        }
    }
}

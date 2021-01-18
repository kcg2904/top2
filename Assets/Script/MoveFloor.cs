using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    GameObject player;
    
    SpriteRenderer sr;
    Material mtg;
    Material mtd;

    public bool monster;
    public bool mvok = false;
    bool btn;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        monster = GameObject.Find("MoveM").GetComponent<MonsterTrun>();
        sr = this.gameObject.GetComponent<SpriteRenderer>();
        mtg = Resources.Load("g", typeof(Material)) as Material;
        mtd = Resources.Load("d", typeof(Material)) as Material;

    }

    // Update is called once per frame
    void Update()
    {
        btn = GameObject.Find("UIManager").GetComponent<UIManager>().mvok;

        if (mvok){
                if (btn)
                {
                    sr.material = mtg;
                }else
                {

                sr.material = mtd;
            }
            }   
            else if (mvok == false)
            {
                sr.material = mtd;
            }

     
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == player.name)
        {

                mvok = true;
            
        }
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            mvok = false;
        }

            if (other.gameObject.tag == "Monster")
            {
                this.gameObject.GetComponent<MoveFloor>().mvok = false;
            }
        

    }
    private void OnCollisionExit(Collision collision)
    {
       if (collision.gameObject.name == player.name)
        {
            mvok = false;
        }
    }

}

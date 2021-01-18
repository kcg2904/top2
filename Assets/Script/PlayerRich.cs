using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRich : MonoBehaviour
{
    // Start is called before the first frame update
    public bool PlayerSkillRichOn;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Monster")
        {
            PlayerSkillRichOn = true;
        }

    }
}

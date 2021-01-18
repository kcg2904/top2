using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public partial class UIManager : MonoBehaviour
{

    public void setScore(int _value)
    {
        mExp = mTrunManager.GetPlayerExp();
        mTrunManager.SetPlayerExp(mExp + _value);
    }
    public void onScore()
    {
        setScore(1);
        print(mTrunManager.GetPlayerExp());
    }
    if()


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//2018-11-17 宋柏慧
//---------------------------------------------------------
//这个脚本的功能为当金币吃光 则隐藏当前金币组 重新随机激活一个金币组
//从而达到刷新金币组的效果
//---------------------------------------------------------


public class PickUpTrans : MonoBehaviour
{

    public GameObject[] pickups;//金币数组

    void Update()
    {
        SetPickUpActive();
    }

    private void SetPickUpActive()//判断若子物体未激活 则随机激活一个
    {
        int i = pickups.Length;
        foreach (GameObject childs in pickups)
        {
            if (childs.gameObject.activeSelf == false)
            {
                i--;
            }
            if (i == 0)
            {
                GameObject pickup = pickups[(int)Random.Range(0, 3)];
                pickup.SetActive(true);
                foreach (Transform child in pickup.transform)
                {
                    child.gameObject.SetActive(true);
                }
            }
        }
    }
}

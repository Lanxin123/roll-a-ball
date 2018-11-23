using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//2018-11-17 宋柏慧
//---------------------------------------------------------
//这个脚本的功能为切换场景
//从而达到开始场景进入到主场景的效果
//---------------------------------------------------------


public class SceneController : MonoBehaviour
{


    public void StartToMain()
    {
        SceneManager.LoadScene(1);
    }

}

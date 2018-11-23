using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//2018-11-17 宋柏慧
//---------------------------------------------------------
//这个脚本的功能为使摄像机与小球保持固定距离
//从而达到摄像头跟随小球的效果
//---------------------------------------------------------

public class GameController : MonoBehaviour
{

    public GameObject player;

    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}

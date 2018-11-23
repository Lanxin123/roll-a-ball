using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//2018-11-17 宋柏慧
//---------------------------------------------------------
//这个脚本的功能为实时更新金币rotation
//从而达到金币选择的效果
//---------------------------------------------------------


public class Rotator : MonoBehaviour {

	void Update () {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//2018-11-17 宋柏慧
//---------------------------------------------------------
//这个脚本内包含:
//                          小球控制 
//                          死亡判断
//                          音效
//                          得分更新 储存
//                          碰撞事件
//                          gameover界面
//---------------------------------------------------------

public class PlayerController : MonoBehaviour {

    public float speed;                                 //小球运动速度
    public Text countText;                            //得分文本
    public Image loseImage;                       //GameOver图片
    public AudioSource coinSound;           //得到金币声音
    public AudioSource dieSound;              //死亡声音

    private Rigidbody rb;                               
    private int count;                                      //得分

	void Start () {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();

    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void Update()
    {
        LoseJudge();
    }


    private void Lose()
    {
        dieSound.Play();
        Onfile();
        StartCoroutine(WaitSeconds(0.5f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            coinSound.Play();
            SetCountText();
        }
        SearchAndSetActive(other);
        //set music then
    }

    //设置得分文本
    private void SetCountText()
    {
        countText.text = "得分：" + count.ToString();
    }
    //存储得分
    public void Onfile()
    {
        PlayerPrefs.SetInt("count", count);
    }
    //失败判定
    private void LoseJudge()
    {
        if (gameObject.transform.position.x <-10 ||  gameObject.transform.position.x > 10 || gameObject.transform.position.z>10 || gameObject.transform.position.z<-10)
        {
            loseImage.gameObject.SetActive(true);
            Lose();
        }
    }
    //判断若子物体未激活 则随机激活一个
    private void SearchAndSetActive(Collider other)
    {
        GameObject titleFrame = other.gameObject.transform.parent.gameObject;
        int i = titleFrame.transform.childCount;
        foreach (Transform child in titleFrame.transform)
        {
            if (child.gameObject.activeSelf == false)
            {
                i--;
            }
            if (i == 0)
            {
                titleFrame.SetActive(false);
            }
        }
    }

    IEnumerator WaitSeconds(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("Final");
    }
}

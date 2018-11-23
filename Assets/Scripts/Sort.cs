using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//2018-11-17 宋柏慧
//---------------------------------------------------------
//这个脚本的功能为 排序并显示得分
//从而达到排行榜的效果
//---------------------------------------------------------

public class Sort : MonoBehaviour
{

    public GameObject L0;
    public GameObject[] newIndexs;

    public GameObject Panel;

    public Text indexText;

    int count;//用来把取的数赋值于此

    int[] save = new int[10];
    int Num;
    string saveIntStr;

    //插入排序

    // Use this for initialization
    void Start()
    {

        //获取上一场景存储的数据
        count = PlayerPrefs.GetInt("count");
        indexText.text = "Your score：" + count.ToString();

        //获取存储的排行榜中的数据
        for (int i = 0; i < 10; i++)
        {
            string saveIntStrS = saveIntStr + i.ToString();
            save[i] = PlayerPrefs.GetInt(saveIntStrS);
        }

        //添加新数据并排序（从小到大）
        for (int i = 0; i < 10; i++)
        {
            if (save[i] == null || save[i] == 0)
            {
                save[i] = count;
                Num = i;

                for (int m = 0; m < Num + 1; ++m)
                {
                    int t = save[m];
                    int n = m;
                    while ((n > 0) && (save[n - 1] < t))
                    {
                        save[n] = save[n - 1];
                        --n;
                    }
                    save[n] = t;
                }

                break;
            }
            else
            {
                int n = 9;
                if (count > save[9])
                {
                    while (save[n - 1] < count)
                    {
                        save[n] = save[n - 1];
                        --n;
                        save[n] = count;

                        if (n == 0)
                        {
                            break;
                        }
                    }
                    break;
                }
            }
        }

        //把当前数据存储
        for (int j = 0; j < 10; j++)
        {
            string saveIntStrI = saveIntStr + j.ToString();
            PlayerPrefs.SetInt(saveIntStrI, save[j]);
            //PlayerPrefs.SetInt(saveIntStrI, 0);
        }

        //将数据显示到场景UI中
        for (int i = 0; i < newIndexs.Length; i++)
        {
            string saveIntStrO = saveIntStr + i.ToString();
            newIndexs[i] = Instantiate(L0, transform.position, transform.rotation) as GameObject;
            newIndexs[i].transform.SetParent(Panel.transform);
            newIndexs[i].GetComponent<Text>().text = "\t \t \t \t \t" + PlayerPrefs.GetInt(saveIntStrO).ToString() + "\t \t ";
        }
    }

    //删除接口 (未被调用)
    public void DeleteFile()
    {
        PlayerPrefs.DeleteAll();
    }

    public void reStart()
    {
        SceneManager.LoadScene("MainGame");
    }
}

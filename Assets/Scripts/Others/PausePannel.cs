using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePannel : MonoBehaviour
{
    private bool isopen = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//这一帧是否按下了对应按键
        {
            if (!isopen)
            {
                open();

            }
            else if (isopen)
            {
                close();

            }
        }
    }
    public void open()
    {
        Time.timeScale = 0;//游戏时间流速变为0
        transform.GetChild(0).gameObject.SetActive(true);//脚本挂载的物体他的第一个子物体（用0表示）的setactive变为true
        isopen = true;
    }
    public void close()
    {
        Time.timeScale = 1;//游戏时间流速恢复
        transform.GetChild(0).gameObject.SetActive(false);//脚本挂载的物体他的第一个子物体（用0表示）的setactive变为false
        isopen = false;
    }
    public void BacktoMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}

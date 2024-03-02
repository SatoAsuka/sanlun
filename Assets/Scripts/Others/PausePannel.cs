using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePannel : MonoBehaviour
{
    private bool isopen = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//��һ֡�Ƿ����˶�Ӧ����
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
        Time.timeScale = 0;//��Ϸʱ�����ٱ�Ϊ0
        transform.GetChild(0).gameObject.SetActive(true);//�ű����ص��������ĵ�һ�������壨��0��ʾ����setactive��Ϊtrue
        isopen = true;
    }
    public void close()
    {
        Time.timeScale = 1;//��Ϸʱ�����ٻָ�
        transform.GetChild(0).gameObject.SetActive(false);//�ű����ص��������ĵ�һ�������壨��0��ʾ����setactive��Ϊfalse
        isopen = false;
    }
    public void BacktoMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void StartBtnPressed()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void HomeBtnPressed()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void RetryBtnPressed()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void RankBtnPressed()
    {

    }

    public void SettingBtnPressed()
    {
        GameObject main = GameObject.Find("MainButtons");
        GameObject map = GameObject.Find("MapSetButtons");

        for (int i = 0; i < 3; i++)
        {
            main.transform.GetChild(i).gameObject.SetActive(false);
            map.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void SetMapSize()
    {
        //Maincode

        GameObject main = GameObject.Find("MainButtons");
        GameObject map = GameObject.Find("MapSetButtons");

        for (int i = 0; i < 3; i++)
        {
            map.transform.GetChild(i).gameObject.SetActive(false);
            main.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}

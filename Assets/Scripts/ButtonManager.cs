using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void HomeBtnPressed()
    {

    }

    public void RetryBtnPressed()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(gameObject.scene.name);
    }

    public void RankBtnPressed()
    {

    }
}

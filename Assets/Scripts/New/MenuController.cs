using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    public static bool isPause = false;
    public static bool first = true;


    public void ChangeScene(string scene)
    {
        isPause = false;
        CanvasScript.ZeroScore();
        SceneManager.LoadScene(scene);

        if (!PlayerPrefs.GetInt("first").Equals(1))
        {
            isPause = true;
        }
        /*PlayerPrefs.SetInt("first", 1);
        if (first)
        {
            isPause = true;
            //first = false;
            StartCoroutine(setfirstfalse());
        }*/
    }

    IEnumerator setfirstfalse()
    {
        yield return new WaitForSeconds(0.2f);
        first = false;
    }

    public void SetPause()
    {
        if (!isPause)
        {
            panel.SetActive(true);
            isPause = true;

        }
    }

    public void GoGame()
    {
        panel.SetActive(false);
        isPause = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    [SerializeField] private Slider o2Slider;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text scoreTextPanel;
    [SerializeField] private GameObject firstPanel;

    public static int score = 0;


    private void Awake()
    {
        if (!PlayerPrefs.GetInt("first").Equals(1))
        {
            firstPanel.SetActive(true);
            PlayerPrefs.SetInt("first", 1);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        o2Slider.value = o2Slider.maxValue;
        StartCoroutine(SliderFade());
    }

    IEnumerator SliderFade()
    {
        while (true)
        {
            if (!MenuController.isPause)
            {
                o2Slider.value -= 0.01f;
                o2Slider.value = Mathf.Clamp(o2Slider.value, o2Slider.minValue, o2Slider.maxValue);
            }
            yield return new WaitForSeconds(0.3f);
        }
    }

    private void FixedUpdate()
    {
        scoreText.text = string.Format("{0:0000}", score);
        scoreTextPanel.text = scoreText.text;
        //string.Format("{0:0}:{1:00}", min, sec);
    }

    public void AddO2()
    {
        o2Slider.value += 0.2f;
    }

    public static void AddScore(int add)
    {
        score += add;
    }

    public float o2Level()
    {
        return o2Slider.value;
    }
    
    public static void ZeroScore()
    {
        score = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class UiManager : MonoBehaviour
{
    public GameObject zigzagPanel;
    public GameObject gameoverPanel;
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore1;
    public TextMeshProUGUI highScore2;
    public GameObject tap;

    public static UiManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        highScore1.text = "HighScore:"+PlayerPrefs.GetInt("highScore").ToString();
    }
    public void GameStart()
    {
        
        tap.GetComponent<Animator>().Play("Start");
        zigzagPanel.GetComponent<Animator>().Play("Panel");
    }

    public void GameOver()
    {
        gameoverPanel.SetActive(true);
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }

}

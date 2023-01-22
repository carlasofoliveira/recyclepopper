using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinishGameManager : MonoBehaviour
{
    public static FinishGameManager Instance;

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI youLostText;
    [SerializeField] private TextMeshProUGUI plasticText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        Instance = this;
    }

    public void FinishGame()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);

        bool isNewHighScore = PlasticsManager.Instance.CheckNewHighscore();
        if (isNewHighScore)
        {
            youLostText.text = "New Highscore!";
        }

        int plasticCollectedThisGame = PlayerMoney.Instance.GetAndSavePlastic();
        plasticText.text = "Plastic: " + plasticCollectedThisGame;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

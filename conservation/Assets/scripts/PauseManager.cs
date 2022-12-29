using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    private bool isGamePaused;
    private bool canPause = true;
    private float timeBeforePause;

    [SerializeField] private GameObject pauseTextGO;
    [SerializeField] private Image pauseButtonImage;

    [SerializeField] private Sprite pauseButtonSprite;
    [SerializeField] private Sprite playButtonSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TogglePause()
    {
        if (!canPause)
            return;
        isGamePaused = !isGamePaused;

        if (isGamePaused)
        {
            pauseTextGO.SetActive(true);
            pauseButtonImage.sprite = playButtonSprite;

            timeBeforePause = Time.timeScale;
            Time.timeScale = 0;
        }
        else
        {
            pauseTextGO.SetActive(false);
            pauseButtonImage.sprite = pauseButtonSprite;

            Time.timeScale = timeBeforePause;
        }
    }

    public void ChangePauseTo(bool changeItTo)
    {
        canPause = changeItTo;
    }
}

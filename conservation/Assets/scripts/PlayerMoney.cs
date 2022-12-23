using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField] private int currentPaper;

    public static PlayerMoney Instance;

    public const string prefpaper = "prefpaper";

    private void Awake()
    {
        Instance = this;
        currentPaper = PlayerPrefs.GetInt(prefpaper);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPaper(int paperToAdd)
    {
        currentPaper += paperToAdd;
    }

    public int GetAndSavePaper()
    {
        int paperCollectedThisGame = currentPaper - PlayerPrefs.GetInt(prefpaper);
        PlayerPrefs.SetInt(prefpaper, currentPaper);

        return paperCollectedThisGame;
    }
}

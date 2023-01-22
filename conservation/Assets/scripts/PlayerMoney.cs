using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField] private int currentPlastic;

    public static PlayerMoney Instance;

    public const string prefPlastic = "prefPlastic";

    private void Awake()
    {
        Instance = this;
        currentPlastic = PlayerPrefs.GetInt(prefPlastic);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPlastic(int plasticToAdd)
    {
        currentPlastic += plasticToAdd;
        PlayerPrefs.SetInt(prefPlastic, currentPlastic);
    }

    public void AddPlasticAndSave(int plasticToAdd)
    {
        currentPlastic += plasticToAdd;
        PlayerPrefs.SetInt(prefPlastic, currentPlastic);
    }

    public int GetAndSavePlastic()
    {
        int plasticCollectedThisGame = PlayerPrefs.GetInt(prefPlastic);

        return plasticCollectedThisGame;
    }

    public int ReturnCurrentPlastic()
    {
        return currentPlastic;
    }
}

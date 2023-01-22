using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlasticsManager : MonoBehaviour
{
    public static PlasticsManager Instance;

    [SerializeField] private TextMeshProUGUI plasticText;
    private float plasticCollected;
    private bool isTraveling;

    public const string prefPlastic = "prefPlastic";

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTraveling)
            return;
        plasticText.text = PlayerPrefs.GetInt(prefPlastic) + " plastic";
        
    }

    public void StartScript()
    {
        isTraveling = true;
    }

    public bool CheckNewHighscore()
    {
        if ((int)plasticCollected > PlayerPrefs.GetInt(prefPlastic))
        {
            // new highscore
            PlayerPrefs.SetInt(prefPlastic, (int)plasticCollected);
            Debug.Log("new highscore: " + (int)plasticCollected + " plastic");
            return true;
        }
        else
        {
            // no new highscore
            Debug.Log("no new highscore");
            return false;
        }
    }
}

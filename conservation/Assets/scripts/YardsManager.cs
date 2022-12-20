using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class YardsManager : MonoBehaviour
{
    public static YardsManager Instance;

    [SerializeField] private TextMeshProUGUI yardsText;
    private float yardsTraveled;
    private bool isTraveling;

    public const string prefyards = "prefyards";

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
        yardsTraveled += Time.deltaTime * 5;
        yardsText.text = (int)yardsTraveled + " yd";
    }

    public void StartScript()
    {
        isTraveling = true;
    }

    public bool CheckNewHighscore()
    {
        if ((int)yardsTraveled > PlayerPrefs.GetInt(prefyards))
        {
            // new highscore
            PlayerPrefs.SetInt(prefyards, (int)yardsTraveled);
            Debug.Log("new highscore: " + (int)yardsTraveled);
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

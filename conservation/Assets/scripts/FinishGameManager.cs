using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGameManager : MonoBehaviour
{
    public static FinishGameManager Instance;

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
    }
}

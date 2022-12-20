using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) || (Input.touchCount > 0))
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        SpawnManager.Instance.StartScript();
        YardsManager.Instance.StartScript();
        enabled = false;  // this disables the script
    }
}

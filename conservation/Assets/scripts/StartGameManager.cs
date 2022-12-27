using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameManager : MonoBehaviour
{
    public void StartGame()
    {
        SpawnManager.Instance.StartScript();
        YardsManager.Instance.StartScript();
        BoatMovement.Instance.StartScript();
        enabled = false;  // this disables the script
    }
}

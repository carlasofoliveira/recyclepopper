using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartGameManager : MonoBehaviour
{
    public void StartGame()
    {
        
        if (ShopManager.Instance.WentToFactory())
        {
            Time.timeScale = 1;
            ShopManager.Instance.SetWentToFactory(false);
        }
        else
        {
            SpawnManager.Instance.StartScript();
            PlasticsManager.Instance.StartScript();
            PlayerMovement.Instance.StartScript();
            //enabled = false;  // this disables the script
        }
    }
}

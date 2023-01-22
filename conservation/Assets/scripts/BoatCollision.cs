using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Entity"))
        {
            switch (collision.GetComponent<EntityType>().entityType)
            {
                case EntityType.EntityTypes.booty:
                    // add score
                    PlayerMoney.Instance.AddPlastic(1);
                    Destroy(collision.gameObject);
                    break;
                case EntityType.EntityTypes.rock:
                    // lose
                    Debug.Log("You lost");
                    FinishGameManager.Instance.FinishGame();
                    break;
                case EntityType.EntityTypes.factory:
                    // pause and show store
                    ShopManager.Instance.DisplayStore();
                    break;
            }
        }
    }
}

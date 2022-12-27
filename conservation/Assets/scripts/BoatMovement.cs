using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    public static BoatMovement Instance;

    private Rigidbody2D rb;
    private Camera mainCamera;

    [SerializeField] private float xMargin = 2;
    [SerializeField] private float boatSpeed = 50;

    private bool canMove;

    private void Awake()
    {
        Instance = this;

        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove)
            return;

        int dirX = 0;
        transform.rotation = Quaternion.Euler(0, 0, 0);

        // just for running in unity editor
        if (Application.isEditor)
        {
            // wasd input
            if (Input.GetKey(KeyCode.D))
            {
                dirX = 1;
                transform.rotation = Quaternion.Euler(0, 0, -30);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                dirX = -1;
                transform.rotation = Quaternion.Euler(0, 0, 30);
            }
        }
        else
        {
            if (Input.touches.Length > 0) {
                Vector3 touchPosition = Input.touches[0].position;
                touchPosition = mainCamera.ScreenToWorldPoint(touchPosition);

                if (touchPosition.x > 0)
                {
                    dirX = 1;
                    transform.rotation = Quaternion.Euler(0, 0, -30);
                }
                else
                {
                    dirX = -1;
                    transform.rotation = Quaternion.Euler(0, 0, 30);
                }
            }
        }

        rb.velocity = new Vector2(dirX * boatSpeed * Time.deltaTime, 0);

        float posX = transform.position.x;
        posX = Mathf.Clamp(posX, -xMargin, xMargin);
        transform.position = new Vector3(posX, transform.position.y, transform.position.z);
    }

    public void StartScript()
    {
        canMove = true;

        int strongerOarsLevel = PlayerPrefs.GetInt(ShopItem.ShopItems.strongerOars.ToString());

        if (strongerOarsLevel > 0)
        {
            boatSpeed += strongerOarsLevel * 50;
        }
    }
}

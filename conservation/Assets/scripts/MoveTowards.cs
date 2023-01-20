using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    [SerializeField] private Vector3 positionToGoBackTo;
    [SerializeField] private Vector3 destination;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
            return;

        transform.position = Vector2.MoveTowards(transform.position, destination, speed);

        if (transform.position == destination)
            transform.position = positionToGoBackTo;
    }
}

using System;
using UnityEngine;

public class Floatinig : MonoBehaviour
{
    [SerializeField] float speed;
    private float topPosition;
    private float bottomPosition;
    private bool goingUp = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        topPosition = transform.position.y + 0.25f;
        bottomPosition = transform.position.y - 0.25f;
        if (UnityEngine.Random.Range(0, 10) < 5)
        {
            goingUp = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (goingUp)
        {
            if (transform.position.y < topPosition)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
            } else {
                goingUp = false;
            }
        } else {
            if (transform.position.y > bottomPosition)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
            } else {
                goingUp = true;
            }
        }
    }
}

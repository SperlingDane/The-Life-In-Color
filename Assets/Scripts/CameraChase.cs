using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChase : MonoBehaviour
{

    public float speed, offset;
    public bool reachedUp;
    private Vector2 startingPosition;


    // Start is called before the first frame update
    void Start()
    {
        reachedUp = false;
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= startingPosition.y + offset)
        {
            reachedUp = true;
        }
    }

    void FixedUpdate()
    {
        if (!reachedUp)
        {
            transform.Translate(Vector2.up * Time.deltaTime * speed);
        }
    }
}

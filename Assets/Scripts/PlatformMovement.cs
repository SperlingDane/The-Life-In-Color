using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{





    // Start is called before the first frame update

    [SerializeField] float offsetLeft = 0, offsetRight = 0, offsetUp = 0, offsetDown = 0, speed = 1;
    [SerializeField] bool hasReachedRight = true, hasReachedLeft = true, hasReachedUp = true, hasReachedDown = true;
    Vector3 startPosition = Vector3.zero;

    void Awake()
    {
        startPosition = transform.position;
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        if (!hasReachedRight)
        {
            if (transform.position.x < startPosition.x + offsetRight)
            {
                // Move platform to the right
                moveHorizontal(offsetRight);
            }
            else if (transform.position.x >= startPosition.x + offsetRight)
            {
                hasReachedRight = true;
                hasReachedLeft = false;
            }
        }
        else if (!hasReachedLeft)
        {
            if (transform.position.x > startPosition.x + offsetLeft)
            {
                // Move platform to the left 
                moveHorizontal(offsetLeft);
            }
            else if (transform.position.x <= startPosition.x + offsetLeft)
            {
                hasReachedRight = false;
                hasReachedLeft = true;
            }
        }
        else if (!hasReachedUp) {
            if (transform.position.y < startPosition.y + offsetUp)
            {
                moveVertical(offsetUp);
            }
            else if(transform.position.y >= startPosition.x + offsetUp)
            {
                hasReachedUp = true;
                hasReachedDown = false;
            }
        }
        else if (!hasReachedDown)
        {
            if(transform.position.y > startPosition.y + offsetDown)
            {
                moveVertical(offsetDown);
            }
            else if(transform.position.y <= startPosition.y + offsetDown)
            {
                hasReachedUp = false;
                hasReachedDown = true;
            }
        }
    }

    void moveHorizontal(float offset)
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(startPosition.x + offset, transform.position.y, transform.position.z), speed * Time.deltaTime);
    }

    void moveVertical(float offset)
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, startPosition.y + offset, transform.position.z), speed * Time.deltaTime);
    }
}
    
    





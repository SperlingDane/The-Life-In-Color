using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathplane : MonoBehaviour
{
    
    private Vector2 playerPos;
    //private Vector2 playerPos1 = new Vector2(-525f, -68.92f);
    //private Vector2 playerPos2 = new Vector2(0f, 0f);
    [SerializeField] private GameObject currentPlatform;
    [SerializeField] private int lives = 2;
    [SerializeField] private Scene sceneLoaded;
    private bool onPlatform;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoaded = SceneManager.GetActiveScene();
        //Debug.Log("This is scene " + sceneLoaded.buildIndex);

        
    }

    // Update is called once per frame
    void Update()
    { 
        if(lives < 0)
        {
            SceneManager.LoadScene(sceneLoaded.buildIndex);
        }
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Death"))
        {
            lives--;
            if (lives >= 0 && !onPlatform)
            {
                playerPos = new Vector2(currentPlatform.transform.position.x, currentPlatform.transform.position.y + 2.61765f);
                transform.parent.position = playerPos;
            }
        }

        if (other.gameObject.CompareTag("Platform"))
        {
            currentPlatform = other.transform.parent.gameObject;
            onPlatform = true;
        }
        if (other.gameObject.CompareTag("Exit"))
        {
            SceneManager.LoadScene(sceneLoaded.buildIndex + 1);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            onPlatform = false;
        }
    }


}

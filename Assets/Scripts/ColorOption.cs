using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorOption : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject Red, Blue, Green;
    [SerializeField] private CanvasGroup RedCircle, BlueCircle, GreenCircle;
    [SerializeField] private bool isRed, isBlue, isGreen;
    private Scene sceneLoaded;
    private string lastColor;
    
    private bool selected, touching;

    void Start()
    {
        
        touching = false;
        RedCircle.alpha = 0;
        BlueCircle.alpha = 0;
        GreenCircle.alpha = 0;
        isRed = GlobalControl.Instance.isRed;
        isBlue = GlobalControl.Instance.isBlue;
        isGreen = GlobalControl.Instance.isGreen;
        selected = false;
        sceneLoaded = SceneManager.GetActiveScene();

        if (isRed)
        {
            Destroy(Red);
        }
        if (isBlue)
        {
            Destroy(Blue);
        }
        if (isGreen)
        {
            Destroy(Green);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(touching && isRed && Input.GetKey(KeyCode.E))
        {
            
            isRed = true;
            RedCircle.alpha = 0;
            lastColor = "Red";
            SavePlayer();
            selected = true;
            SceneManager.LoadScene(sceneLoaded.buildIndex + 1);
        }

        if (touching && isBlue && Input.GetKey(KeyCode.E))
        {
            
            isBlue = true;
            BlueCircle.alpha = 0;
            lastColor = "Blue";
            SavePlayer();
            selected = true;
            SceneManager.LoadScene(sceneLoaded.buildIndex + 1);
        }

        if (touching && isGreen && Input.GetKey(KeyCode.E))
        {
            
            isGreen = true;
            lastColor = "Green";
            GreenCircle.alpha = 0;
            SavePlayer();
            selected = true;
            SceneManager.LoadScene(sceneLoaded.buildIndex + 1);
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Red") && !selected)
        {
            RedCircle.alpha = 1;
            isRed = true;
            touching = true;
        }
        if (other.CompareTag("Green") && !selected)
        {
            GreenCircle.alpha = 1;
            isGreen = true;
            touching = true;
        }
        if (other.CompareTag("Blue") && !selected)
        {
            BlueCircle.alpha = 1;
            isBlue = true;
            touching = true;
        }
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Red") && !selected)
        {
            RedCircle.alpha = 0;
            isRed = false;
            touching = false;
        }
        if (other.CompareTag("Green") && !selected)
        {
            GreenCircle.alpha = 0;
            isGreen = false;
            touching = false;
        }
        if (other.CompareTag("Blue") && !selected)
        {
            BlueCircle.alpha = 0;
            isBlue = false;
            touching = false;
        }
        
    }

    public void SavePlayer()
    {
        GlobalControl.Instance.isRed = isRed;
        GlobalControl.Instance.isBlue = isBlue;
        GlobalControl.Instance.isGreen = isGreen;
        GlobalControl.Instance.lastColor = lastColor;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private CanvasGroup pause;
    [SerializeField] private bool isAlpha = false;
    // Start is called before the first frame update
    void Start()
    {
        pause.alpha = 0;
        pause.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isAlpha)
        {
            PauseButton();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isAlpha)
        {
            Resume();
        }

    }

    public void PauseButton()
    {
        pause.alpha = 1;
        pause.interactable = true;
        isAlpha = true;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        pause.alpha = 0;
        pause.interactable = false;
        isAlpha = false;
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
        
    }
}

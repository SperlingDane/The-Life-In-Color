using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private Scene sceneLoaded;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoaded = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        SceneManager.LoadScene(sceneLoaded.buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
        
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}

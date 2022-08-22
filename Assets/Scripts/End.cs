using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    [SerializeField] private GameObject endCircle;
    [SerializeField] private CanvasGroup EndCircle;
    [SerializeField] private bool isEnd, touching;

    // Start is called before the first frame update
    void Start()
    {
        isEnd = false;
        touching = false;
        EndCircle.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (touching && isEnd && Input.GetKey(KeyCode.E))
        {
            SceneManager.LoadScene(0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("End"))
        {
            EndCircle.alpha = 1;
            isEnd = true;
            touching = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("End"))
        {
            EndCircle.alpha = 0;
            isEnd = false;
            touching = false;
        }
    }
}

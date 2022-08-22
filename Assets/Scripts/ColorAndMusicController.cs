using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColorAndMusicController : MonoBehaviour {


    [SerializeField] private Sprite MountainColored, OceanColored, Tree1Colored, Tree2Colored, Tree3Colored, Platform, Ground, BackgroundColored;
    [SerializeField] private SpriteRenderer[] mountains, ocean, tree1, tree2, tree3, platforms, ground, background;
    private int count1, count2, count3, count4, count5, count6, count7, count8;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip red, blue, green;


    // Start is called before the first frame update
    void Start()
    {
        count1 = 0;
        count2 = 0;
        count3 = 0;
        count4 = 0;
        count5 = 0;
        count6 = 0;
        count7 = 0;
        count8 = 0;
        audioSource = GetComponent<AudioSource>();
        if (GlobalControl.Instance.lastColor == "Blue")
        {
            audioSource.clip = blue;
        }
        if (GlobalControl.Instance.lastColor == "Green")
        {
            audioSource.clip = green;
        }
        if (GlobalControl.Instance.lastColor == "Red")
        {
            audioSource.clip = red;
        }
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

        while ((GlobalControl.Instance.isRed) && count1 != mountains.Length)
        {
            mountains[count1].sprite = MountainColored;
            count1++;
        }
        while ((GlobalControl.Instance.isBlue) && count2 != ocean.Length)
        {
            ocean[count2].sprite = OceanColored;
            count2++;
        }
        while ((GlobalControl.Instance.isBlue) && count8 != background.Length)
        {
            background[count8].sprite = BackgroundColored;
            count8++;
        }
        while ((GlobalControl.Instance.isGreen) && count3 != tree1.Length)
        {
            tree1[count3].sprite = Tree1Colored;
            count3++;
        }
        while ((GlobalControl.Instance.isGreen) && count4 != tree2.Length)
        {
            tree2[count4].sprite = Tree2Colored;
            count4++;
        }
        while ((GlobalControl.Instance.isGreen) && count5 != tree3.Length)
        {
            tree3[count5].sprite = Tree3Colored;
            count5++;
        }
        while ((GlobalControl.Instance.isGreen) && count6 != platforms.Length)
        {
            platforms[count6].sprite = Platform;
            count6++;
        }
        while ((GlobalControl.Instance.isGreen) && count7 != ground.Length)
        {
            ground[count7].sprite = Ground;
            count7++;
        }
    }


}



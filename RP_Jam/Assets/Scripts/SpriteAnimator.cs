using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    SpriteRenderer sr;
    Animator anim;

    [SerializeField] BootScript player;
    [SerializeField] UI_Manager ui;

    [SerializeField] SpriteRenderer skySr;
    [SerializeField] List<Color> colours = new List<Color>();

    int animIndex;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        BgAnim();
    }


    void BgAnim()
    {
        float val = player.GetIdeologyVal();

        if(val < 30 && val > -30)
        {
            animIndex = 0;
            skySr.color = colours[0];
        }
        if(val < 75 && val >= 30)
        {
            animIndex = 1;
            skySr.color = colours[1];
        }
        if(val >= 75)
        {
            animIndex = 2;
            skySr.color = colours[2];
        }

        if (val > -75 && val <= -30)
        {
            animIndex = -1;
            skySr.color = colours[3];
        }
        if (val <= -75)
        {
            animIndex = -2;
            skySr.color = colours[4];
        }

        anim.SetFloat("brokenVal", animIndex);
    }


}

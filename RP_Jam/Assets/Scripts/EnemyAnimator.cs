using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    Enemy enemy;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.GetGood())
        {
            anim.SetFloat("goodVal", 1);
        }
        else
        {
            anim.SetFloat("goodVal", 0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] Transform moveTarget;

    float ideologyLevel = 0;

    bool isGood;


    void Start()
    {
        moveTarget = GameObject.FindGameObjectWithTag("EnemyTarget").transform;

        if(Random.Range(0,2) == 0)
        {
            isGood = true;
        }
        else
        {
            isGood = false;
        }

    }

    void Update()
    {
        Move();

        
    }

    void Move()
    {
        //move enemy to the left of the screen as soon as they spawn
        transform.position = Vector2.MoveTowards(transform.position, moveTarget.position, moveSpeed * Time.deltaTime);
    }

    public void ReachedTarget()
    {
        Debug.Log("Reached Target");
        Destroy(gameObject, 0.1f);
    }

    public void Stomped()
    {
        Debug.Log("Stomped");
        Destroy(gameObject/*, 0.1f*/);
    }

    float GetIdeologyLevel()
    {
        return ideologyLevel;
    }
}

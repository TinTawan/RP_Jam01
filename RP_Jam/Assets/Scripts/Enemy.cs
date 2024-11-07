using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] Transform moveTarget;


    // Start is called before the first frame update
    void Start()
    {

        //transform.position = new(12, -4);

        moveTarget = GameObject.FindGameObjectWithTag("EnemyTarget").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveTarget.position, moveSpeed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootScript : MonoBehaviour
{
    [SerializeField] float dropTime = 2f;

    [SerializeField] Vector2 dropPos;
    Vector2 startPos = new(-5, 0.2f);

    bool isStomping, isRising;

    float stompTimer = 0.5f, riseTimer = 0.5f;
    [SerializeField] float stompTime = 0.5f;

    BoxCollider2D bootCol;


    private void Start()
    {
        bootCol = GetComponent<BoxCollider2D>();

        stompTimer = stompTime;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isStomping && !isRising)
        {
            //Debug.Log("Stomp ");
            isStomping = true;

            
        }

        if(isStomping)
        {
            Stomp();
            
        }
        if (isRising)
        {
            Rise();
        }
    }


    void Stomp()
    {
        transform.position = Vector2.Lerp(transform.position, dropPos, dropTime * Time.deltaTime);

        stompTimer -= Time.deltaTime;
        if(stompTimer <= 0)
        {
            isRising = true;
            Rise();
            stompTimer = stompTime;
        }

        bootCol.enabled = true;
    }

    void Rise()
    {
        //Debug.Log("Rise");
        transform.position = Vector2.Lerp(transform.position, startPos, (dropTime * Time.deltaTime)/2f);
        isStomping = false;

        bootCol.enabled = false;

        riseTimer -= Time.deltaTime;
        if (riseTimer <= 0)
        {
            isRising = false;
            riseTimer = 0.5f;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            //Debug.Log("Stomp Enemy");

            Destroy(other.gameObject);
        }

    }

    

}

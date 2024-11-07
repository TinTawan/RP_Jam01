using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootScript : MonoBehaviour
{
    [SerializeField] float dropTime = 2f;

    [SerializeField] Vector2 dropPos;
    Vector2 startPos = new(-5, 0);

    [SerializeField] bool isStomping, isRising;

    [SerializeField] float stompTimer = 0.5f, riseTimer = 0.5f;

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
            stompTimer = 0.5f;
        }

    }

    void Rise()
    {
        //Debug.Log("Rise");
        transform.position = Vector2.Lerp(transform.position, startPos, (dropTime * Time.deltaTime)/2);
        isStomping = false;

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
            Debug.Log("Stomp Enemy");
        }
    }

}

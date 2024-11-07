using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootScript : MonoBehaviour
{
    [SerializeField] float dropTime = 2f;

    /*[SerializeField] */Vector2 dropPos;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //DropBoot();

            StartCoroutine(Stomp());
        }
    }

    void DropBoot()
    {
        dropPos = new(transform.position.x, transform.position.y - 2.5f);
        transform.position = Vector3.Lerp(transform.position, dropPos, dropTime * Time.deltaTime);
    }

    IEnumerator Stomp()
    {
        transform.position = Vector3.Lerp(transform.position, dropPos, dropTime * Time.deltaTime);


        yield return new WaitForSeconds(dropTime);
    }
}

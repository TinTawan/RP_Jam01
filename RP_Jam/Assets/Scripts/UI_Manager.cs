using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        arrow.transform.eulerAngles = Vector2.right;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

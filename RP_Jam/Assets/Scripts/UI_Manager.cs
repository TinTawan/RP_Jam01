using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] BootScript player;
    [SerializeField] GameObject arrow;
    [SerializeField] TextMeshProUGUI ideologyValText;

    [SerializeField][Range(-90 ,90)] float arrowPointAngle = 0;
    Vector3 arrowPoint;


    void Start()
    {
        
    }


    void Update()
    {
        RotateArrow(arrowPointAngle);
        ideologyValText.text = player.GetIdeologyVal().ToString();
    }

    void RotateArrow(float angle)
    {
        arrowPoint = new(0, 0, -angle);

        arrow.transform.eulerAngles = arrowPoint;
    }


}

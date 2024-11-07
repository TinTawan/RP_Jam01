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
        //RotateArrow(arrowPointAngle);
        RotateArrow(player.GetIdeologyVal());
        ideologyValText.text = player.GetIdeologyVal().ToString();
    }

    void RotateArrow(float angle)
    {
        arrowPoint = new(0, 0, -angle);

        arrow.transform.eulerAngles = arrowPoint;
    }

    float IdeologyLevelToAngle(float value, float min1, float max1, float min2, float max2)
    {
        return min2 + (value - min1) * (max2 - min2) / (max1 - min1);

    }


}

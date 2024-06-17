using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectTransformTest : MonoBehaviour
{
    [SerializeField]
    private RectTransform rectTransform;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            rectTransform.SetLeft(rectTransform.offsetMin.x + 100);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            rectTransform.SetRight(100);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            rectTransform.SetTop(100);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            rectTransform.SetBottom(100);
        }
    }
}

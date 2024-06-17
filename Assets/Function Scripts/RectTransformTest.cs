using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectTransformTest : MonoBehaviour
{
    [SerializeField]
    private RectTransform rectTransform;
    public void Start()
    {
        rectTransform.SetLeft(100);
    }    
}

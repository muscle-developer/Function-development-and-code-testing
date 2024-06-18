using UnityEngine;
using System.Collections.Generic;

// UI RectTransform을 쉽게 확장,축소 하기위한 스크립트
public static class RectTransformExtensions
{

    // private static Dictionary<RectTransform, RectTransformState> originalStates = new Dictionary<RectTransform, RectTransformState>();

    public static void SetLeft(this RectTransform rt, float left)
    {
        rt.offsetMin = new Vector2(left, rt.offsetMin.y);
    }

    public static void SetRight(this RectTransform rt, float right)
    {
        rt.offsetMax = new Vector2(-right, rt.offsetMax.y);
    }

    public static void SetTop(this RectTransform rt, float top)
    {
        rt.offsetMax = new Vector2(rt.offsetMax.x, -top);
    }

    public static void SetBottom(this RectTransform rt, float bottom)
    {
        rt.offsetMin = new Vector2(rt.offsetMin.x, bottom);
    }

    // 보류
    // public static void Reset(this RectTransform rt)
    // {
    //     if (originalStates.TryGetValue(rt, out RectTransformState state))
    //     {
    //         rt.offsetMin = state.OffsetMin;
    //         rt.offsetMax = state.OffsetMax;
    //         originalStates.Remove(rt);
    //     }
    // }

    // private static void SaveOriginalState(RectTransform rt)
    // {
    //     if (!originalStates.ContainsKey(rt))
    //     {
    //         originalStates[rt] = new RectTransformState(rt.offsetMin, rt.offsetMax);
    //     }
    // }

    // private struct RectTransformState
    // {
    //     public Vector2 OffsetMin { get; }
    //     public Vector2 OffsetMax { get; }

    //     public RectTransformState(Vector2 offsetMin, Vector2 offsetMax)
    //     {
    //         OffsetMin = offsetMin;
    //         OffsetMax = offsetMax;
    //     }
    // }
}


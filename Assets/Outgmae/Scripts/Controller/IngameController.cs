using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameController : MonoBehaviour
{
    public static IngameController Instance;

    [SerializeField]
    private UIViewPowerSaving uiViewPowerSaving;

    void Awake()
    {
        Instance = this;
    }

    private IEnumerator LogicOnEverySecondCoroutine()
    {
        var lastTime = (int)Time.realtimeSinceStartup;
        while(true)
        {
            var currentTime = (int)Time.realtimeSinceStartup;

            if(currentTime - lastTime >= 1)
            {
                // 절전모드가 실행중이라면
                if(uiViewPowerSaving.IsOn)
                {   
                    // 인게임 내에서 최소화 할것들 추가
                    // ex) 그래픽, 조명, 사운드 끄기 등...
                }

                lastTime = currentTime;
            }

            yield return null;
        }
    }
}

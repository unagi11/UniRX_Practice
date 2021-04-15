using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeCounterWithEvent : MonoBehaviour
{
    [SerializeField]
    public delegate void TimerEventHandler(int time);

    // 외부에서 이벤트를 등록해서 1초마다 실행시켜줍니다.
    [SerializeField]
    public event TimerEventHandler OnTimeChanged;


    private void Start()
    {
        StartCoroutine(TimeCoroutine());
    }

    private IEnumerator TimeCoroutine()
    {
        var time = 100;
        while (time > 0)
        {
            time--;

            // 100 부터 1초마다 1씩 줄이면서 계속해서 OnTimeChanged를 호출합니다.
            OnTimeChanged(time);

            yield return new WaitForSeconds(1);
        }
    }
}

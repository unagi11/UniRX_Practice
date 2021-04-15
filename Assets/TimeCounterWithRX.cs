using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class TimeCounterWithRX : MonoBehaviour
{
    private Subject<int> timerSubject = new Subject<int>();

    public IObservable<int> OnTimeChanged
    {
        get
        {
            return timerSubject;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimerCoroutine());
    }

    private IEnumerator TimerCoroutine()
    {
        var time = 100;
        while (time > 0)
        {
            time--;

            // 이벤트 발행 ******
            timerSubject.OnNext(time);

            yield return new WaitForSeconds(1);
        }
    }
}

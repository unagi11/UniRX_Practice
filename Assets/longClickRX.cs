using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

public class longClickRX : MonoBehaviour
{
    public Button button;

    private void Start()
    {
        button = GetComponent<Button>();

        var pointerDown = this.UpdateAsObservable()
            .Where(_ => Input.GetMouseButtonDown(0)); // 마우스가 눌려진것만 남긴다.

        var pointerUp = this.UpdateAsObservable()
            .Where(_ => Input.GetMouseButtonUp(0)); // 마우스가 눌려진것만 남긴다.

        pointerDown.SelectMany(_ => Observable.Timer(TimeSpan.FromSeconds(1))) // 스트림을 다른 스트림으로 교체한다.
            .TakeUntil(pointerUp) // pointer Up할때까지 한다. Up하면 OnComplete
            .RepeatUntilDestroy(gameObject) // OnComplete나면 다시 subscribe
            .Subscribe(_ => Debug.LogError("롱클릭" + _)); // 

        //observable.timer(timespan.fromseconds(1))
        //    .subscribe(a => debug.logerror(a), () => debug.logerror("컴플리트!"));

        button
            .OnPointerClickAsObservable()
            .Subscribe(
                a => Debug.LogError("버튼 클릭" + a)
            );


    }

}

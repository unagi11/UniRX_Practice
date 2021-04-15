using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UniRx.Examples
{
    public class Sample08_DetectDoubleClick : MonoBehaviour
    {
        void Start()
        {
            // Global event handling is very useful.
            // UniRx can handle there events.
            // Observable.EveryUpdate/EveryFixedUpdate/EveryEndOfFrame
            // Observable.EveryApplicationFocus/EveryApplicationPause
            // Observable.OnceApplicationQuit

            // This DoubleCLick Sample is from
            // The introduction to Reactive Programming you've been missing
            // https://gist.github.com/staltz/868e7e9bc2a7b8c1f754

            var clickStream = Observable.EveryUpdate() // 매 프레임마다의 스트림 생성
                .Where(_ => Input.GetMouseButtonDown(0)); // 마우스 오른쪽 버튼이 true일때로 제한

            clickStream.Buffer( // 스로틀 이벤트가 올때까지 이벤트를 모은다. (무시한다.)
                clickStream.Throttle(TimeSpan.FromMilliseconds(250)) // 250ms 동안 이벤트가 발생하지 않을때 통지한다.
                )
                .Where(xs => xs.Count >= 2)
                .Subscribe(xs => Debug.Log("DoubleClick Detected! Count:" + xs.Count));



        }
    }
}
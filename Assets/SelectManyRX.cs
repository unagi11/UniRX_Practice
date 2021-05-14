using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using System;

public class SelectManyRX : MonoBehaviour
{
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        /*
        button.OnPointerDownAsObservable()                  // 버튼을 눌렀을때 메시지가 오는 스트림
            .SelectMany(_ => button.UpdateAsObservable())   // 최초로 버튼을 눌렀을때, 매 프레임마다 메시지가 전달되는 스트림으로 변경
            .TakeUntil(button.OnPointerUpAsObservable())    // 이 스트림은 버튼을 떼는 순간 종료한다.
            .Subscribe(_ =>
            {
                Debug.Log("pressing...");
            },
            () =>
            {
                Debug.Log("completed");
            });
        */

        //마우스가 눌리고 5초안에 다시 누르지 않으면 작동하는 코드
        this.UpdateAsObservable()                       // 매 프레임 메시지가 오는 스트림
            .Where(_ => Input.GetMouseButtonDown(0))    // 마우스를 누른 프레임만 전달하도록 필터링
            .Throttle(TimeSpan.FromSeconds(5))          // 마우스를 뗀후로부터 5초 안에 새로운 메시지가 안오면 마지막 메시지 전달
            .Subscribe(_ => Debug.Log("5초가 지났습니다."));

        //마우스가 눌리고 100프레임 안에 다시 누르지 않으면 작동하는 코드
        this.UpdateAsObservable()                       // 매 프레임 메시지가 오는 스트림
            .Where(_ => Input.GetMouseButtonDown(0))    // 마우스를 누른 프레임만 전달하도록 필터링
            .ThrottleFrame(100)                         // 마우스를 뗀후로부터 100프레임 안에 새로운 메시지가 안오면 마지막 메시지 전달
            .Subscribe(_ => Debug.Log("100프레임이 지났습니다."));

    }

}

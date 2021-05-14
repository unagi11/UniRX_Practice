using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class ButtonClickRX : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Text text;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick // Unity가 제공하는 클릭 이벤트
            .AsObservable() // 클릭 이벤트를 Observable로 변경한다.
            .Buffer(3)
            .Subscribe(_ => // OnNext 메시지가 왔을때 동작을 정의한다.
            {
                text.text = "Clicked";
            });


        button.onClick // Unity가 제공하는 클릭 이벤트
            .AsObservable() // 클릭 이벤트를 Observable로 변경한다.
            .Subscribe(_ => 
            {
                // OnNext 메시지가 왔을때 동작을 정의한다.
                text.text = "Clicked";
            }, err =>
            {
                // OnError 메시지가 왔을때 동작을 정의한다.
                text.text = "Error Occur";
            }, () =>
            {
                // OnCompleted 메시지가 왔을때 동작을 정의한다.
                text.text = "Completed";
            });
    }
}

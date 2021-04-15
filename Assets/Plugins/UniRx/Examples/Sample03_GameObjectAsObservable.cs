#if !(UNITY_IPHONE || UNITY_ANDROID || UNITY_METRO)

using UnityEngine;
using UniRx.Triggers; // for enable gameObject.EventAsObservbale()

namespace UniRx.Examples
{
    public class Sample03_GameObjectAsObservable : MonoBehaviour
    {

        void Start()
        {
            // All events can subscribe by ***AsObservable if enables UniRx.Triggers
            this.OnMouseDownAsObservable()
                .SelectMany(_ => this.gameObject.UpdateAsObservable()) // 매 프레임 업데이트를 하는 새로운 스트림을 생성하고, 그 스트림이 흐르는 메시지를 본래의 스트림 메시지로 취급
                .TakeUntil(this.gameObject.OnMouseUpAsObservable()) // (마우스가 올라가는) 지정한 스트림에 메시지가 오면, 자신의 스트림에 OnCompleted를 보내서 종료한다.
                .Select(_ => Input.mousePosition) // 요소의 값을 (마우스 위치로) 변경한다.
                .RepeatUntilDestroy(this) // 오브젝트가 Destory 될때까지 반복한다.
                .Subscribe(x => Debug.Log(x), ()=> Debug.Log("!!!" + "complete"));// OnNext, OnComplete
        }
    }
}

#endif
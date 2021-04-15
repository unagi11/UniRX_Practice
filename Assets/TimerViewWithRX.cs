using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;

public class TimerViewWithRX : MonoBehaviour
{

    [SerializeField] private TimeCounterWithRX timeCounterWithRX;
    [SerializeField] private TextMeshProUGUI TextMeshProUGUI;

    // Start is called before the first frame update
    void Start()
    {
        // 이벤트 대신에 쓸수있다. 타이밍 조작도 가능
        timeCounterWithRX
            .OnTimeChanged
            .Subscribe(asdf =>
        {
            TextMeshProUGUI.text = asdf.ToString();
        });


    }
}

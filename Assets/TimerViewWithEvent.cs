using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerViewWithEvent : MonoBehaviour
{

    [SerializeField] private TimeCounterWithEvent timeCounterWithEvent;
    [SerializeField] private TextMeshProUGUI TextMeshProUGUI;

    // Start is called before the first frame update
    void Start()
    {
        // 람다함수로 Event 등록함
        timeCounterWithEvent.OnTimeChanged += time =>
        {
            TextMeshProUGUI.text = time.ToString();
        };
    }

}

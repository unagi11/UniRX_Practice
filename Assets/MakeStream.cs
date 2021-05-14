using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System.Timers;

public class MakeStream : MonoBehaviour
{
    public int a = 10;

    public double t = 10;

    public ReactiveProperty<int> b = new ReactiveProperty<int>();

    // Start is called before the first frame update
    void Start()
    {

        b.Value = 10;
        b.Subscribe(b => Debug.LogError(b));

        this.ObserveEveryValueChanged(_ => a)
            .Subscribe(a => Debug.LogError(a));

    }

    // Update is called once per frame
    void Update()
    {

    }
}

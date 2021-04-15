using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;
using UnityEngine.UI;

public class ZipTest : MonoBehaviour
{
    public Image Aim, Sim, ASim;

    // Start is called before the first frame update
    void Start()
    {
        /*
        Observable.EveryUpdate().Where(_ => Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
            .Select(a => true)
            .First()
            .Subscribe(asdf =>
            {
                Debug.Log(asdf);
            }
            , 
            () =>
            {
                Debug.Log("OnComplete!");
            });
        */

        var A_KeyStream = Observable.EveryUpdate()
            .Select(_ => Input.GetKey(KeyCode.A));
        var S_KeyStream = Observable.EveryUpdate()
            .Select(_ => Input.GetKey(KeyCode.S));

        A_KeyStream.Subscribe(_ =>
        {
            if (_ == true)
                Aim.color = Color.red;
            else
                Aim.color = Color.white;
        });
        S_KeyStream.Subscribe(_ =>
        {
            if (_ == true)
                Sim.color = Color.red;
            else
                Sim.color = Color.white;
        });

        var cc = A_KeyStream.Zip(S_KeyStream, (a, s) => a && s)
            .Subscribe(_ =>
            {
                if (_ == true)
                    ASim.color = Color.red;
                else
                    ASim.color = Color.white;
            }
            );
        
                
//            .Where(x => x == true)


    }

}

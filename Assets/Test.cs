using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UniRx;

public class Test : MonoBehaviour
{
    public Text text;
    public Button button;
    public Button button1;
    public Button button2;


    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        text = GetComponentInChildren<Text>(); 
        button.onClick.AsObservable() // 스트림을 생성한다.
            .Buffer(3)
            .Subscribe(_ =>
           {
               Debug.Log("Clicked 3 times!");
           });

        button.OnClickAsObservable().SubscribeToText(text, _ => "i am inja");

        button.OnClickAsObservable()
            .Zip(button1.OnClickAsObservable(), (a,b) => "여긴 뭘까")
            .Subscribe(x =>
            {
                Debug.Log("hummm.." + x);
                
            });

//        button.onClick.subsc
        
    }

}

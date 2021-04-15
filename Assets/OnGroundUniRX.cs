using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class OnGroundUniRX : MonoBehaviour
{
    public bool isGournd;

    // Start is called before the first frame update
    void Start()
    {
        var characterController = GetComponent<CharacterController>();
        var particleSystem = GetComponentInChildren<ParticleSystem>();

        characterController                                 // 캐릭터 컨트롤러의
            .ObserveEveryValueChanged(x => x.isGrounded)    // x.isGrounded를 Observe
            .DistinctUntilChanged()                         // 변화 있을때 stream
            .ThrottleFrame(3)                               // 변화후 3프레임동안 변화가 없으면
            .Subscribe(x => {
                isGournd = x;                               // 값을 받아서 
                if (isGournd)                               // true면 땅되고나서 3프레임동안 변화가 없다는 뜻
                    particleSystem.Play();
            });
    }

    /*
    private void Update()
    {
        Debug.LogError(isGournd);
    }
    */

}
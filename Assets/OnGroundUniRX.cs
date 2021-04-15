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

        characterController
            .ObserveEveryValueChanged(x => x.isGrounded)
            .DistinctUntilChanged()
            .ThrottleFrame(5)
            .Subscribe(x => { isGournd = x; if (isGournd) particleSystem.Play(); });
    }

    private void Update()
    {
        Debug.LogError(isGournd);
    }

}
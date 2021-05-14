using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGroundDefault : MonoBehaviour
{
    public CharacterController characterController;
    public new ParticleSystem particleSystem;

    // 이전 상태를 기록하기 위한 변수
    public bool oldFlag; 

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        oldFlag = characterController.isGrounded;
    }

    // Update is called once per frame
    void Update()
    {
        bool currentFlag = characterController.isGrounded;

        if (currentFlag && !oldFlag)
            particleSystem.Play();

        oldFlag = currentFlag;

        // 뭘 하는지 알기 힘들다..
    }
}

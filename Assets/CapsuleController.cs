using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleController : MonoBehaviour
{
    public CharacterController characterController;
    public float jumpForce = 10f;
    public float gravity = 0.1f;
    public float moveSpeed = 10f;
    public Vector3 vector3;
    
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.LogError(characterController.isGrounded);

        // 이걸 사용하면 계속해서 떠있을수 있다.
        //if (characterController.isGrounded)

        if (GetComponent<OnGroundUniRX>().isActiveAndEnabled && GetComponent<OnGroundUniRX>().isGournd) // 5프레임마다 마지막 변화를 값으로 가진다.
        {
            // 계속땅에 붙어있도록 vector3.y 유지 (중력)
            vector3 = new Vector3(Input.GetAxis("Horizontal"), -1, Input.GetAxis("Vertical"));

            if (Input.GetKey(KeyCode.Space))
                vector3.y = jumpForce;
        }
        else if (GetComponent<OnGroundDefault>().isActiveAndEnabled && characterController.isGrounded)
        {
            // 계속땅에 붙어있도록 vector3.y 유지 (중력)
            vector3 = new Vector3(Input.GetAxis("Horizontal"), -1, Input.GetAxis("Vertical"));

            if (Input.GetKey(KeyCode.Space))
                vector3.y = jumpForce;
        }

        // 떠있으면
        vector3.y -= gravity; // 계속해서 무거워진다.

        characterController.Move(vector3 * Time.deltaTime * moveSpeed);
    }
}

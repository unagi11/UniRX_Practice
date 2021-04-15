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

        if (characterController.isGrounded)
            vector3 = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (GetComponent<OnGroundUniRX>().isGournd) // 5프레임마다 마지막 변화를 값으로 가진다.
        {
            if (Input.GetKey(KeyCode.Space))
                vector3.y = jumpForce;
        }

        vector3.y -= gravity;
        characterController.Move(vector3 * Time.deltaTime * moveSpeed);
    }
}

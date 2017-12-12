using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject Player;
    public GameObject MainCamera;

    [SerializeField] private int moveSpeed = 5;
    [SerializeField] private int sensitivity = 5;
    [SerializeField] private int gravity = 10;

    private int sprintSpeed = 1;
    private int jumpSpeed = 5;
    private int rotateMin = -15;
    private int rotateMax = 50;

    private Vector3 moveDir = Vector3.zero;
    private Vector3 v3Rotate = Vector3.zero;

    void Start ()
    {
        MainCamera.transform.localEulerAngles = v3Rotate;
        Cursor.visible = false;
	}
	

	void Update ()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            sprintSpeed = 2;
        }
        else
        {
            sprintSpeed = 1;
        }

        CharacterController controller = GetComponent<CharacterController>();
        if(controller.isGrounded)
        {
            moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            moveDir = transform.TransformDirection(moveDir);
            moveDir *= moveSpeed;
            if(Input.GetButtonDown("Jump"))
            {
                moveDir.y = jumpSpeed;
            }
        }
        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime * sprintSpeed);


        v3Rotate.x += -Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivity;
        v3Rotate.x = Mathf.Clamp(v3Rotate.x, rotateMin, rotateMax);
        MainCamera.transform.localEulerAngles = v3Rotate;

        //transform.Translate(Input.GetAxisRaw("Horizontal")*Time.deltaTime*moveSpeed, 0f,Input.GetAxisRaw("Vertical")*Time.deltaTime*moveSpeed);
        transform.Rotate(0f, Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivity, 0f);
        //MainCamera.transform.Rotate(-Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivity, 0f, 0f);
    }
}

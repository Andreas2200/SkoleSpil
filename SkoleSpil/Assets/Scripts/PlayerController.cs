using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject Player;
    public GameObject MainCamera;

    [SerializeField] private int moveSpeed = 5;
   //[SerializeField] private int rotateSpeed = 5;

    void Start ()
    {
        Cursor.visible = false;
	}
	

	void Update ()
    {
        transform.Translate(Input.GetAxisRaw("Horizontal")*Time.deltaTime*moveSpeed, 0f,Input.GetAxisRaw("Vertical")*Time.deltaTime*moveSpeed);
        //MainCamera.transform.Rotate(Input.GetAxisRaw("Mouse X") * Time.deltaTime * rotateSpeed, Input.GetAxisRaw("Mouse X") * Time.deltaTime * rotateSpeed, 0f);
    }
}

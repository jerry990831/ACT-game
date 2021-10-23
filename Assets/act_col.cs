using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class act_col : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dog;
    public player input;
    private Animator act;
    public float speed = 0.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;


    void Start()
    {
        input = GetComponent<player>();
        act = dog.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        GameObject camera1 = GameObject.Find("Main Camera");
        Vector3 Camera_r = camera1.transform.right;
        Camera_r.y=0;
        Vector3 Camera_f = camera1.transform.forward;
        Camera_f.y=0;
        Debug.Log(input.rightorleft*Camera_r+input.upordown*Camera_f);
        act.SetFloat("forwards",Mathf.Sqrt((input.upordown*input.upordown)+(input.rightorleft*input.rightorleft)));
        if((input.upordown*input.upordown)+(input.rightorleft*input.rightorleft)>0.1f){
            dog.transform.forward = input.rightorleft*Camera_r+input.upordown*Camera_f;
        }
        if((input.upordown*input.upordown)+input.rightorleft*input.rightorleft>0.10f)
        {
            speed =2.0f;
        }
        else{
            speed =0;
        }
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded) {
            moveDirection = dog.transform.forward;
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        }
        
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    
    
}

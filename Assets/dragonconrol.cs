using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonconrol : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator dragonact;
    public GameObject dragon;
    public float dragonspeed = 0.0F;
    private float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    void Start()
    {
        dragonact = dragon.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Playerhandle");
        if(Vector3.Distance(player.transform.position,this.transform.position)<20){
            dragonact.SetTrigger("wake");
        }
        CharacterController controller = GetComponent<CharacterController>();
        
        if (controller.isGrounded) {
            moveDirection = dragon.transform.forward;
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= dragonspeed;
        }
        
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        
    }
}

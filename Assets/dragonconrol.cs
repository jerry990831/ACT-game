using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonconrol : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator dragonact;
    public GameObject dragon;

    void Start()
    {
        dragonact = dragon.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Playerhandle");
        Debug.Log(Vector3.Distance(player.transform.position,this.transform.position));
        if(Vector3.Distance(player.transform.position,this.transform.position)<20){
            dragonact.SetTrigger("wake");
        }
    }
}

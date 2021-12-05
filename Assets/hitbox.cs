using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitbox : MonoBehaviour
{
    public GameObject damageTarget; 
    public GameObject drangonhandle;
    public dragonconrol dragonCont; 

    // Start is called before the first frame update
    void Start()
    {
        damageTarget = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(!dragonCont.damagefeature && damageTarget!=null)
            damageTarget = null;
    }
    void OnTriggerEnter(Collider other){
        Debug.Log(other.gameObject.name);
        if(other.gameObject.name == "Playerhandle"){
            damageTarget = other.gameObject;
        }
    }
}

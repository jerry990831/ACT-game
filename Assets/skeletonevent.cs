using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skeletonevent : MonoBehaviour
{
    // Start is called before the first frame update
    public Image talking;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.name == "Playerhandle"){
            talking.gameObject.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
            this.gameObject.SetActive(false);
        }
    }
}

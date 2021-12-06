using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dungeonevent : MonoBehaviour
{
    // Start is called before the first frame update
    public Image talking;
    public Text text;

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
            text.text = "there are more skeletons in the room. they are moving!";
            Time.timeScale = 0;
            Cursor.visible = true;
            this.gameObject.SetActive(false);
        }
    }
}

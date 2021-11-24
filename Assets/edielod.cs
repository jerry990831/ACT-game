using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class edielod : MonoBehaviour
{
    private Transform[] allChildren;
    private List<GameObject> childObjects;
    // Start is called before the first frame update
    void Start()
    {
        allChildren = GetComponentsInChildren<Transform>();
        childObjects = new List<GameObject>();
        foreach (Transform child in allChildren)
        { 
            childObjects.Add(child.gameObject);
        }
        foreach(var child in childObjects){
            LODGroup lod = child.GetComponent<LODGroup>();
            if(lod != null){
                lod.enabled = false;
            }
            string key1 = "lod1";
            string key2 = "lod2";
            string key3 = "lod3";
            if(child.transform.name.ToLower().Contains(key1.ToLower()) ||
            child.transform.name.ToLower().Contains(key2.ToLower()) ||
            child.transform.name.ToLower().Contains(key3.ToLower())){
                Object.Destroy(child);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}

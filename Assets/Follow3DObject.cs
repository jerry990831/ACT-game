using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow3DObject : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public Vector3 offset = new Vector3(0, 1, 0);
    public Camera Camera;
    // Use this for initialization
    void Start()
    {
 
    }
 
    // Update is called once per frame
    void Update()
    {

            transform.rotation = Camera.main.transform.rotation;
       
    }
    }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTurbine : MonoBehaviour
{
    [SerializeField]
    private float rotaionSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0, rotaionSpeed, 0);
        
        transform.RotateAround( transform.localPosition,Vector3.right, rotaionSpeed *Time.deltaTime);
    }
}

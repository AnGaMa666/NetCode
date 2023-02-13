using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class SimpleMoveToMousePosition : NetworkBehaviour
{
    CharacterController controller;
    Vector3 mousePos;
    [SerializeField]
    float speed = 5f;
    float gOMiddle;
    void Start()
    {
        mousePos = Vector3.zero; //initial value       
        controller = GetComponent<CharacterController>();
        gOMiddle = GetComponent<MeshRenderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos = new Vector3(mousePos.x, gOMiddle, mousePos.z);

            transform.LookAt(mousePos);

            controller.Move(transform.forward * speed * Time.deltaTime);
        }
    }


    public override void OnNetworkSpawn()
    {
        if (!IsOwner) this.enabled = false;
    }
}

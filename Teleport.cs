using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] GameObject targetLocation;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var charContrl = other.GetComponent<CharacterController>();

            charContrl.enabled = false;
            other.gameObject.transform.position = targetLocation.transform.position;
            charContrl.enabled = true;

        }
    }
}

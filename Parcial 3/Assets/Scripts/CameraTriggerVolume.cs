using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(BoxCollider))]

public class CamTrigger : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cam;
    [SerializeField] private Vector3 boxSize;

    BoxCollider box;

    private void Awake()
    {
        box = GetComponent<BoxCollider>();
        box.isTrigger = true; // Ensure this is set as a trigger
        box.size = boxSize;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, boxSize);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the other collider belongs to the player
        if (other.CompareTag("Player"))
        {if (CameraSwitcher.ActiveCamera != cam)
                {
                    CameraSwitcher.SwitchCamera(cam);
                }
            }
        
    }
}
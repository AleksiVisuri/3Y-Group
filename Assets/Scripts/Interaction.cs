using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private LayerMask interactLayer;
    //public float radius;
    public GameObject InteractUI;
    private bool isInteractable = false;
    private bool isInteracting = false;

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && isInteractable == true)
        {
            if(isInteracting == false)
            {
                /*Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, interactLayer);
                foreach (var hitCollider in hitColliders)
                {
                    IInteraction interaction = hitCollider.GetComponent<IInteraction>();
                    if (interaction != null)   
                    {
                        interaction.Interact();
                        isInteracting = true;
                    }
                }*/

                IInteraction interaction = other.GetComponent<IInteraction>();
                if (interaction != null)
                {
                    interaction.Interact();
                    isInteracting = true;
                    InteractUI.gameObject.SetActive(false);
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            isInteracting = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((interactLayer & (1 << other.gameObject.layer)) != 0)
        {
            InteractUI.gameObject.SetActive(true);
            isInteractable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((interactLayer & (1 << other.gameObject.layer)) != 0)
        {
            InteractUI.gameObject.SetActive(false);
            isInteractable = false;
        }
    }
}

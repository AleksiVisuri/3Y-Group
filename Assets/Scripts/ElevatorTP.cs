using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ElevatorTP : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] GameObject playerTransform;

    [Header("Animators")]
    [SerializeField] Animator upperFloorAnimator;
    [SerializeField] Animator currentFloorAnimator;

    [Header("Teleportation")]
    [SerializeField] float tpHeight;
    [SerializeField] float tpWaitTime = 2.5f;

    [Header("Enemy")]
    [SerializeField] private GameObject upperFloorEnemy;
    [SerializeField] private GameObject currentFloorEnemy;

    [Header("Objective")]
    [SerializeField] private TextMeshProUGUI ObjectiveUI;
    [SerializeField] private GameObject finalEnemy;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        StartCoroutine(TPWaitTime());
    }

    private IEnumerator TPWaitTime()
    {
        currentFloorAnimator.SetTrigger("Close");

        if (upperFloorEnemy != null)
            upperFloorEnemy.SetActive(true);

        yield return new WaitForSeconds(tpWaitTime);
        Debug.Log("TPWaitTime Aloitettu");
        ObjectiveUI.SetText("Find the Code");

        playerTransform.transform.position = new Vector3(playerTransform.transform.position.x, tpHeight, playerTransform.transform.position.z);

        Physics.SyncTransforms();

        upperFloorAnimator.SetTrigger("Open");

        if (currentFloorEnemy != null)
            currentFloorEnemy.SetActive(false);

        if (finalEnemy != null)
            ObjectiveUI.SetText("You'll never truly escape!");
    }
}

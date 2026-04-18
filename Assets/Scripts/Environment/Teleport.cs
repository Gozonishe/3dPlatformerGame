using UnityEngine;

public class Teleport : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("The destination teleporter that the player will be teleported to.")]
    public Teleport destinationTeleporter;
    public GameObject teleportEffect;

    private bool isTeleportAvailable = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isTeleportAvailable && destinationTeleporter != null)
        {
            if (teleportEffect != null)
            {
                Instantiate(teleportEffect, transform.position, transform.rotation, null);
            }

            CharacterController characterController = other.GetComponent<CharacterController>();
            if (characterController != null)
            {
                characterController.enabled = false;
            }

            float heightOffset = transform.position.y - other.transform.position.y;

            other.transform.position = destinationTeleporter.transform.position - new Vector3(0, heightOffset, 0);

            destinationTeleporter.isTeleportAvailable = false;

            if (characterController != null)
            {
                characterController.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTeleportAvailable = true;
        }
    }
}

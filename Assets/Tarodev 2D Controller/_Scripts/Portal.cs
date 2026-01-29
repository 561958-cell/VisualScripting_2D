using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Portal : MonoBehaviour
{
    [SerializeField] private Transform destination;
    [SerializeField] private float teleportCooldown = 0.5f;
    [SerializeField] private AudioClip teleportClip;
    private float lastTeleportTime;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Time.time > lastTeleportTime)
        {
            Teleport(other.transform);
        }
    }

    public void Teleport(Transform playerTransform)
    {
        if (destination == null) return;

        Portal destPortal = destination.GetComponent<Portal>();
        if (destPortal != null)
        {
            destPortal.lastTeleportTime = Time.time + teleportCooldown;
        }

        // Play sound
        if (teleportClip != null)
        {
            audioSource.PlayOneShot(teleportClip);
        }

        playerTransform.position = destination.position;
    }
}
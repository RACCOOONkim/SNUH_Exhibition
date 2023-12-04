using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    public GameObject object3;
    public AudioClip collisionSound;

    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == object3)
        {
            PlayCollisionSound();
        }
    }

    private void PlayCollisionSound()
    {
        audioSource.PlayOneShot(collisionSound);
    }
}

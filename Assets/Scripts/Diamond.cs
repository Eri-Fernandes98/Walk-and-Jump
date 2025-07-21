using UnityEngine;

public class Diamond : MonoBehaviour
{
    private GameObject diamondAudio;

    void Start()
    {
        
        diamondAudio = GameObject.Find("DiamondAudio");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            if (diamondAudio != null)
            {
                AudioSource audioSource = diamondAudio.GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    audioSource.Play();
                }
            }

            GameManager.score += 1;
            Destroy(gameObject);
        }
    }
}

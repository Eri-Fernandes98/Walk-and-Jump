using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathArea : MonoBehaviour
{
    private AudioSource deathAudioSource;

    void Start()
    {
        
        GameObject audioObject = GameObject.Find("DeathAudio");
        if (audioObject != null)
        {
            deathAudioSource = audioObject.GetComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (deathAudioSource != null)
            {
                deathAudioSource.Play();
                
                StartCoroutine(ReloadSceneAfterSound(deathAudioSource.clip.length));
            }
            else
            {
                ReloadScene();
            }
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameManager.score = 0;
    }

    private System.Collections.IEnumerator ReloadSceneAfterSound(float delay)
    {
        yield return new WaitForSeconds(delay);
        ReloadScene();
    }
}

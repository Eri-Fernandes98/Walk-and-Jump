using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    SpriteRenderer Pl;
    Animator an;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Pl = GetComponent<SpriteRenderer>();
        an = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movimento = new Vector3(
            Input.GetAxis("Horizontal") * 4,
            Input.GetAxis("Vertical") * 8,
            0f
        );
        transform.position += movimento * Time.deltaTime * 5;

        if (Input.GetAxis("Horizontal") > 0) {
            Pl.flipX = false;
            an.SetBool("andando", true);
        }else if (Input.GetAxis("Horizontal") < 0)
        {
            Pl.flipX = true;
            an.SetBool("andando", true);

        }
        else
        {
            an.SetBool("andando", false);
        }
                      
    }
        void OnTriggerStay2D(Collider2D collider)
    {
        SceneManager.LoadScene("Tela2");
    }
}

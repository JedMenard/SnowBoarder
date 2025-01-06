using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField]
    private float ReloadDelay = 2f;

    [SerializeField]
    private ParticleSystem FinishEffect;

    private PlayerController player => FindObjectOfType<PlayerController>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && this.player.IsPlaying())
        {
            this.FinishEffect.Play();
            this.GetComponent<AudioSource>().Play();
            Invoke("Reload", this.ReloadDelay);
            this.player.SetPlayState(false);
        }
    }

    private void Reload()
    {
        SceneManager.LoadScene("Level1");
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField]
    private float ReloadDelay = 05f;

    [SerializeField]
    private ParticleSystem CrashEffect;

    [SerializeField]
    private AudioClip CrashSFX;

    private PlayerController player => FindObjectOfType<PlayerController>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" && this.player.IsPlaying())
        {
            this.CrashEffect.Play();
            this.GetComponent<AudioSource>().PlayOneShot(this.CrashSFX);
            FindObjectOfType<PlayerController>().DisableMovement();
            Invoke("Reload", this.ReloadDelay);
            this.player.SetPlayState(false);
        }
    }

    private void Reload()
    {
        SceneManager.LoadScene("Level1");
    }
}

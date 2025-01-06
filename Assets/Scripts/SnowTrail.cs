using UnityEngine;

public class SnowTrail : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem snowTrailEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag  == "Ground")
        {
            this.snowTrailEffect.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag  == "Ground")
        {
            this.snowTrailEffect.Stop();
        }
    }
}

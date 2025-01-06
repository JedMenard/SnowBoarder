using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float torqueAmount = 1;

    [SerializeField]
    private float boostSpeed = 20;

    [SerializeField]
    private float baseSpeed = 12;

    private Rigidbody2D rigidBody;
    private SurfaceEffector2D surfaceEffector;

    private bool isBoosting;
    private bool canMove = true;
    private bool isPlaying = true;

    // Start is called before the first frame update
    private void Start()
    {
        this.rigidBody = this.GetComponent<Rigidbody2D>();
        this.surfaceEffector = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (this.canMove){
            this.Rotate();
            this.Boost();
        }
    }

    private void Rotate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.rigidBody.AddTorque(this.torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            this.rigidBody.AddTorque(-this.torqueAmount);
        }
    }

    private void Boost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (!this.isBoosting)
            {
                this.surfaceEffector.speed = this.boostSpeed;
                this.isBoosting = true;
            }
        }
        else
        {
            if (this.isBoosting)
            {
                this.surfaceEffector.speed = this.baseSpeed;
                this.isBoosting = false;
            }
        }

    }

    public void DisableMovement() => this.canMove = false;

    public void SetPlayState(bool playState) => this.isPlaying = playState;

    public bool IsPlaying() => this.isPlaying;
}

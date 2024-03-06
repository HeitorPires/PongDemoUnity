using UnityEngine;

public class BallController : MonoBehaviour
{

    private Rigidbody2D rb;
    private CircleCollider2D circleCollider;
    public Vector2 startingVelocity = new Vector2(-5f, 5f);

    public GameManager gameManager;

    public float speedUp = 1.1f;


    public Vector3 startingScale = new Vector3(3f, 3f, 1f);
    public float startingRadius = .1f;
    public float radiusDecressValue = .1f;
    public float scaleDecressValue = .1f;

    public AudioClip ballSound;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider = rb.GetComponent<CircleCollider2D>();
    }

    public void ResetBall()
    {
        transform.position = Vector3.zero;
        rb.velocity = startingVelocity;
        transform.localScale = startingScale;
        circleCollider.radius = startingRadius;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector2 newVelocity = rb.velocity;
            newVelocity.y = -newVelocity.y;
            rb.velocity = newVelocity;
            AudioManager.Instance.PlayAudio(ballSound);
        }

        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
            rb.velocity *= speedUp;

            circleCollider.radius -= radiusDecressValue;
            Vector3 targetScale = new Vector3(transform.localScale.x - scaleDecressValue, transform.localScale.y - scaleDecressValue, transform.localScale.z);
            transform.localScale = targetScale;
            AudioManager.Instance.PlayAudio(ballSound);
        }

        if (collision.gameObject.CompareTag("WallEnemy"))
        {
            gameManager.ScorePlayer();
            ResetBall();
        }
        if (collision.gameObject.CompareTag("WallPlayer"))
        {
            gameManager.ScoreEnemy();
            ResetBall();
        }
    }
}

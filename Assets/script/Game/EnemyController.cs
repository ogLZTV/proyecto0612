using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D _componentRigidbody2D;
    private Vector2 positionInitial;
    private Transform positionPlayer;

    public float speed;

    private void Awake()
    {
        _componentRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        positionInitial = transform.position;
    }

    private void Update()
    {
        if (positionPlayer != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, positionPlayer.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, positionInitial, speed * Time.deltaTime);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            positionPlayer = null;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            positionPlayer = collision.transform; 
        }
    }
}

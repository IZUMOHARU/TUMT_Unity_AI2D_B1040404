using UnityEngine;

public class moster : MonoBehaviour
{
[Header("速度"), Range(0, 50)]
public float speed = 1.5f;
[Header("傷害"), Range(0, 100)]
public float damage = -20;

private Rigidbody2D r2d;
public Transform checkPoint;

    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(checkPoint.position, -checkPoint.up * 3);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "player")
        {
            Track(collision.transform.position);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player" && collision.transform.position.y < transform.position.y + 1)
        {
            collision.gameObject.GetComponent<HITO>().Damage(damage);
        }
    }

void Move()
{
    r2d.AddForce(-transform.right * speed);

    RaycastHit2D hit = Physics2D.Raycast(checkPoint.position, -checkPoint.up, 1.5f, 1 << 8);

    if (hit == false)
    {
        transform.eulerAngles += new Vector3(0,0 ,180 );
    }
}

void Track(Vector3 target)
{
    if (target.y < transform.position.y)
    {
        transform.eulerAngles = Vector3.zero;
    }
    else
    {
        transform.eulerAngles = new Vector3(0, 0, 180);
    }
}
}
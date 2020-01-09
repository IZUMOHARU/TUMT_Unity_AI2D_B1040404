using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HITO : MonoBehaviour
{
    public int speed = 10;
    public float jump = 2.5f;
    public string NAME = "HITO";
    public bool pass = false;

    public UnityEvent onEat;
    public float hp = 5;
    public GameObject[] Image;
    public GameObject final;
    public int Coin = 1;

    private Rigidbody2D r2d;
    private Animator ani;
    private Transform tran;
    private bool isGround;
    private float hpMax;

    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        tran = GetComponent<Transform>();
        hpMax = hp;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Walk();
        Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) Turn();
        if (Input.GetKeyDown(KeyCode.A)) Turn(180);
        if (this.transform.position.y <= -6)
        {
            final.SetActive(true);
        }

    }
    private void Walk()
    {
        r2d.AddForce(new Vector2(speed * Input.GetAxisRaw("Horizontal"), 0));
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            r2d.AddForce(new Vector2(0, jump * Input.GetAxis("Jump")));
        }
    }
    private void Turn(int direction = 0)
    {
        transform.eulerAngles = new Vector3(0, direction, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            Destroy(collision.gameObject);
            onEat.Invoke();

        }
    }
    public void Damage(float damage)
    {
        hp -= damage;

        if (hp == 2)
        {
            Destroy(Image[2].gameObject);
        }
        if (hp == 1)
        {
            Destroy(Image[1].gameObject);
        }
        if (hp <= 0)
        {

        }

        if (hp <= 0) final.SetActive(true);
    }
}
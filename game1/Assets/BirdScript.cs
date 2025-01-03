using Unity.VisualScripting;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float flapStrength;
    public LogicManager logic;
    public bool isAlive = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.name = "Bob The Bird";
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        moveUP();
    }

    void moveUP()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isAlive )
        {
            rb.linearVelocity =  Vector2.up * flapStrength;
        }
    }

    
    void OnCollisionEnter2D(Collision2D other)
    {
        logic.gameOver();
        isAlive = false;
    }
}

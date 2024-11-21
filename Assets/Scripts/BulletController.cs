using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody2D myrigidbody2D;
    public float bulletSpeed = 10f;
    public GameManager myGameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
{
    myrigidbody2D = GetComponent<Rigidbody2D>();
    if (myrigidbody2D == null)
    {
        Debug.LogError("No se encontró Rigidbody2D en el objeto.");
    }

    myGameManager = Object.FindFirstObjectByType<GameManager>();
    if (myGameManager == null)
    {
        Debug.LogError("No se encontró GameManager en la escena.");
    }
}


    // Update is called once per frame
    void Update()
    {
        myrigidbody2D.linearVelocity = new Vector2(bulletSpeed,myrigidbody2D.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("itemGood")) 
    {
        Destroy(collision.gameObject);
    }
    else if (collision.gameObject.CompareTag("itemBad"))
    {
        myGameManager.AddScore();
        Destroy(collision.gameObject);
    }
}


}

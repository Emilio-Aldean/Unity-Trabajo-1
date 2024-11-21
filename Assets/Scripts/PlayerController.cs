using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{
    
    public float playerJumpForce = 20f;
    public float playerSpeed = 5f;
    public Sprite[] mySprites;
    private int index =0;

    private Rigidbody2D myrigidbody2D;
    private SpriteRenderer mySpriteRenderer;
    public GameObject Bullet;
    private GameObject gameManagerObject;
    public GameManager myGameManager;

    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WalkCoRoutine());

        gameManagerObject = GameObject.FindWithTag("GameController");
        if (gameManagerObject == null)
        {
            Debug.LogError("No se encontró un objeto con el tag 'GameController' en la escena.");
            return;
        }
        
        myGameManager = gameManagerObject.GetComponent<GameManager>();
        if (myGameManager == null)
        {
            Debug.LogError("No se encontró el componente GameManager en el GameController.");
        }
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            myrigidbody2D.linearVelocity = new Vector2(myrigidbody2D.linearVelocity.x,playerJumpForce);
        }
        myrigidbody2D.linearVelocity = new Vector2(playerSpeed, myrigidbody2D.linearVelocity.y);
        
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);
        }
    }

    IEnumerator WalkCoRoutine() {
    while (true) { 
        yield return new WaitForSeconds(0.05f);
        mySpriteRenderer.sprite = mySprites[index];
        index = (index + 1) % mySprites.Length; 
    }
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        Debug.Log(collision.gameObject.tag); 
        if (collision.gameObject.CompareTag("itemGood")) 
        {
            Debug.Log("Recogió moneda");
            Destroy(collision.gameObject); 
            myGameManager.AddScore();
        }
        else if (collision.gameObject.CompareTag("itemBad"))
        {
            Destroy(collision.gameObject); 
            PlayerDeath();
        }
        else if (collision.gameObject.CompareTag("DeathZone"))
        {
            PlayerDeath(); 
        }
    }
    void PlayerDeath()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

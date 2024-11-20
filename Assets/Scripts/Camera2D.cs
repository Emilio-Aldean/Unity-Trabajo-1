using UnityEngine;

public class Camera2D : MonoBehaviour
{
    public Transform targetPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(targetPlayer.position.x + 6f,0,-10);
    }
}

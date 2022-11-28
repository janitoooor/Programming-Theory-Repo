using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public float speed;

    private Rigidbody enemy;
    private GameManager gameManager;

    private float boundX = -7.5f;
    private float boundZ = 5.99f;
    private float spawnZ = 6.17f;
    private float spawnTopZ = 8.35f;
    private float topBoundZ = 7.99f;
    private float midBoundZ = 6.01f;
    private float midBoundZz = 7.01f;
    private float midBoundZzz = 6.99f;
    private float spawnTopZz = 7.25f;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        enemy = GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        TransformPos();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Door"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Debug.Log("The door is broken!");
        }
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            gameManager.gameOver = true;
        }
    }

    void TransformPos()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < boundX)
        {
            Destroy(gameObject);
            gameManager.gameOver = true;
        }

        if (transform.position.z > boundZ && transform.position.z < midBoundZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, spawnZ);
        }
        
        if (transform.position.z > topBoundZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, spawnTopZ);
        }

        if (transform.position.z > midBoundZzz && transform.position.z < midBoundZz)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, spawnTopZz);
        }
    }
}

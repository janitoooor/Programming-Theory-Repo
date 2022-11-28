using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject gunPrefab;
    private GameManager gameManager;
    public float speed = 10.0f;
    private float boundZ = 4.8f;
    private float boundZz = 8.6f;
    private Vector3 offset = new Vector3(0.5f, 0.5f , 0);
    private Vector3 offsetTop = new Vector3(0.5f, 0.5f, 1);
    private Vector3 offsetBot = new Vector3(0.5f, 0.5f, -1);
    private Vector3 offsetBbot = new Vector3(0.5f, 0.5f, 0.5f);
    private Vector3 offsetBott = new Vector3(0.5f, 0.5f, -0.5f);

    public float spamDelay = 0.5f;
    private float chekTime = 0.0f;
    private float timePowerUp = 6;

    public bool hasPowerUp;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        SpawnGuns();
        TransformPos();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            Debug.Log("You has PowerUp!");
            Destroy(other.gameObject);
            hasPowerUp = true;
            StartCoroutine(PowerCountdownRoutine());
        }
    }

    IEnumerator PowerCountdownRoutine()
    {
        yield return new WaitForSeconds(timePowerUp);
        hasPowerUp = false;
        spamDelay = 0.5f;
    }

    private void SpawnGuns()
    {
        Vector3 spawnPos = transform.position + offset;
        if (chekTime < spamDelay)
        {
            chekTime += Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space) && gameManager.gameOver != true)
        {
            if (chekTime >= spamDelay && hasPowerUp != true)
            {
                Instantiate(gunPrefab, spawnPos, gunPrefab.transform.rotation);
                chekTime = 0.0f;
            }

            else if(hasPowerUp == true)
            {
                Vector3 spawnPoss = transform.position + offsetTop;
                Vector3 spawnPosss = transform.position + offsetBot;
                Vector3 spawnPpos = transform.position + offsetBbot;
                Vector3 spawnPpposs = transform.position + offsetBott;
                Instantiate(gunPrefab, spawnPos, gunPrefab.transform.rotation);
                Instantiate(gunPrefab, spawnPoss, gunPrefab.transform.rotation);
                Instantiate(gunPrefab, spawnPosss, gunPrefab.transform.rotation);
                Instantiate(gunPrefab, spawnPpos, gunPrefab.transform.rotation);
                Instantiate(gunPrefab, spawnPpposs, gunPrefab.transform.rotation);
            }
        }
    }


    private void TransformPos()
    {
        if(gameManager.gameOver != true)
        {
            float verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
        }

        if (transform.position.z < boundZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, boundZ);
        }
        if (transform.position.z > boundZz)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, boundZz);
        }
    }

}

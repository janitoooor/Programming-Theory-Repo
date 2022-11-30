using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] protected private GameObject gunPrefab;

    [SerializeField] protected private ParticleSystem particlePowerUp;

    [SerializeField] protected private AudioSource audioGun;
    [SerializeField] protected private float speed { get; private set; } = 10.0f;
    [SerializeField] protected private float boundZ { get; private set; } = 4.8f;
    [SerializeField] protected private float boundZz { get; private set; } = 8.6f;
    [SerializeField] protected private Vector3 offset { get; private set; } = new Vector3(0.1f, 0.5f , 0);
    [SerializeField] protected private Vector3 offsetTop { get; private set; } = new Vector3(0.1f, 0.5f, 1);
    [SerializeField] protected private Vector3 offsetBot { get; private set; } = new Vector3(0.1f, 0.5f, -1);
    [SerializeField] protected private Vector3 offsetBbot { get; private set; } = new Vector3(0.1f, 0.5f, 0.5f);
    [SerializeField] protected private Vector3 offsetBott { get; private set; } = new Vector3(0.1f, 0.5f, -0.5f);

    [SerializeField] protected private float spamDelay { get; private set; } = 0.5f;
    [SerializeField] protected private float chekTime { get; private set; } = 0.0f;
    [SerializeField] protected private float timePowerUp { get; private set; } = 6;

    [SerializeField] protected private bool hasPowerUp { get; private set; }

    protected private void Update()
    {
        SpawnGuns();
        TransformPos();
    }

    protected private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            particlePowerUp.Play();
            StartCoroutine(PowerCountdownRoutine());
        }
    }

    IEnumerator PowerCountdownRoutine()
    {
        yield return new WaitForSeconds(timePowerUp);
        hasPowerUp = false;
        particlePowerUp.Stop();
        spamDelay = 0.5f;
    }

    protected private void SpawnGuns()
    {
        Vector3 spawnPos = transform.position + offset;
        if (chekTime < spamDelay)
        {
            chekTime += Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space) && MainUI.gameOver != true)
        {
            if (chekTime >= spamDelay && hasPowerUp != true)
            {
                Instantiate(gunPrefab, spawnPos, gunPrefab.transform.rotation);
                chekTime = 0.0f;
                audioGun.Play();
            }
            else if(chekTime >= spamDelay && hasPowerUp == true)
            {
                spamDelay = 0.2f;
                chekTime = 0.0f;
                SpawnProjectile();
                audioGun.Play();
            }
        }
    }

    protected private void SpawnProjectile()
    {
        Vector3 spawnPos = transform.position + offset;
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


    protected private void TransformPos()
    {

        if (MainUI.gameOver != true)
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

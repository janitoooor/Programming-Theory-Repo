using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGuns : MonoBehaviour
{
    public float speed = 50;
    private float boundX = 5.5f;
    private float rotateSpeed = 400;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TransformPos();
    }

    private void TransformPos()
    {
        transform.Translate(Vector3.up * -speed * Time.deltaTime);
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);

        if (transform.position.x > boundX)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            other.GetComponent<EnemyHP>().KillEnemy(1);
        }
    }
}

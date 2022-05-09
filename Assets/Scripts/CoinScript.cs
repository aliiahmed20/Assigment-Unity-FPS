using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
   [SerializeField]public Transform coin;
   [SerializeField] GameObject gold;

    float xRotation = 0f;
    float amplitude = 0.5f;
    float frequency = 1.0f;
    Vector3 posOrigin = new Vector3();
    Vector3 tempPos = new Vector3();
    float x, z;
    Vector3 newPos;



    [SerializeField] float lifetime = 3f;

    float countdown;

    private void Start()
    {
        posOrigin = coin.transform.position;
        countdown = lifetime;
    }

    void Update()
    {
        xRotation -= Time.deltaTime * 60.0f;       
        transform.localRotation = Quaternion.Euler(0.0f, xRotation, 0.0f);

        tempPos = posOrigin;
        tempPos.y = Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        transform.position = tempPos;

        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {           
            x = Random.Range(-28.0f, 18.0f);
            z = Random.Range(-28.0f, 18.0f);
            newPos = new Vector3(x, 0, z);
            Instantiate(gold, newPos, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }




}

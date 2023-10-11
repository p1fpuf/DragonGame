using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDragon : MonoBehaviour
{
    public GameObject DragonEggPrefab;
    public float speed = 1;
    public float TimeBetweenEggDrops = 1f;
    public float LeftRightDistance = 10f;
    public float ChanceDirection = 0.1f;

    void Start()
    {
        Invoke("DropEgg", 2f);
    }
    void DropEgg()
    {
        Vector3 myVector = new Vector3(0.0f, 5.0f, 0.0f);
        GameObject egg = Instantiate<GameObject>(DragonEggPrefab);
        egg.transform.position = transform.position + myVector;
        Invoke("DropEgg", TimeBetweenEggDrops);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -LeftRightDistance)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > LeftRightDistance)
        {
            speed = -Mathf.Abs(speed);
        }
        }
    private void FixedUpdate()
    {
        if (Random.value < ChanceDirection)
        {
            speed *= -1;
        }
    }
}

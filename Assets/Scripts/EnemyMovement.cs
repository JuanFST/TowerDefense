using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 10f;
    public int health = 100;

    public int value = 50;

    private Transform target;
    private int wavePointIndex;

    void Start()
    {
        target = Waypoints.waypoints[0];
    }

    public void TakeDamage(int amount)
    {
        health -= amount;


        if (health <= 0)
        {
            PlayerStats.money += value;
            Die();
        }
    }

    void Die()
    {

        Destroy(gameObject);
    }

    private void Update()
    {
        Vector3 direccion = target.position - transform.position;
        transform.Translate(direccion.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.3f)
        {
            GetNextWaypoint();
        }
    }
    void GetNextWaypoint()
    {
        if (wavePointIndex >= Waypoints.waypoints.Length - 1)
        {
            EndPath();
            return;
        }
        wavePointIndex++;
        target = Waypoints.waypoints[wavePointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}

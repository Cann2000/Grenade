using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explision : MonoBehaviour
{
    public GameObject bomb;
    public float power = 10;
    public float radius = 5;
    public float upforce = 1;

    public bool GrenadeActive;


    // this script should be in camera !!!

    private void FixedUpdate()
    {
        if (bomb == enabled)
        {
            Invoke("GrenadeON", 5);
        }
    }

    private void GrenadeON()
    {

        Vector3 explosionpos = bomb.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionpos, radius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionpos, radius, upforce, ForceMode.Impulse);
            }
        }
    }

    // To see the drawn Collider not required !!!

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(bomb.transform.position,radius);
    }
}

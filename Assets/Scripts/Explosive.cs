using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    public float power = 10;
    public float radius = 5;
    public float upforce = 3;

    public bool GrenadeActive;


    private void FixedUpdate()
    {
        if (gameObject == enabled)
        {
            Invoke("GrenadeON", 3);
        }
    }

    private void GrenadeON()
    {

        Vector3 explosionpos = gameObject.transform.position;
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
        //Gizmos.DrawSphere(bomb.transform.position,radius);
    }
}

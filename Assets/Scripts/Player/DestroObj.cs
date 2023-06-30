using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroObj : MonoBehaviour
{
    public GameObject ExploHitFX;
    [SerializeField]private float raio = 10f;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != ("Inimigo") && other.gameObject.tag != ("Player") )
        {
            if (this.gameObject.tag == ("Bombs"))
            {
                Explode();
                Instantiate(ExploHitFX, this.transform.position, Quaternion.identity);

            }
            Destroy(this.gameObject);
            
        }

        if (other.gameObject.tag == ("Inimigo"))
        {
            if(this.gameObject.tag == ("Bombs"))
            {
                Explode();
                Instantiate(ExploHitFX, this.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
            else
            {
                other.GetComponent<Inimigo>().TomarDano(10);
                Destroy(this.gameObject);
                Debug.Log("Atingido");
            }
        }
        
    }

    private void Explode()
    {
        Collider[] colisores = Physics.OverlapSphere(this.transform.position, raio);
        Destroy(this.gameObject);
        foreach (Collider nearbyObjs in colisores)
        {
            if (nearbyObjs != null && nearbyObjs.gameObject.tag == ("Inimigo") && nearbyObjs.gameObject.tag != ("Ground"))
            {
                nearbyObjs.GetComponent<Inimigo>().TomarDano(30);
                Debug.Log("Raio Atingido");
            }

        }
         

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, raio);
    }
}

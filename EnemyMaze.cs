using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaze : MonoBehaviour
{
    
    public float czasWedrowki;
    public float PredkoscPoruszania;
    public float dystans;

    public GameObject Cel;


    private void Start()
    {

    }

    private void Update()
    {
        if (Cel==true)
         {
             if (Cel==null)
             {
                 SzukajCelu();
                 if (czasWedrowki>0)
                 {
                     transform.Translate(Vector3.forward * PredkoscPoruszania);
                     czasWedrowki -= Time.deltaTime;
                 }
                 else
                 {
                     czasWedrowki = Random.Range(5.0f, 12.0f);
                     Przemierzanie();
                 }
             }
             else
             {
                 PodazanieZaCelem();
             }
         }
     }


  void SzukajCelu()
  {
            Vector3 center = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            Collider[] hitColliders = Physics.OverlapSphere(center, 100);
            int i = 0;
            while (i < hitColliders.Length)
            {
                if (hitColliders[i].transform.tag == "Player")
                {
                    Cel = hitColliders[i].transform.gameObject;
                }
                i++;
            }
        }

        void PodazanieZaCelem()
        {
            Vector3 targetPosition = Cel.transform.position;
            targetPosition.y = transform.position.y;
            transform.LookAt(targetPosition);

            float distance = Vector3.Distance(Cel.transform.position, this.transform.position);
            if (distance < dystans)
            {
                transform.Translate(Vector3.forward * PredkoscPoruszania);
            }
        }

        void Przemierzanie()
        {
        transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
        }
}


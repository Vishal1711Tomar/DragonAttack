using UnityEditor.Rendering;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int ehealth;
    public float espeed;
    public int timebtwattack;
    [HideInInspector] public Transform player;
    public int pdamage;
    public int pickupchance;
    public GameObject[] pickup;
    public GameObject deatheffect;
    


    public  virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void TakeDamage(int edamage)
    {
        ehealth -= edamage;
        if(ehealth <= 0)
        {
            int random = Random.Range(0, 101);
            if(random<pickupchance)
            {
                GameObject randompickup = pickup[Random.Range(0, pickup.Length)];
                Instantiate(randompickup, transform.position, Quaternion.identity);

            }
            Instantiate(deatheffect,transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
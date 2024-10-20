
using System.Collections;
using System.IO.MemoryMappedFiles;
using UnityEngine;
public class MeleeEnemy: Enemy
{
    public float stopdistance;
    public float attackspeed;
    private float attacktime;

     void Update()
     {
        if (player != null)
        {
            if (Vector2.Distance(player.position, transform.position)>stopdistance)
            {  transform.position=Vector2.MoveTowards(transform.position, player.position, espeed*Time.deltaTime); // espeed for enemy inheritance

            }
            else
            {
                if (Time.time > attacktime)
                {
                    // Attack
                    StartCoroutine(Attack());
                    attacktime = Time.time + timebtwattack;
                    
                }
            }
        }
        
     }
    IEnumerator Attack()
    {
        player.GetComponent<Player>().TakeDamage(pdamage);
        Vector2 originalpos = transform.position;
        Vector2 targetpos = player.position;
        float percent = 0;
        while (percent <= 1)
        {
            percent += Time.deltaTime * attackspeed;
            float formula = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position=Vector2.Lerp(originalpos, targetpos, formula);
            yield return null;
        }
        
    }

}
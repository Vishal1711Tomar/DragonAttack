
using UnityEngine;

public class Weapon: MonoBehaviour
{
    public GameObject projectile;
    public Transform shootpoint;
    public Player player;
    public float timebtwshoot;
  


    private float shoottime;

    private void Start()
    {
        player= GetComponentInParent<Player>();

    }
    private void Update()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;
        if (Input.GetMouseButton(0) && Time.time >= shoottime)
        {
            Instantiate(projectile, shootpoint.position, transform.rotation);
            shoottime = Time.time + timebtwshoot;
  
        }

    }

}


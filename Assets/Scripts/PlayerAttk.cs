using UnityEngine;

public class PlayerAttk : MonoBehaviour
{
    public float damage;
    public float range;
    public Camera fpsCam;
    public Target target;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        
    }

    public void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.tag);


            if(hit.transform.tag == "Bat")
            {
              target.BatTakeDamage(damage);
                
            }


            if (hit.transform.tag == "Slime")
            {
               target.SlimeTakeDamage(damage);

            }
        }
    }
}

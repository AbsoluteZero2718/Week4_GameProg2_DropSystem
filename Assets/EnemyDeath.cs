using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public List <DropSystemScript> itemDrops = new List<DropSystemScript>();

    public void DropLoot()
    {
        float chance = Random.Range(0f, 100f);
        for (int i = 0; i < itemDrops.Count; i++)
        {
            if (chance <= itemDrops[i].DropChance)
            {
                int amountToDrop = Random.Range(itemDrops[i].min, itemDrops[i].max);
                for (int j = 0; j < amountToDrop; j++)
                {
                    GameObject itemSpawn = Instantiate(itemDrops[i].ItemPrefab, transform.position, Quaternion.identity);
                    //itemSpawn.AddComponent<Rigidbody>();
                    itemSpawn.AddComponent<CapsuleCollider>();
                    Rigidbody rb = itemSpawn.AddComponent<Rigidbody>();
                    rb.AddForce(transform.up * 100);
                    Destroy(itemSpawn, itemDrops[i].duration);

                }
                Debug.Log($"{amountToDrop} {itemDrops[i].ItemName} (s) dropped.");
            }
            
         }
    }
    public void OnDestroy()
    {
        DropLoot();
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}

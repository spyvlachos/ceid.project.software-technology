using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InventoryObject inventory;
    public void OnTriggerEnter2D(Collider2D collision)

    {

        var item = collision.GetComponent<GroundItem>();

        if (item)

        {

            inventory.AddItem(new Item (item.item), 1);

            Destroy(collision.gameObject);

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            inventory.Save();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            inventory.Load();
        }
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Items.Clear();
    }
}

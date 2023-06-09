using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite itemSprite;
    public bool showInInventory = true;
    public virtual void Use()
    {
        //TODO gelistirmeler yapýlacak
    }
    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}

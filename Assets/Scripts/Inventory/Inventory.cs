using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    private void Awake()
    {
        instance = this;
    }

    #endregion
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int inventorySpace = 10;

    public List<Item> items = new List<Item>();

    public void AddItem(Item item)
    {
        if (item.showInInventory)
        {
            if (items.Count >=inventorySpace)
            {
                Debug.Log("Not Enough Space ! ");
                return;
            }
            items.Add(item);
            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }
    }
    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback !=null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Generic.Enums;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
	public EquipmentSlot equipSlot;
	public int armorModifier;
	public int damageModifier;
	public SkinnedMeshRenderer prefab;

    public override void Use()
    {
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
    }

}

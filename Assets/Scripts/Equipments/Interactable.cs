using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
	public float radius = 3f;
	public Transform interactionTransform;
	bool isFocus = false;
	Transform player;
	bool hasInteracted = false;
    private void Update()
    {
        if (isFocus)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (!hasInteracted && distance<=radius)
            {
                hasInteracted = true;
                Interact();
            }
        }
    }
    public void OnFocused()
    {
        isFocus = true;
        hasInteracted = false;
        player = player.transform;
    }
    public void OnDefocused()
    {
        isFocus = false;
        hasInteracted = false;
        player = null;
    }
    public virtual void Interact()
    {

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}

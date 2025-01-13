using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    Vector2 currentlyFacingDirection = new Vector2(1, 0);
    LayerMask layerMask;
    [SerializeField] KeyCode interactKey;
    [SerializeField] float interactRange = 1f;
    // Start is called before the first frame update
    void Start()
    {
        layerMask = LayerMask.GetMask("Interactable");
    }

    public void SetFacingDirection(Vector2 newDirection)
    {
        
        currentlyFacingDirection = newDirection;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            InteractCheck();
        }
        
    }
    void InteractCheck()
    {
        //float yValue = Input.GetAxisRaw("Vertical");
        //float xValue = Input.GetAxisRaw("Horizontal");
        //currentlyFacingDirection = new Vector2(xValue, yValue);
        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, currentlyFacingDirection, interactRange, layerMask);
        Debug.Log(currentlyFacingDirection);
        if (raycastHit.collider)
        {
            raycastHit.collider.GetComponent<DialogueInitiator>().StartConversation();
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    Vector2 currentlyFacingDirection = new Vector2(1, 0);
    LayerMask layerMask;
    [SerializeField] KeyCode interactKey;
    [SerializeField] float interactRange = 1f;

    //temporory visual to show what direction the player before sprites and animations
    [SerializeField] Transform tempDirectionShower;

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
        float yValue = Input.GetAxisRaw("Vertical");
        float xValue = Input.GetAxisRaw("Horizontal");

        if (new Vector2(xValue, yValue) != Vector2.zero)
        {
            //Debug.Log(xValue + ", " + yValue);
            currentlyFacingDirection = new Vector2(xValue, yValue);
            tempDirectionShower.localPosition = new Vector2(xValue * 0.3f, yValue * 0.3f);
        }

        if (Input.GetKeyDown(interactKey))
        {
            InteractCheck();
        }
        
    }
    void InteractCheck()
    {

        
        
        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, currentlyFacingDirection, interactRange, layerMask);
        Debug.Log(currentlyFacingDirection);
        if (raycastHit.collider)
        {
            Debug.Log("hit collider");
            if (raycastHit.collider.GetComponent<DialogueInitiator>())
            {
                raycastHit.collider.GetComponent<DialogueInitiator>().StartConversation();
            }
            else if (raycastHit.collider.GetComponent<Pickup>())
            {
                Debug.Log("hit pickup");
                raycastHit.collider.GetComponent<Pickup>().AddToInventory();
            }
        }
        
    }
}

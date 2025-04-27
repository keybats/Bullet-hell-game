using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 1;

    public float weaponSlowdown = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        float yValue = Input.GetAxisRaw("Vertical");
        float xValue = Input.GetAxisRaw("Horizontal");

        
        

        RaycastHit2D hitX = Physics2D.Raycast(new Vector2(transform.position.x + 0.256f * xValue / Mathf.Abs(xValue), transform.position.y), transform.TransformDirection(Vector2.right * xValue)); 
        RaycastHit2D hitY = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + 0.256f * yValue / Mathf.Abs(yValue)), transform.TransformDirection(Vector2.up * yValue));

        
        if (hitX.transform.gameObject.GetComponent<Walls>())
        {

            if ((hitX.distance < 0.01f))
            {

                xValue = 0;
            }

        }
        if (hitY.transform.gameObject.GetComponent<Walls>())
        {
            if ((hitY.distance < 0.01f))
            {

                yValue = 0;
            }
        }

        Vector2 movementVector = new Vector2(xValue, yValue).normalized;


        //Debug.Log("x value " + xValue);
        //Debug.Log("Vector " + movementVector);

        transform.Translate(movementVector * speed * Time.deltaTime * weaponSlowdown);
    }



}

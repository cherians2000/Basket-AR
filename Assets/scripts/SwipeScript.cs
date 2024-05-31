using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeScript : MonoBehaviour
{

    Vector2 startPos, endPos, direction; // touch or mouse start position, end position, swipe direction
    float touchTimeStart, touchTimeFinish, timeInterval; // to calculate swipe time to control throw force

    [SerializeField]
    float throwForceInXandY = 1f; // to control throw force in X and Y directions

    [SerializeField]
    float throwForceInZ = 50f; // to control throw force in Z direction

    public float ballDestroyTime = 4f;

    Rigidbody rb;

    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        // Check for both touch and mouse input:
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
          
            HandleSwipeInput(Input.GetTouch(0).position);
        }
        else if (Input.GetMouseButtonDown(0))
        {
            HandleSwipeInput(Input.mousePosition);
           
        }
    }

    void HandleSwipeInput(Vector2 position)
    {
      
        touchTimeStart = Time.time;
        startPos = position;
    }

    void OnMouseUp()
    {
        // Handle mouse release events
        if (Input.GetMouseButtonUp(0))
        {
            touchTimeFinish = Time.time;
            endPos = Input.mousePosition;
            CalculateSwipeAndApplyForce();
        }
    }

    void CalculateSwipeAndApplyForce()
    {
        timeInterval = touchTimeFinish - touchTimeStart;
        direction = startPos - endPos;
        rb.isKinematic = false;
        rb.AddForce(-direction.x * throwForceInXandY, -direction.y * throwForceInXandY, throwForceInZ / timeInterval);
      //  AudioManager.instance.SwipedSfxUpdate();
        Destroy(gameObject, ballDestroyTime);
    }
}

using UnityEngine;
using System.Collections;

public class ViewPlatform : MonoBehaviour
{
    
    //public GameObject platform;
    /*// Start is called before the first frame update
    void Start()
    {
    platform = GameObject.Find("Platform");
    }
*/


    void Update()
    {
        float horizontalSpeed = 2.0f;
        float verticalSpeed = 2.0f;
        // Get the mouse delta. This is not in the range -1...1
        if (Input.GetMouseButton(0))
        {
            
            float h = horizontalSpeed * Input.GetAxis("Mouse X");
            float v = verticalSpeed * Input.GetAxis("Mouse Y");
            Debug.Log("Mouse X " + Input.GetAxis("Mouse X"));
            Debug.Log("Mouse Y " + Input.GetAxis("Mouse Y"));
            this.transform.Rotate(v, h, 0);
        }

        if (Input.GetKey(KeyCode.Z)) { Debug.Log("Mouse key "); this.transform.Rotate(0, horizontalSpeed, 0); }
            else if (Input.GetKey(KeyCode.C)) { Debug.Log("Mouse key "); this.transform.Rotate(0, -horizontalSpeed, 0); }
            else if (Input.GetKey(KeyCode.R)) { Debug.Log("Mouse key "); this.transform.Rotate(verticalSpeed, 0, 0); }
            else if (Input.GetKey(KeyCode.F)) { Debug.Log("Mouse key "); this.transform.Rotate(-verticalSpeed, 0, 0); }
            
        
    }
}

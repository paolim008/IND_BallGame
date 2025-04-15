using UnityEngine;

public class PlateController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float clampAngle;
    [SerializeField] private float clampDistance;

    private float currentXRot = 0f;
    private float currentZRot = 0f;
    
    [SerializeField] private Transform plate;
    private void Update()
    {
        if (Input.GetAxis("Horizontal") == 0)
        {
            //             0 < XROT < clampDistance                                 -clampDistance < XROT < 0
            if ((currentXRot < clampDistance && currentXRot > 0f) || (currentXRot < 0f && currentXRot > -clampDistance))
            {
                currentXRot = 0f;
            }
            else
            {
                if(currentXRot > 0)
                    currentXRot -= rotationSpeed * Time.deltaTime;
                else if(currentXRot < 0) 
                    currentXRot += rotationSpeed * Time.deltaTime;
            }
            

        }
        if (Input.GetAxis("Vertical") == 0)
        {
            if ((currentZRot < 0.7f && currentZRot > 0f) || (currentZRot < 0f && currentZRot > -0.7f))
            {
                currentZRot = 0f;
            }
            else
            {
                if (currentZRot > 0)
                    currentZRot -= rotationSpeed * Time.deltaTime;
                else if (currentZRot < 0)
                    currentZRot += rotationSpeed * Time.deltaTime;
            }
        }


        plate.rotation = Quaternion.Euler(currentXRot, 0f, currentZRot);
        
        
            float tiltX = Input.GetAxis("Horizontal");
            float tiltZ = Input.GetAxis("Vertical");
        
            currentXRot += tiltX * rotationSpeed * Time.deltaTime;
            currentZRot += tiltZ * rotationSpeed * Time.deltaTime;
        
            currentXRot = Mathf.Clamp(currentXRot, -clampAngle, clampAngle);
            currentZRot = Mathf.Clamp(currentZRot, -clampAngle, clampAngle);
        
        plate.rotation = Quaternion.Euler(currentXRot, 0f, currentZRot);    
        
        // Debug.Log("Horizontal : " + tiltX);
        // Debug.Log("Vertical : " + tiltZ);
        
    }
}

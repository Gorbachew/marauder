using UnityEngine;

public class AISensor : MonoBehaviour
{
    
    private AIControl aIControl;
    private void Awake()
    {
        aIControl = GetComponent<AIControl>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "character")
        {
            aIControl.FindCharacter(other.gameObject);
        }
    }
  
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "character")
        {
            StartCoroutine(aIControl.LostCharacter());
        }
        
    }

}

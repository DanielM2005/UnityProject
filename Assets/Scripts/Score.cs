using UnityEngine;

public class Score : MonoBehaviour
{
    private float hits = 0f;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Hit" && other.gameObject.tag != "Ground") 
        {
            hits++;
            Debug.Log("Score: " + hits);
        }
        
        
    }
}

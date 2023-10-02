using UnityEngine;

public class RocketCollisionHandler : MonoBehaviour
{
    private bool _isPowerUpActive;
    
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            default:
                if(!GameManager.Instance.IsGamePlaying()) return;
                GameManager.OnRocketHit?.Invoke();
                
                if (Health.Instance.GetCurrentHealth() < 1)
                {
                    GameManager.OnRocketCrashed?.Invoke();
                    //particle effect
                }
                break;
            case "Friendly":
                Debug.Log("friendly gameobject");
                break;
            case "Finish":
                GameManager.OnRocketFinished?.Invoke();
                //particle effects
                break;
        }
    }
}

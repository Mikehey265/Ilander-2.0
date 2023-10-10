using UnityEngine;

public class RocketCollisionHandler : MonoBehaviour
{
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
                }
                break;
            case "Friendly":
                break;
            case "Finish":
                GameManager.OnRocketFinished?.Invoke();
                break;
        }
    }
}

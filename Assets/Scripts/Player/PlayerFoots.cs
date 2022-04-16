using UnityEngine;

public class PlayerFoots : MonoBehaviour 
{ 
    public bool IsStay { get; private set; }

    private void OnTriggerStay2D(Collider2D collision)
    {
        IsStay = collision.TryGetComponent(out Floor floor);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Floor floor))
            IsStay = false;
    }
}
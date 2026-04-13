using UnityEngine;

public class VisualFlipper : MonoBehaviour
{
    public GameObject reference;

    public void Flip()
    {
        reference.SetActive(!reference.activeSelf);
    }
}

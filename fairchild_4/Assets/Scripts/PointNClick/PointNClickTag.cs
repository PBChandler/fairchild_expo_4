using UnityEngine;

public class PointNClickTag : MonoBehaviour
{
    public ImageInvestigation owner;
    public int id;

    public void Interact()
    {
        owner.AddItem(this);
    }
}

using UnityEngine;
using UnityEngine.Events;

public class EasyHover : MonoBehaviour
{
    public AudioClip onSelectClip, offSelectClip;
    public Sprite onSelectSprite, offSelectSprite;

    public SpriteRenderer mySprite;
    public AudioSource myAudio;

    public UnityEvent onRun;

    public void SetHovered()
    {
        mySprite.sprite = onSelectSprite;
        myAudio.PlayOneShot(onSelectClip);
    }

    public void SetNoLongerHovered()
    {
        mySprite.sprite = offSelectSprite;
        myAudio.PlayOneShot(offSelectClip);
    }

    public void RunEvent()
    {
        onRun.Invoke();
    }
}

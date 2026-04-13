using UnityEngine;
using UnityEngine.Formats.Alembic.Importer;

public class AlembicCoplayer : MonoBehaviour
{
    public AlembicStreamPlayer asp;
    public Animator time;
    public void Update()
    {
        if (AnimatorIsPlaying())
            asp.CurrentTime += Time.deltaTime;
        else
        {
            asp.CurrentTime = 0;
            time.Play(0);
        }
            
    }

    bool AnimatorIsPlaying()
    {
        // Get the current state info for layer 0 (base layer)
        AnimatorStateInfo stateInfo = time.GetCurrentAnimatorStateInfo(0);

        // Check if the animation is currently playing (normalizedTime < 1.0)
        // or if it's still considered "playing" even after the first loop
        return stateInfo.normalizedTime < 1.0f;
    }
}

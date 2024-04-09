using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer
{
    IEnumerator ApplyDamage(float value);
    void ApplyHeal(float value);
    void ApplyLevelProgress(int value);

    void PlayMode(bool isPlaying);
    void CollectTreasure(bool isCollecting);

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer
{
    void ApplyDamage(float value);
    void ApplyHeal(float value);
    void ApplyLevelProgress(int value);
}

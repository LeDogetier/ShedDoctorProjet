using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDifficultyState 
{
    void AdjustDifficulty(EnumDifficulty difficulty);
}

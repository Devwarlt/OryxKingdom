#region

using System;
using wServer.logic.attack;
using wServer.logic.cond;
using wServer.logic.loot;
using wServer.logic.movement;
using wServer.logic.taunt;

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private static _ C453 = Behav()
            .Init(0x702A, Behaves("C453 The Mad Coder",
            new RunBehaviors(
                new State("idle",
                        SetConditionEffect.Instance(ConditionEffectIndex.Armored),
                        HpLesserPercent.Instance(0.99f, SetState.Instance("beginning of the end"))
                        ),
                new State("beginning of the end",
                        SetConditionEffect.Instance(ConditionEffectIndex.Armored),
                        InfiniteSpiralAttack.Instance(1000, 20, 1, 0)//,
                        //HpLesserPercent.Instance(0.99f, SetState.Instance("beginning of the end"))
                        )
                )
            ));
    }
}
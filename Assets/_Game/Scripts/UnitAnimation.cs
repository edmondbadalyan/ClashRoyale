using UnityEngine;
using static UnitState;

public class UnitAnimation : MonoBehaviour
{
    private const string STATE = "State";
    private const string ATTACKSPEED = "AttackSpeed";
    [SerializeField] private Animator _animator;

    public void Init(Unit unit)
    {
        float damageDelay = unit.parametres.damageDelay;
        _animator.SetFloat(ATTACKSPEED, 1/damageDelay);
    }
    public void SetState(UnitStateType type)
    {
        _animator.SetInteger(STATE, (int)type);
    }
}

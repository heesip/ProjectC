using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[System.Serializable]
public class PlayerAnimatorSystem
{
    Animator _animator;
    [SerializeField] Animator _effectAnimator;
    
    public void Initialize( )
    {
        _animator = Player.Instance.GetComponent<Animator>();
    }

    public void RunAnimation(float keyboardInput)
    {
        _animator.SetFloat(AllStrings.Run_Key, keyboardInput);
    }

    public void RunAnimation(bool joyStickDrag)
    {
        _animator.SetBool(AllStrings.Run_Joy, joyStickDrag);
    }

    public void DeadAnimation()
    {
        _animator.SetTrigger(AllStrings.Dead);
    }

    public void AtropineEffect(bool isAtropine)
    {
        _effectAnimator.SetBool(AllStrings.IsAtropine, isAtropine);
    }

    public void HealEffect()
    {
        _effectAnimator.SetTrigger(AllStrings.IsHeal);
    }
}

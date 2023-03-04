using cky.Reuseables.Extension;
using PizzaTower.Characters.Chef.StateMachine;
using UnityEngine;

namespace PizzaTower.Characters.Chef.States
{
    public class GoToTableState : ChefBaseState
    {
        Transform _chefTr;
        Vector3 _tableLocalPosition;
        Vector3 _direction;
        SpriteRenderer _spriteRenderer;

        public GoToTableState(ChefStateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            _spriteRenderer = stateMachine.GetComponent<SpriteRenderer>();
            _spriteRenderer.flipX = true;

            stateMachine.Animator.Walk();

            _chefTr = stateMachine.transform;
            _tableLocalPosition = stateMachine.TableLocalPosition;
        }

        public override void Exit()
        {
            _spriteRenderer.flipX = false;
        }

        public override void Tick(float deltaTime)
        {
            _direction = _chefTr.LocalUnitDirectionX(_tableLocalPosition);

            _chefTr.localPosition += _direction * stateMachine.MovementSpeed * deltaTime;

            if (Mathf.Abs(_tableLocalPosition.x - _chefTr.localPosition.x) < 0.1f)
            {
                _chefTr.localPosition = _tableLocalPosition;
                stateMachine.SwitchState(new CookState(stateMachine));
            }
        }
    }
}
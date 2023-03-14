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

        public GoToTableState(ChefStateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            stateMachine.SpriteRenderer.flipX = true;

            stateMachine.Animator.Walk();

            _chefTr = stateMachine.transform;
            _tableLocalPosition = stateMachine.TableLocalPosition;
        }

        public override void Exit()
        {
            stateMachine.SpriteRenderer.flipX = false;
        }

        public override void Tick(float deltaTime)
        {
            _direction = _chefTr.LocalUnitDirectionX(_tableLocalPosition);

            _chefTr.localPosition += _direction * stateMachine.MovementSpeed * deltaTime;

            if (Mathf.Abs(_tableLocalPosition.x - _chefTr.localPosition.x) < 0.2f)
            {
                _chefTr.localPosition = _tableLocalPosition;
                stateMachine.SwitchState(new CookState(stateMachine));
            }
        }
    }
}
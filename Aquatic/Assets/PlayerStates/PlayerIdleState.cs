using UnityEngine;
public class PlayerIdleState : PlayerState {
    protected Vector2 rawMovementInput { get; private set; }

    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName) {
	}

	public override void DoChecks() {
		base.DoChecks();
        rawMovementInput = player.InputHandler.RawMovementInput;
    }

    public override void Enter() {
		base.Enter();
		player.SetVelocity(0,0);
        //Movement?.SetVelocityX(0f);
    }

	public override void Exit() {
		base.Exit();
	}

	public override void LogicUpdate() {
		base.LogicUpdate();
		if (!isExitingState && (rawMovementInput.x != 0 || rawMovementInput.y != 0))
			stateMachine.ChangeState(player.MoveState);
	}

	public override void PhysicsUpdate() {
		base.PhysicsUpdate();
	}
}
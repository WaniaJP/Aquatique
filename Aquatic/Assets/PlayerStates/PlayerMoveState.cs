using UnityEngine;
public class PlayerMoveState : PlayerState {
    protected Vector2 rawMovementInput { get; set; }

    public PlayerMoveState(Player player, PlayerStateMachine stateMachine,string animBoolName) : base(player, stateMachine,animBoolName) {
	}

	public override void DoChecks() {
		base.DoChecks();
		rawMovementInput = player.InputHandler.RawMovementInput;
	}

	public override void Enter() {
		base.Enter();
	}

	public override void Exit() {
		base.Exit();
	}

	public override void LogicUpdate() {
		base.LogicUpdate();
		if (!isExitingState && rawMovementInput.x == 0 && rawMovementInput.y == 0)
			stateMachine.ChangeState(player.IdleState);
	}

	public override void PhysicsUpdate() {
		base.PhysicsUpdate();
		player.Run(rawMovementInput);
	}
}

namespace Platformer2d
{
    public class PlayerStateMachine : StateMachine<Player>
    {
        public PlayerStateMachine(Player actor)
        {
            AddStates(actor);
            SetState(typeof(MovePlayerState));
        }

        public override void AddStates(Player player)
        {
            AddState(new MovePlayerState(player, this));
            AddState(new JumpPlayerState(player, this));
            AddState(new FallPlayerState(player, this));
            AddState(new AttackPlayerState(player, this));
        }
    }
}
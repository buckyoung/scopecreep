using ScopeCreep.Player;

namespace ScopeCreep.Module {
	public interface IEngageable {
        void disengage(ShipModule module, Player.Player player);
        void engage(ShipModule module, Player.Player player);
	}
}
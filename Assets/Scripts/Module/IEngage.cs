using ScopeCreep.Player;

namespace ScopeCreep.Module {
	public interface IEngage {
		void engage(ShipModule module, Player.Player player);
		void disengage(ShipModule module, Player.Player player);
	}
}
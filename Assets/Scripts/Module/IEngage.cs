using ScopeCreep.Player;

namespace ScopeCreep.Module {
	public interface IEngage {
		void engage(ShipModule module, PlayerInfo player);
		void disengage(ShipModule module, PlayerInfo player);
	}
}
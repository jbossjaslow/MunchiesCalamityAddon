using CalamityMod;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Munchies_CalamityAddon {
	public class Munchies_CalamityAddon : Mod {
		internal static Munchies_CalamityAddon instance;
		internal Mod MunchiesMod;
		internal Mod CalamityMod;

		public Munchies_CalamityAddon() { }

		public override void Load() {
			instance = this;
		}

		public override void Unload() {
			instance = null;
		}

		public override void PostSetupContent() {
			try {
				if (ModLoader.TryGetMod("Munchies", out Mod munchiesMod) && ModLoader.TryGetMod("CalamityMod", out Mod calamityMod)) {
					MunchiesMod = munchiesMod;
					CalamityMod = calamityMod;

					AddCalamityConsumables_Health();
					AddCalamityConsumables_Mana();
					AddCalamityConsumables_Other();
					AddCalamityConsumables_RageMode();
					AddCalamityConsumables_AdrenalineMode();
				} else {
					Logger.Error("Error: couldn't find the Munchies mod or the Calamity mod");
				}
			} catch {
				Logger.Error($"PostSetupContent Error in Munchies Calamity Addon");
			}
		}

		private void AddCalamityConsumables_Health() {
			if (CalamityMod == null) return;
			CallMunchiesMod(GetModItem("BloodOrange"), "player_normal", () => Main.LocalPlayer.Calamity().bOrange);
			CallMunchiesMod(GetModItem("MiracleFruit"), "player_normal", () => Main.LocalPlayer.Calamity().mFruit);
			CallMunchiesMod(GetModItem("Elderberry"), "player_normal", () => Main.LocalPlayer.Calamity().eBerry);
			CallMunchiesMod(GetModItem("Dragonfruit"), "player_normal", () => Main.LocalPlayer.Calamity().dFruit);
		}

		private void AddCalamityConsumables_Mana() {
			if (CalamityMod == null) return;
			CallMunchiesMod(GetModItem("CometShard"), "player_normal", () => Main.LocalPlayer.Calamity().cShard);
			CallMunchiesMod(GetModItem("EtherealCore"), "player_normal", () => Main.LocalPlayer.Calamity().eCore);
			CallMunchiesMod(GetModItem("PhantomHeart"), "player_normal", () => Main.LocalPlayer.Calamity().pHeart);
		}

		private void AddCalamityConsumables_RageMode() {
			if (CalamityMod == null) return;
			CallMunchiesMod(GetModItem("MushroomPlasmaRoot"), Color.Red, () => Main.LocalPlayer.Calamity().rageBoostOne);
			CallMunchiesMod(GetModItem("InfernalBlood"), Color.Red, () => Main.LocalPlayer.Calamity().rageBoostTwo);
			CallMunchiesMod(GetModItem("RedLightningContainer"), Color.Red, () => Main.LocalPlayer.Calamity().rageBoostThree);
		}

		private void AddCalamityConsumables_AdrenalineMode() {
			if (CalamityMod == null) return;
			CallMunchiesMod(GetModItem("ElectrolyteGelPack"), Color.Red, () => Main.LocalPlayer.Calamity().adrenalineBoostOne);
			CallMunchiesMod(GetModItem("StarlightFuelCell"), Color.Red, () => Main.LocalPlayer.Calamity().adrenalineBoostTwo);
			CallMunchiesMod(GetModItem("Ectoheart"), Color.Red, () => Main.LocalPlayer.Calamity().adrenalineBoostThree);
		}

		private void AddCalamityConsumables_Other() {
			if (CalamityMod == null) return;
			CallMunchiesMod(GetModItem("CelestialOnion"), "player_normal", () => Main.LocalPlayer.Calamity().extraAccessoryML);
		}

		private ModItem GetModItem(string name) {
			if (CalamityMod == null) return null;

			if (CalamityMod.TryFind(name, out ModItem ectoheart)) return ectoheart;
			else return null;
		}

		private void CallMunchiesMod(ModItem item, object categoryOrColor, Func<bool> hasBeenConsumed) {
			if (MunchiesMod == null || item == null) return;

			object[] args = [
				"AddSingleConsumable",
				CalamityMod,
				"1.3",
				item,
				categoryOrColor,
				hasBeenConsumed
			];
			MunchiesMod.Call(args);
		}
	}
}

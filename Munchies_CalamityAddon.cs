using CalamityMod;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using CalamityMod.Systems;

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
			CallMunchiesMod(GetModItem("BloodOrange"), () => Main.LocalPlayer.Calamity().bOrange);
			CallMunchiesMod(GetModItem("MiracleFruit"), () => Main.LocalPlayer.Calamity().mFruit);
			CallMunchiesMod(GetModItem("Elderberry"), () => Main.LocalPlayer.Calamity().eBerry);
			CallMunchiesMod(GetModItem("Dragonfruit"), () => Main.LocalPlayer.Calamity().dFruit);
		}

		private void AddCalamityConsumables_Mana() {
			if (CalamityMod == null) return;
			CallMunchiesMod(GetModItem("CometShard"), () => Main.LocalPlayer.Calamity().cShard);
			CallMunchiesMod(GetModItem("EtherealCore"), () => Main.LocalPlayer.Calamity().eCore);
			CallMunchiesMod(GetModItem("PhantomHeart"), () => Main.LocalPlayer.Calamity().pHeart);
		}

		private void AddCalamityConsumables_RageMode() {
			if (CalamityMod == null) return;
			CallMunchiesMod(GetModItem("MushroomPlasmaRoot"), () => Main.LocalPlayer.Calamity().rageBoostOne, Color.Red, "Revengeance", () => Main.LocalPlayer.Calamity().RageEnabled);
			CallMunchiesMod(GetModItem("InfernalBlood"), () => Main.LocalPlayer.Calamity().rageBoostTwo, Color.Red, "Revengeance", () => Main.LocalPlayer.Calamity().RageEnabled);
			CallMunchiesMod(GetModItem("RedLightningContainer"), () => Main.LocalPlayer.Calamity().rageBoostThree, Color.Red, "Revengeance", () => Main.LocalPlayer.Calamity().RageEnabled);
		}

		private void AddCalamityConsumables_AdrenalineMode() {
			if (CalamityMod == null) return;
			CallMunchiesMod(GetModItem("ElectrolyteGelPack"), () => Main.LocalPlayer.Calamity().adrenalineBoostOne, Color.Red, "Revengeance", () => Main.LocalPlayer.Calamity().AdrenalineEnabled);
			CallMunchiesMod(GetModItem("StarlightFuelCell"), () => Main.LocalPlayer.Calamity().adrenalineBoostTwo, Color.Red, "Revengeance", () => Main.LocalPlayer.Calamity().AdrenalineEnabled);
			CallMunchiesMod(GetModItem("Ectoheart"), () => Main.LocalPlayer.Calamity().adrenalineBoostThree, Color.Red, "Revengeance", () => Main.LocalPlayer.Calamity().AdrenalineEnabled);
		}

		private void AddCalamityConsumables_Other() {
			if (CalamityMod == null) return;
			CallMunchiesMod(GetModItem("CelestialOnion"), () => Main.LocalPlayer.Calamity().extraAccessoryML);
		}

		private ModItem GetModItem(string name) {
			if (CalamityMod == null) return null;

			if (CalamityMod.TryFind(name, out ModItem ectoheart)) return ectoheart;
			else return null;
		}

		private void CallMunchiesMod(ModItem item, Func<bool> hasBeenConsumed, Color? customColor = null, string difficulty = "classic", Func<bool> availability = null) {
			if (MunchiesMod == null || item == null) return;

			object[] args = [
				"AddSingleConsumable",
				CalamityMod,
				"1.3",
				item,
				"player",
				hasBeenConsumed,
				customColor,
				difficulty,
				null,
				availability
			];
			MunchiesMod.Call(args);
		}
	}
}

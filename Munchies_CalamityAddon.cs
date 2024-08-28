using CalamityMod;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using CalamityMod.Projectiles.Boss;
using CalamityMod.Rarities;
using CalamityMod.Items.PermanentBoosters;

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
			if (ModContent.TryFind("CalamityMod/BloodOrange", out ModItem bOrange)) {
				CallMunchiesMod(bOrange, "player_normal", () => Main.LocalPlayer.Calamity().bOrange);
			}

			if (ModContent.TryFind("CalamityMod/MiracleFruit", out ModItem mFruit)) {
				CallMunchiesMod(mFruit, "player_normal", () => Main.LocalPlayer.Calamity().mFruit);
			}

			if (ModContent.TryFind("CalamityMod/Elderberry", out ModItem eBerry)) {
				CallMunchiesMod(eBerry, "player_normal", () => Main.LocalPlayer.Calamity().eBerry);
			}

			if (ModContent.TryFind("CalamityMod/Dragonfruit", out ModItem dFruit)) {
				CallMunchiesMod(dFruit, "player_normal", () => Main.LocalPlayer.Calamity().dFruit);
			}
		}

		private void AddCalamityConsumables_Mana() {
			if (ModContent.TryFind("CalamityMod/CometShard", out ModItem cShard)) {
				CallMunchiesMod(cShard, "player_normal", () => Main.LocalPlayer.Calamity().cShard);
			}

			if (ModContent.TryFind("CalamityMod/EtherealCore", out ModItem eCore)) {
				CallMunchiesMod(eCore, "player_normal", () => Main.LocalPlayer.Calamity().eCore);
			}

			if (ModContent.TryFind("CalamityMod/PhantomHeart", out ModItem pHeart)) {
				CallMunchiesMod(pHeart, "player_normal", () => Main.LocalPlayer.Calamity().pHeart);
			}
		}

		private void AddCalamityConsumables_RageMode() {
			if (ModContent.TryFind("CalamityMod/MushroomPlasmaRoot", out ModItem mushroomPlasmaRoot)) {
				CallMunchiesMod(mushroomPlasmaRoot, Color.Red, () => Main.LocalPlayer.Calamity().rageBoostOne);
			}

			if (ModContent.TryFind("CalamityMod/InfernalBlood", out ModItem infernalBlood)) {
				CallMunchiesMod(infernalBlood, Color.Red, () => Main.LocalPlayer.Calamity().rageBoostTwo);
			}

			if (ModContent.TryFind("CalamityMod/RedLightningContainer", out ModItem redLightning)) {
				CallMunchiesMod(redLightning, Color.Red, () => Main.LocalPlayer.Calamity().rageBoostThree);
			}
		}

		private void AddCalamityConsumables_AdrenalineMode() {
			if (ModContent.TryFind("CalamityMod/ElectrolyteGelPack", out ModItem electrolyteGelPack)) {
				CallMunchiesMod(electrolyteGelPack, Color.Red, () => Main.LocalPlayer.Calamity().adrenalineBoostOne);
			}

			if (ModContent.TryFind("CalamityMod/StarlightFuelCell", out ModItem starlightFuelCell)) {
				CallMunchiesMod(starlightFuelCell, Color.Red, () => Main.LocalPlayer.Calamity().adrenalineBoostTwo);
			}

			if (ModContent.TryFind("CalamityMod/Ectoheart", out ModItem ectoheart)) {
				CallMunchiesMod(ectoheart, Color.Red, () => Main.LocalPlayer.Calamity().adrenalineBoostThree);
			}
		}

		private void AddCalamityConsumables_Other() {
			if (ModContent.TryFind("CalamityMod/CelestialOnion", out ModItem celestialOnion)) {
				CallMunchiesMod(celestialOnion, "player_normal", () => Main.LocalPlayer.Calamity().extraAccessoryML);
			}
		}

		private void CallMunchiesMod(ModItem item, object categoryOrColor, Func<bool> hasBeenConsumed) {
			object[] args = {
				"AddSingleConsumable",
				CalamityMod,
				"1.3",
				item,
				categoryOrColor,
				hasBeenConsumed
			};
			MunchiesMod?.Call(args);
		}
	}
}

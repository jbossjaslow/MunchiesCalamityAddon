using CalamityMod;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using CalamityMod.Items.Fishing;

namespace Munchies_CalamityAddon {
	public class Munchies_CalamityAddon : Mod {
		internal static Munchies_CalamityAddon instance;
		internal Mod MunchiesMod;
		internal Mod CalamityMod;

		private LocalizedText BloodOrangeText;
		private LocalizedText MiracleFruitText;
		private LocalizedText ElderberryText;
		private LocalizedText DragonfruitText;
		private LocalizedText EnchantedStarfishText;
		private LocalizedText CometShardText;
		private LocalizedText EtherealCoreText;
		private LocalizedText PhantomHeartText;
		private LocalizedText MushroomPlasmaRootText;
		private LocalizedText InfernalBloodText;
		private LocalizedText RedLightningContainerText;
		private LocalizedText ElectrolyteGelPackText;
		private LocalizedText StarlightFuelCellText;
		private LocalizedText EctoheartText;
		private LocalizedText CelestialOnionText;

		public override void Load() {
			instance = this;

			BloodOrangeText = this.GetLocalization("Acquisition.BloodOrange");
			MiracleFruitText = this.GetLocalization("Acquisition.MiracleFruit");
			ElderberryText = this.GetLocalization("Acquisition.Elderberry");
			DragonfruitText = this.GetLocalization("Acquisition.Dragonfruit");
			EnchantedStarfishText = this.GetLocalization("Acquisition.EnchantedStarfish");
			CometShardText = this.GetLocalization("Acquisition.CometShard");
			EtherealCoreText = this.GetLocalization("Acquisition.EtherealCore");
			PhantomHeartText = this.GetLocalization("Acquisition.PhantomHeart");
			MushroomPlasmaRootText = this.GetLocalization("Acquisition.MushroomPlasmaRoot");
			InfernalBloodText = this.GetLocalization("Acquisition.InfernalBlood");
			RedLightningContainerText = this.GetLocalization("Acquisition.RedLightningContainer");
			ElectrolyteGelPackText = this.GetLocalization("Acquisition.ElectrolyteGelPack");
			StarlightFuelCellText = this.GetLocalization("Acquisition.StarlightFuelCell");
			EctoheartText = this.GetLocalization("Acquisition.Ectoheart");
			CelestialOnionText = this.GetLocalization("Acquisition.CelestialOnion");
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
			CallMunchiesModConsumable(GetModItem("BloodOrange"), () => Main.LocalPlayer.Calamity().bOrange, BloodOrangeText);
			CallMunchiesModConsumable(GetModItem("MiracleFruit"), () => Main.LocalPlayer.Calamity().mFruit, MiracleFruitText);
			CallMunchiesModConsumable(GetModItem("Elderberry"), () => Main.LocalPlayer.Calamity().eBerry, ElderberryText);
			CallMunchiesModConsumable(GetModItem("Dragonfruit"), () => Main.LocalPlayer.Calamity().dFruit, DragonfruitText);
		}

		private void AddCalamityConsumables_Mana() {
			if (CalamityMod == null) return;
			CallMunchiesModMultiConsumable(GetModItem("EnchantedStarfish"), () => Main.LocalPlayer.ConsumedManaCrystals, () => 9, EnchantedStarfishText);
			CallMunchiesModConsumable(GetModItem("CometShard"), () => Main.LocalPlayer.Calamity().cShard, CometShardText);
			CallMunchiesModConsumable(GetModItem("EtherealCore"), () => Main.LocalPlayer.Calamity().eCore, EtherealCoreText);
			CallMunchiesModConsumable(GetModItem("PhantomHeart"), () => Main.LocalPlayer.Calamity().pHeart, PhantomHeartText);
		}

		private void AddCalamityConsumables_RageMode() {
			if (CalamityMod == null) return;
			CallMunchiesModConsumable(GetModItem("MushroomPlasmaRoot"), () => Main.LocalPlayer.Calamity().rageBoostOne, MushroomPlasmaRootText, Color.Red, "Revengeance", () => Main.LocalPlayer.Calamity().RageEnabled);
			CallMunchiesModConsumable(GetModItem("InfernalBlood"), () => Main.LocalPlayer.Calamity().rageBoostTwo, InfernalBloodText, Color.Red, "Revengeance", () => Main.LocalPlayer.Calamity().RageEnabled);
			CallMunchiesModConsumable(GetModItem("RedLightningContainer"), () => Main.LocalPlayer.Calamity().rageBoostThree, RedLightningContainerText, Color.Red, "Revengeance", () => Main.LocalPlayer.Calamity().RageEnabled);
		}

		private void AddCalamityConsumables_AdrenalineMode() {
			if (CalamityMod == null) return;
			CallMunchiesModConsumable(GetModItem("ElectrolyteGelPack"), () => Main.LocalPlayer.Calamity().adrenalineBoostOne, ElectrolyteGelPackText, Color.Red, "Revengeance", () => Main.LocalPlayer.Calamity().AdrenalineEnabled);
			CallMunchiesModConsumable(GetModItem("StarlightFuelCell"), () => Main.LocalPlayer.Calamity().adrenalineBoostTwo, StarlightFuelCellText, Color.Red, "Revengeance", () => Main.LocalPlayer.Calamity().AdrenalineEnabled);
			CallMunchiesModConsumable(GetModItem("Ectoheart"), () => Main.LocalPlayer.Calamity().adrenalineBoostThree, EctoheartText, Color.Red, "Revengeance", () => Main.LocalPlayer.Calamity().AdrenalineEnabled);
		}

		private void AddCalamityConsumables_Other() {
			if (CalamityMod == null) return;
			CallMunchiesModConsumable(GetModItem("CelestialOnion"), () => Main.LocalPlayer.Calamity().extraAccessoryML, CelestialOnionText);
		}

		private ModItem GetModItem(string name) {
			if (CalamityMod == null) return null;

			if (CalamityMod.TryFind(name, out ModItem modItem)) return modItem;
			else return null;
		}

		private void CallMunchiesModConsumable(ModItem item, Func<bool> hasBeenConsumed, LocalizedText acquisitionText, Color? customColor = null, string difficulty = "classic", Func<bool> availability = null) {
			if (MunchiesMod == null || item == null) return;

			object[] args = [
				"AddSingleConsumable",
				CalamityMod,
				"1.4",
				item,
				"player",
				hasBeenConsumed,
				customColor,
				difficulty,
				item.Tooltip,
				availability,
				acquisitionText
			];
			MunchiesMod.Call(args);
		}

		private void CallMunchiesModMultiConsumable(ModItem item, Func<int> currentCount, Func<int> totalCount, LocalizedText acquisitionText, Color? customColor = null, string difficulty = "classic", Func<bool> availability = null) {
			if (MunchiesMod == null || item == null) return;

			object[] args = [
				"AddMultiUseConsumable",
				CalamityMod,
				"1.4",
				item,
				"player",
				currentCount,
				totalCount,
				customColor,
				difficulty,
				item.Tooltip,
				availability,
				acquisitionText
			];
			MunchiesMod.Call(args);
		}
	}
}

using CalamityMod;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Munchies_CalamityAddon {
	public class Munchies_CalamityAddon : Mod {
		internal static Munchies_CalamityAddon instance;

		public Munchies_CalamityAddon() { }

		public override void Load() {
			instance = this;
		}

		public override void Unload() {
			instance = null;
		}

		public override void PostSetupContent() {
			try {
				if (ModLoader.TryGetMod("Munchies", out Mod munchiesMod)) {
					AddCalamityMod(munchiesMod);
					AddCalamityConsumables_Health(munchiesMod);
					AddCalamityConsumables_Mana(munchiesMod);
					AddCalamityConsumables_Other(munchiesMod);
					AddCalamityConsumables_RageMode(munchiesMod);
					AddCalamityConsumables_AdrenalineMode(munchiesMod);
				} else {
					Logger.Error("Error: couldn't find the Munchies mod");
				}
			} catch (Exception e) {
				Logger.Error($"PostSetupContent Error: {e.StackTrace} {e.Message}");
			}
		}

		private void AddCalamityMod(Mod munchiesMod) {
			string[] args = {
				"AddMod",
				"Calamity",
				"CalamityMod/icon_small" //"CalamityMod/MainMenu/Logo"
			};
			munchiesMod.Call(args);
		}

		private void AddCalamityConsumables_Health(Mod munchiesMod) {
			object[] bloodOrangeArgs = {
				"AddConsumable",
				"Calamity",
				"Blood Orange",
				"CalamityMod/Items/PermanentBoosters/BloodOrange",
				"Increases max health by 25 if user has at least 500 HP",
				"player_normal",
				new Func<bool>(GetBOrange),
				"38",
				"40"
			};
			munchiesMod.Call(bloodOrangeArgs);

			object[] miracleFruitArgs = {
				"AddConsumable",
				"Calamity",
				"Miracle Fruit",
				"CalamityMod/Items/PermanentBoosters/MiracleFruit",
				"Increases max health by 25 if user has at least 500 HP",
				"player_normal",
				new Func<bool>(GetMFruit),
				"32",
				"36"
			};
			munchiesMod.Call(miracleFruitArgs);

			object[] elderberryArgs = {
				"AddConsumable",
				"Calamity",
				"Elderberry",
				"CalamityMod/Items/PermanentBoosters/Elderberry",
				"Increases max health by 25 if user has at least 500 HP",
				"player_normal",
				new Func<bool>(GetEBerry),
				"38",
				"34"
			};
			munchiesMod.Call(elderberryArgs);

			object[] dragonfruitArgs = {
				"AddConsumable",
				"Calamity",
				"Dragonfruit",
				"CalamityMod/Items/PermanentBoosters/Dragonfruit",
				"Increases max health by 25 if user has at least 500 HP",
				"player_normal",
				new Func<bool>(GetDFruit),
				"32",
				"32"
			};
			munchiesMod.Call(dragonfruitArgs);

			static bool GetBOrange() {
				return Main.LocalPlayer.Calamity().bOrange;
			}

			static bool GetMFruit() {
				return Main.LocalPlayer.Calamity().mFruit;
			}

			static bool GetEBerry() {
				return Main.LocalPlayer.Calamity().eBerry;
			}

			static bool GetDFruit() {
				return Main.LocalPlayer.Calamity().dFruit;
			}
		}

		private void AddCalamityConsumables_Mana(Mod munchiesMod) {
			object[] cometShardArgs = {
				"AddConsumable",
				"Calamity",
				"Comet Shard",
				"CalamityMod/Items/PermanentBoosters/CometShard",
				"Increases max mana by 50 if user has at least 200 mana",
				"player_normal",
				new Func<bool>(GetCShard),
				"24",
				"46"
			};
			munchiesMod.Call(cometShardArgs);

			object[] etherealCoreArgs = {
				"AddConsumable",
				"Calamity",
				"Ethereal Core",
				"CalamityMod/Items/PermanentBoosters/EtherealCore",
				"Increases max mana by 50 if user has at least 200 mana",
				"player_normal",
				new Func<bool>(GetECore),
				"42",
				"44"
			};
			munchiesMod.Call(etherealCoreArgs);

			object[] phantomHeartArgs = {
				"AddConsumable",
				"Calamity",
				"Phantom Heart",
				"CalamityMod/Items/PermanentBoosters/PhantomHeart",
				"Increases max mana by 50 if user has at least 200 mana",
				"player_normal",
				new Func<bool>(GetPHeart),
				"28",
				"46"
			};
			munchiesMod.Call(phantomHeartArgs);

			static bool GetCShard() {
				return Main.LocalPlayer.Calamity().cShard;
			}

			static bool GetECore() {
				return Main.LocalPlayer.Calamity().eCore;
			}

			static bool GetPHeart() {
				return Main.LocalPlayer.Calamity().pHeart;
			}
		}

		private void AddCalamityConsumables_RageMode(Mod munchiesMod) {
			object[] mushroomPlasmaRootArgs = {
				"AddConsumable",
				"Calamity",
				"Mushroom Plasma Root",
				"CalamityMod/Items/PermanentBoosters/MushroomPlasmaRoot",
				"[Revengeance/Death Mode Only] Increases Rage Mode duration by 1 second",
				Color.Red,
				new Func<bool>(GetRageBoostOne),
				"32",
				"32"
			};
			munchiesMod.Call(mushroomPlasmaRootArgs);

			object[] infernalBloodArgs = {
				"AddConsumable",
				"Calamity",
				"Infernal Blood",
				"CalamityMod/Items/PermanentBoosters/InfernalBlood",
				"[Revengeance/Death Mode Only] Increases Rage Mode duration by 1 second",
				Color.Red,
				new Func<bool>(GetRageBoostTwo),
				"28",
				"38"
			};
			munchiesMod.Call(infernalBloodArgs);

			object[] redLightningContainerArgs = {
				"AddConsumable",
				"Calamity",
				"Red Lightning Container",
				"CalamityMod/Items/PermanentBoosters/RedLightningContainer",
				"[Revengeance/Death Mode Only] Increases Rage Mode duration by 1 second",
				Color.Red,
				new Func<bool>(GetRageBoostThree),
				"30",
				"38"
			};
			munchiesMod.Call(redLightningContainerArgs);

			static bool GetRageBoostOne() {
				return Main.LocalPlayer.Calamity().rageBoostOne;
			}

			static bool GetRageBoostTwo() {
				return Main.LocalPlayer.Calamity().rageBoostTwo;
			}

			static bool GetRageBoostThree() {
				return Main.LocalPlayer.Calamity().rageBoostThree;
			}
		}

		private void AddCalamityConsumables_AdrenalineMode(Mod munchiesMod) {
			object[] electrolyteGelPackArgs = {
				"AddConsumable",
				"Calamity",
				"Electrolyte Gel Pack",
				"CalamityMod/Items/PermanentBoosters/ElectrolyteGelPack",
				"[Revengeance/Death Mode Only] Increases Adrenaline Mode damage by 20% & damage reduction by 5%",
				Color.Red,
				new Func<bool>(GetAdrenalineBoostOne),
				"34",
				"26"
			};
			munchiesMod.Call(electrolyteGelPackArgs);

			object[] starlightFuelCellArgs = {
				"AddConsumable",
				"Calamity",
				"Starlight Fuel Cell",
				"CalamityMod/Items/PermanentBoosters/StarlightFuelCell",
				"[Revengeance/Death Mode Only] Increases Adrenaline Mode damage by 20% & damage reduction by 5%",
				Color.Red,
				new Func<bool>(GetAdrenalineBoostTwo),
				"34",
				"32"
			};
			munchiesMod.Call(starlightFuelCellArgs);

			object[] ectoheartArgs = {
				"AddConsumable",
				"Calamity",
				"Ectoheart",
				"CalamityMod/Items/PermanentBoosters/Ectoheart",
				"[Revengeance/Death Mode Only] Increases Adrenaline Mode damage by 20% & damage reduction by 5%",
				Color.Red,
				new Func<bool>(GetAdrenalineBoostThree),
				"42",
				"42"
			};
			munchiesMod.Call(ectoheartArgs);

			static bool GetAdrenalineBoostOne() {
				return Main.LocalPlayer.Calamity().adrenalineBoostOne;
			}

			static bool GetAdrenalineBoostTwo() {
				return Main.LocalPlayer.Calamity().adrenalineBoostTwo;
			}

			static bool GetAdrenalineBoostThree() {
				return Main.LocalPlayer.Calamity().adrenalineBoostThree;
			}
		}

		private void AddCalamityConsumables_Other(Mod munchiesMod) {
			object[] CelestialOnionArgs = {
				"AddConsumable",
				"Calamity",
				"Celestial Onion",
				"CalamityMod/Items/PermanentBoosters/CelestialOnion",
				"Adds an accessory slot",
				"player_normal",
				new Func<bool>(GetAdrenalineBoostOne),
				"42",
				"52"
			};
			munchiesMod.Call(CelestialOnionArgs);

			static bool GetAdrenalineBoostOne() {
				return Main.LocalPlayer.Calamity().extraAccessoryML;
			}
		}
	}
}

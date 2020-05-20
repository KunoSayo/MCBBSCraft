using Terraria.ID;
using Terraria.ModLoader;

namespace MCBBSCraft.Items {
    // ReSharper disable once UnusedType.Global     #auto load
    public class Mess : ModItem {
        public override void SetStaticDefaults() {
            Tooltip.SetDefault("Hunluan!.");
        }

        public override void SetDefaults() {
            item.damage = 1;
            item.width = 10;
            item.height = 10;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 6;
            item.value = 10000;
            item.rare = ItemRarityID.Yellow;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<WarningCard>();
            item.shootSpeed = 10;
        }

        public override void AddRecipes() {
            var recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofNight, 1);
            recipe.AddIngredient(ItemID.SoulofLight, 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}

using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MCBBSCraft.Items {
    // ReSharper disable once UnusedType.Global #auto load
    // ReSharper disable once ClassNeverInstantiated.Global #auto load
    public class WarningCard : ModProjectile {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Give warnings to them!");
        }

        public override void SetDefaults() {
            projectile.arrow = true;
            projectile.width = 21;
            projectile.height = 17;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            aiType = ProjectileID.WoodenArrowFriendly;
        }

        public override void ModifyHitNPC(NPC target,
            ref int damage,
            ref float knockback,
            ref bool crit,
            ref int hitDirection) {
            damage = target.HasBuff(ModContent.BuffType<WarnedBuff>()) && (crit = true) ? 2 * damage : damage;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            int buffType = ModContent.BuffType<WarnedBuff>();
            target.AddBuff(buffType, 5 * 60, target.HasBuff(buffType));
        }
    }

    // ReSharper disable once ClassNeverInstantiated.Global # auto load
    public class WarnedBuff : ModBuff {
        public override bool Autoload(ref string name, ref string texture) {
            texture = texture.Replace("WarnedBuff", "WarningCard");
            return true;
        }

        public override void SetDefaults() {
            DisplayName.SetDefault("You're good.");
        }
    }
}

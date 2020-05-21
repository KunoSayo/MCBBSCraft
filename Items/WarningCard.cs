using Microsoft.Xna.Framework;
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

        public override void Update(NPC npc, ref int buffIndex) {
            var pos = npc.position;
            Dust.NewDust(pos, 42, 34, ModContent.DustType<WarningCardDust>(), Scale: 2);
        }
    }

    // ReSharper disable once ClassNeverInstantiated.Global #autoload
    public class WarningCardDust : ModDust {
        public override bool Autoload(ref string name, ref string texture) {
            texture = texture.Replace("WarningCardDust", "WarningCard");
            return true;
        }

        public override void OnSpawn(Dust dust) {
            dust.velocity = Vector2.Zero;
            dust.noGravity = true;
        }

        public override bool Update(Dust dust) {
            if (!dust.firstFrame) {
                dust.active = false;
            }
            return false;
        }
    }
}

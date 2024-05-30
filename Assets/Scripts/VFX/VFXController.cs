using UnityEngine;

namespace CosmicCuration.VFX
{
    public class VFXController
    {
        private VFXView vfxView;

        public VFXController(VFXView vfxPrefab)
        {
            vfxView = Object.Instantiate(vfxPrefab);
            vfxView.SetController(this);
        }

        public void Configure(VFXType type, Vector2 spawnPosition) => vfxView.ConfigureAndPlay(type, spawnPosition);

        public void OnParticleEffectCompleted() => GameService.Instance.GetVFXService().ReturnVFXToPool(this);
    }
}
using System;
using System.Reflection;
using Leopotam.Ecs;
using NUnit.Framework;

namespace Tests.Ecs
{
    public abstract class EcsTestsFixture
    {
        private static readonly Type EcsFilterType = typeof(EcsFilter);
        
        protected EcsWorld World;
        protected EcsSystems Systems;

        [SetUp]
        public virtual void SetupBase()
        {
            World = new EcsWorld();
            Systems = new EcsSystems(World);
            
            SetUpEcsFilters();
        }

        [TearDown]
        public virtual void TearDownBase()
        {
            Systems.Destroy();
            World.Destroy();
        }

        protected virtual void SetUpEcsFilters()
        {
            Type testsType = GetType();

            foreach (FieldInfo fieldInfo in testsType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if (fieldInfo.FieldType.IsSubclassOf(EcsFilterType))
                    fieldInfo.SetValue(this, World.GetFilter(fieldInfo.FieldType));
            }
        }
    }
}
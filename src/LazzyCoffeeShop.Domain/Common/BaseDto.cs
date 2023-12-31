﻿using Mapster;

namespace LazzyCoffeeShop.Domain.Common
{
    public abstract class BaseDto<TDto, TEntity> : IRegister
    where TDto : class, new()
    where TEntity : class, new()
    {

        public TEntity ToEntity()
        {
            return this.Adapt<TEntity>();
        }

        public TEntity ToEntity(TEntity entity)
        {
            return (this as TDto).Adapt(entity);
        }

        public static TDto FromEntity(TEntity entity)
        {
            return entity.Adapt<TDto>();
        }

        private TypeAdapterConfig Config { get; set; }

        public virtual void AddCustomMappings() { }

        protected TypeAdapterSetter<TDto, TEntity> SetCustomMappings() => Config.ForType<TDto, TEntity>().IgnoreNullValues(true);

        protected TypeAdapterSetter<TEntity, TDto> SetCustomMappingsInverse() => Config.ForType<TEntity, TDto>();

        public void Register(TypeAdapterConfig config)
        {
            Config = config;
            AddCustomMappings();
        }
    }
}

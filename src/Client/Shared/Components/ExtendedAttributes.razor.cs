﻿using System;
using TestApi2.Domain.Contracts;
using Microsoft.AspNetCore.Components;

namespace TestApi2.Client.Shared.Components
{
    public abstract partial class ExtendedAttributes<TId, TEntityId, TEntity, TExtendedAttribute>
        : ExtendedAttributesBase<TId, TEntityId, TEntity, TExtendedAttribute>
            where TEntity : AuditableEntity<TEntityId>, IEntityWithExtendedAttributes<TExtendedAttribute>, IEntity<TEntityId>
            where TExtendedAttribute : AuditableEntityExtendedAttribute<TId, TEntityId, TEntity>, IEntity<TId>
            where TId : IEquatable<TId>
    {
        protected override RenderFragment Inherited() => builder => base.BuildRenderTree(builder);
    }
}
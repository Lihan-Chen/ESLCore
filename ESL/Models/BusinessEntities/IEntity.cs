namespace ESL.Models.BusinessEntities
{
    public interface IEntity
    {
        /// <summary>
        /// Gets or sets the Id of the Entity.
        /// [DataObjectFieldAttribute(key, identity, isNullable]
        /// </summary>
        public int Id { get; set; }
    }
}

namespace ESL.Web.Models.BusinessEntities
{
    public interface IEntity
    {
        /// <summary>
        /// Gets or sets the Id of the Entity.
        /// [DataObjectField(key, identity, isNullable]
        /// </summary>
        public int Id { get; set; }
    }
}

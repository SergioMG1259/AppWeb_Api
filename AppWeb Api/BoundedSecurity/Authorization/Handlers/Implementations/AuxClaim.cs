namespace AppWeb_Api.BoundedSecurity.Authorization.Handlers.Implementations
{
    public class AuxClaim
    {
        public int Id { get; set; }
        public int Type { get; set; }

        public AuxClaim(int id, int type)
        {
            Id = id;
            Type = type;

        }
    }
}
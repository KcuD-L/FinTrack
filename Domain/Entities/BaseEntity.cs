namespace FinTrack.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAtUtc { get; private set; } = DateTime.UtcNow;
        public DateTime? UpdatedAtUtc { get; private set; }

        public void MarkAsUpdated()
        {
            UpdatedAtUtc = DateTime.UtcNow;
        }
    }
}

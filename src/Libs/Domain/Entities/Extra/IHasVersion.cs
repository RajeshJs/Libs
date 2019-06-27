namespace Libs.Domain.Entities.Extra
{
    public interface IHasVersion
    {
        byte[] Timestamp { get; set; }
    }
}

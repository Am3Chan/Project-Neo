namespace Neo.Driver.Linux.Models
{
    [Flags]
    public enum MapEntryPermissions
    {
        None,
        Read,
        Write,
        Execute,
        Shared
    }
}
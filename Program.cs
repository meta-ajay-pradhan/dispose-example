class ResourceManagement : IDisposable
{
    public ResourceManagement()
    { }
    private bool IsDisposed = false;
    public void Free()
    {
        if (IsDisposed)
            throw new System.ObjectDisposedException("Object Name");
    }
    //Call Dispose to free resources explicitly
    public void Dispose()
    {
        //Pass true in dispose method to clean managed resources too and say GC to skip finalize in next line.
        Dispose(true);
        //If dispose is called already then say GC to skip finalize on this instance.
        GC.SuppressFinalize(this);
    }
    ~ResourceManagement()
    {
        //Pass false as param because no need to free managed resources when you call finalize it will be done
        //by GC itself as its work of finalize to manage managed resources.
        Console.WriteLine("GC Mananging");
        Dispose(false);
    }
    //Implement dispose to free resources
    protected virtual void Dispose(bool disposedStatus)
    {
        if (!IsDisposed)
        {
            IsDisposed = true;
            // Released unmanaged Resources
            if (disposedStatus)
            {
                Console.WriteLine("Releasing Resources...!");
                // Released managed Resources
            }
        }
    }
}

public class Program {
    public static void Main(string[] args) {

        Console.WriteLine("With Dispose Method!");
        ResourceManagement resManage = new ResourceManagement();
        resManage.Dispose();
        Console.WriteLine("Witout Dispose Method!");
        ResourceManagement resManage2 = new ResourceManagement();
        
    }
}
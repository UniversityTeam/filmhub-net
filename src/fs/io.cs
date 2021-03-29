namespace Filmhub.FS
{
    abstract class IO
    {
        abstract public void Open(string path);
        abstract public void Close();
        abstract public byte[] Read();

        // TODO: writting
        //abstract public void Write(string);
    }
}

using System.IO;

namespace Filmhub.FS
{
    class File : IO
    {
        private FileStream stream;

        public string Path { get; private set; }
        public long Size { get; private set; }

        public File() : base() { }
        public File(string path)
            : base()
        {
            Open(path);
        }

        public override void Open(string path)
        {
            Path = path;
            stream = new FileStream(path, FileMode.OpenOrCreate);
            Size = stream.Length;
        }

        public override byte[] Read()
        {
            // Allocate buffer
            byte[] data = new byte[stream.Length];

            // Read all stream
            stream.Read(data, 0, (int)stream.Length);

            return data;
        }

        public override void Close()
        {
            stream.Close();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Filmhub.FS
{
    class Cache
    {
        private Dictionary<string, byte[]> data;

        public Cache()
        {
            data = new Dictionary<string, byte[]>();
        }

        public byte[] Get(string path)
        {
            if(!data.ContainsKey(path))
            {
                Console.WriteLine($"File {path} readed from disk");
                Add(new File(path));
            }

            Console.WriteLine($"File {path} readed from cache");
            return data[path];
        }

        public void Add(File file)
        {
            data.Add(file.Path, file.Read());
        }
        public void Remove(string path)
        {
            data.Remove(path);
        }
    }
}

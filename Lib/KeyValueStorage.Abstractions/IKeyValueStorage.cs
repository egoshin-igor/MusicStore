using System;

namespace MusicStore.Lib.KeyValueStorage.Abstractions
{
    public interface IKeyValueStorage
    {
        void Subscribe( string channel, Action<string> action );
        void Publish( string channel, string message );
    }
}

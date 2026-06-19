namespace Redexpress.DesignPatterns.Platform;

public sealed class LowerCaseStream(Stream inner) : Stream
{
    public override int Read(byte[] buffer, int offset, int count)
    {
        int bytesRead = inner.Read(buffer, offset, count);

        for (int i = offset; i < offset + bytesRead; i++)
            buffer[i] = (byte)char.ToLowerInvariant((char)buffer[i]);

        return bytesRead;
    }

    public override int Read(Span<byte> buffer)
    {
        int bytesRead = inner.Read(buffer);

        for (int i = 0; i < bytesRead; i++)
            buffer[i] = (byte)char.ToLowerInvariant((char)buffer[i]);

        return bytesRead;
    }

    public override async ValueTask<int> ReadAsync(
        Memory<byte> buffer,
        CancellationToken cancellationToken = default)
    {
        int bytesRead = await inner.ReadAsync(buffer, cancellationToken);

        for (int i = 0; i < bytesRead; i++)
            buffer.Span[i] = (byte)char.ToLowerInvariant((char)buffer.Span[i]);

        return bytesRead;
    }

    public override void Write(byte[] buffer, int offset, int count)
        => inner.Write(buffer, offset, count);

    public override void Write(ReadOnlySpan<byte> buffer)
        => inner.Write(buffer);

    public override bool CanRead => inner.CanRead;
    public override bool CanSeek => inner.CanSeek;
    public override bool CanWrite => inner.CanWrite;
    public override long Length => inner.Length;

    public override long Position
    {
        get => inner.Position;
        set => inner.Position = value;
    }

    public override void Flush() => inner.Flush();

    public override long Seek(long offset, SeekOrigin origin)
        => inner.Seek(offset, origin);

    public override void SetLength(long value)
        => inner.SetLength(value);
}

public static class InputTest
{
    public static void Run()
    {
        Stream input = new LowerCaseStream(
            new BufferedStream(
                File.OpenRead("data.txt")));

        Span<byte> buffer = stackalloc byte[4096];

        int bytesRead;
        while ((bytesRead = input.Read(buffer)) > 0)
            Console.Write(System.Text.Encoding.UTF8.GetString(buffer[..bytesRead]));

        input.Close();
    }
}
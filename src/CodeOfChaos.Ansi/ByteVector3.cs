// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CodeOfChaos.Ansi;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
[StructLayout(LayoutKind.Explicit, Pack = 1)]
public readonly record struct ByteVector3(
    [field: FieldOffset(0)] byte X,
    [field: FieldOffset(1)] byte Y,
    [field: FieldOffset(2)] byte Z
) {
    public static readonly ByteVector3 Zero = new(byte.MinValue, byte.MinValue, byte.MinValue);
    public static readonly ByteVector3 Max = new(byte.MaxValue, byte.MaxValue, byte.MaxValue);

    // -----------------------------------------------------------------------------------------------------------------
    // Constructors
    // -----------------------------------------------------------------------------------------------------------------
    public ByteVector3(byte value) : this(value, value, value) {}
    public ByteVector3(int x, int y, int z) : this(
        (byte)Math.Clamp(x, byte.MinValue, byte.MaxValue),
        (byte)Math.Clamp(y, byte.MinValue, byte.MaxValue),
        (byte)Math.Clamp(z, byte.MinValue, byte.MaxValue)
    ) {
    }

    // -----------------------------------------------------------------------------------------------------------------
    // Methods
    // -----------------------------------------------------------------------------------------------------------------
    public string ToAnsiString() => $"{X};{Y};{Z}";
    public string ToRgbString() => $"rgb({X},{Y},{Z})";

    public ReadOnlySpan<byte> AsSpan()
        => MemoryMarshal.AsBytes(MemoryMarshal.CreateReadOnlySpan(ref Unsafe.AsRef(in this), 1));
}

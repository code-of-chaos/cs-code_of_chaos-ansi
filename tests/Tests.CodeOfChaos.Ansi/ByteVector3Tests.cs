// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using CodeOfChaos.Ansi;

namespace Tests.CodeOfChaos.Ansi;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class ByteVector3Tests {
    [Test]
    public async Task Zero_Vector_Should_Be_All_Zeroes() {
        // Arrange
        var expected = new ByteVector3(0, 0, 0);

        // Act
        ByteVector3 vector = ByteVector3.Zero;

        // Assert
        await Assert.That(vector.X).IsEqualTo(expected.X);
        await Assert.That(vector.Y).IsEqualTo(expected.Y);
        await Assert.That(vector.Z).IsEqualTo(expected.Z);
    }

    [Test]
    public async Task Max_Vector_Should_Be_Max_Values() {
        // Arrange
        var expected = new ByteVector3(byte.MaxValue, byte.MaxValue, byte.MaxValue);

        // Act
        ByteVector3 vector = ByteVector3.Max;

        // Assert
        await Assert.That(vector.X).IsEqualTo(expected.X);
        await Assert.That(vector.Y).IsEqualTo(expected.Y);
        await Assert.That(vector.Z).IsEqualTo(expected.Z);
    }

    [Test]
    public async Task Constructor_With_Single_Value_Should_Set_All_Components() {
        // Arrange
        const byte value = 128;
        var expected = new ByteVector3(value, value, value);

        // Act
        var vector = new ByteVector3(value);

        // Assert
        await Assert.That(vector.X).IsEqualTo(expected.X);
        await Assert.That(vector.Y).IsEqualTo(expected.Y);
        await Assert.That(vector.Z).IsEqualTo(expected.Z);
    }

    [Test]
    public async Task Constructor_With_Three_Integers_Should_Clamp_To_Byte_Range() {
        // Arrange
        var expected = new ByteVector3(byte.MaxValue, byte.MinValue, (byte)128);

        // Act
        var vector = new ByteVector3(300, -50, 128);

        // Assert
        await Assert.That(vector.X).IsEqualTo(expected.X);// Clamped to byte.MaxValue (255)
        await Assert.That(vector.Y).IsEqualTo(expected.Y);// Clamped to byte.MinValue (0)
        await Assert.That(vector.Z).IsEqualTo(expected.Z);
    }

    [Test]
    [Arguments(10, 20, 30, "10;20;30")]
    [Arguments(-1, -1, -1, "0;0;0")]
    [Arguments(int.MinValue, int.MinValue, int.MinValue, "0;0;0")]
    [Arguments(int.MaxValue, int.MaxValue, int.MaxValue, "255;255;255")]
    public async Task ToAnsiString_Should_Return_Correct_Format(int x, int y, int z, string expected) {
        // Arrange
        var vector = new ByteVector3(x, y, z);

        // Act
        string result = vector.ToAnsiString();

        // Assert
        await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    [Arguments(10, 20, 30, "rgb(10,20,30)")]
    [Arguments(-1, -1, -1, "rgb(0,0,0)")]
    [Arguments(int.MinValue, int.MinValue, int.MinValue, "rgb(0,0,0)")]
    [Arguments(int.MaxValue, int.MaxValue, int.MaxValue, "rgb(255,255,255)")]
    public async Task ToRgbString_Should_Return_Correct_Format(int x, int y, int z, string expected) {
        // Arrange
        var vector = new ByteVector3(x,y,z);

        // Act
        string result = vector.ToRgbString();

        // Assert
        await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    public async Task AsSpan_Should_Return_Correct_Byte_Order() {
        // Arrange
        var vector = new ByteVector3(10, 20, 30);
        byte[] expectedSpan = [10, 20, 30];

        // Act
        int length = vector.AsSpan().Length;

        // Assert
        await Assert.That(length).IsEqualTo(expectedSpan.Length);
        for (int i = 0; i < length; i++) {
            ReadOnlySpan<byte> span = vector.AsSpan();
            await Assert.That(span[i]).IsEqualTo(expectedSpan[i]);
        }
    }
}

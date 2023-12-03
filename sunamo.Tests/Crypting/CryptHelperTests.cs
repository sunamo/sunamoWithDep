using static CryptHelper;

public class CryptHelperTests
{
    public class RijndaelStringTests
    {
        /// <summary>
        /// Not working great
        /// Must convert to bytes and transfer in bytes, also through network
        /// </summary>
        [Fact]
        public void EncryptDecrypStringTest()
        {
            var input = SH.Join("", RandomHelper.vsZnaky);
            
            var encrypted = CryptHelper.RijndaelString.Instance.Encrypt(input);
            var decrypted = CryptHelper.RijndaelString.Instance.Decrypt(encrypted);

            Assert.Equal(input, decrypted);
        }

        [Fact]
        public void EncryptDecrypBytesTest()
        {
            var inputString = SH.Join("", RandomHelper.vsZnaky);
            var input = Encoding.UTF8.GetBytes( inputString).ToList();

            var encrypted = CryptHelper.RijndaelBytes.Instance.Encrypt(input);

            var hexEncrypted = HexHelper.ToHex(encrypted);
            var encryptedBytes = HexHelper.FromHex(hexEncrypted);

            var decrypted = CryptHelper.RijndaelBytes.Instance.Decrypt(encryptedBytes);

            CA.RemovePadding<byte>(decrypted, 0);

            var s = Encoding.UTF8.GetString(decrypted.ToArray());



            Assert.Equal(inputString, s);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Dannys.Common
{
	public class Password
	{
		static string hash1(string password, byte[] salt)
		{
			Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt);
			return Convert.ToBase64String(pbkdf2.GetBytes(20));
		}

		static string hash2(string password, byte[] salt)
		{
			return Convert.ToBase64String(KeyDerivation.Pbkdf2(
				password: password,
				salt: salt,
				prf: KeyDerivationPrf.HMACSHA256,
				iterationCount: 10108,
				numBytesRequested: 256 / 8));
		}

		static byte[] generateSalt(int length)
		{
			byte[] salt = new byte[length];
			RandomNumberGenerator.Fill(salt);
			return salt;
		}

		public char Algorithm { get; set; }

		[Required, StringLength(100)]
		public string Hash { get; set; }

		[MaxLength(32)]
		public byte[] Salt { get; set; }

		public string NewPassword { get; private set; }

		public void SetPassword(string password, char algorithm = '2')
		{
			switch (algorithm)
			{
				case '1':
					Salt = generateSalt(20);
					NewPassword = hash1(password, Salt);
					break;
				case '2':
					Salt = generateSalt(20);
					NewPassword = hash2(password, Salt);
					break;
				default:
					throw new NotImplementedException();
			}
			
			Algorithm = algorithm; // Change the algorithm if the hash function changed
		}

		public bool CheckPassword(string password)
		{
			string hash;

			switch (Algorithm)
			{
				case '1':
					hash = hash1(password, Salt);
					break;
				case '2':
					hash = hash2(password, Salt);
					break;
				default:
					throw new NotImplementedException();
			}

			return hash == Hash;
		}
	}
}

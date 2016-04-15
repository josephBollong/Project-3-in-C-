using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Machine.Utils {
    class SecurityUtils {

        public String getHashedPassword(String passwordToHash, String salt) {



            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(passwordToHash + salt);
            data = MD5.Create().ComputeHash(data);
            return Convert.ToBase64String(data);

        }


        public List<String> getHashedPassword(String passwordToHash) {

            List<String> generatedResult = new List<String>();

            RandomNumberGenerator rand = new RNGCryptoServiceProvider();
            byte[] token = new byte[64];
            rand.GetBytes(token);
            String seed = Convert.ToBase64String(token);

            generatedResult.Add(getHashedPassword(passwordToHash, seed));
            generatedResult.Add(seed);

            return generatedResult;

        }
    }
}

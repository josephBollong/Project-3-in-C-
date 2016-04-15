using Bank_Machine.Utils.datatypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Machine.Utils.commands {
    class DataManagement {
        public static Int64 user;
        public static Int64 account;
        public static Int64 trans;
        private static string path = "./sav/conf.bin";
        private static FileInfo file = new FileInfo(path);
        private static User userAccount;
        private static Dictionary<String, Int64> idTable;

        public DataManagement() {

            if (!File.Exists(path)) {
                createFile();
            } else {
                loadNums();
            }

        }
        public static void saveNums() {

            try {
                FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                BinaryWriter w = new BinaryWriter(fs);
                w.Write((Int64)user);
                w.Write((Int64)account);
                w.Write((Int64)trans);
                IFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bf.Serialize(fs, idTable);
                w.Flush();
                w.Close();
                fs.Close();

            } catch (FileNotFoundException e) {
                createFile();
            } catch (IOException e) {
            }
        }


        public static void saveData() {
            String f = "./sav/" + userAccount.getUserId() + ".bin";
            if (!(idTable.ContainsKey(userAccount.getUserName()))) {
                idTable.Add(userAccount.getUserName(), userAccount.getUserId());
            }
            try {
                FileStream fs = new FileStream(f, FileMode.Create, FileAccess.Write);
                IFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bf.Serialize(fs, userAccount);
                fs.Flush();
                fs.Close();

            } catch (IOException e) {

            }
        }


        public static void loadData(Int64 _id) {
            String f = "./sav/" + _id + ".bin";
            try {
                FileStream fs = new FileStream(f, FileMode.Open, FileAccess.Read);
                IFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                idTable = (Dictionary<String, Int64>)bf.Deserialize(fs);
                fs.Flush();
                fs.Close();
            } catch (IOException e) {

            }
        }

        public static void deleteData(Int64 _id) {
            String f = "./sav/" + _id + ".bin";

            if (File.Exists(f)) {
                File.Delete(f);
            }
        }

        private static void createFile() {

            try {
                String d = "./sav/";
                if (!Directory.Exists(d)) {

                    Directory.CreateDirectory(d);
                } else {
                    String dat = "./sav/conf.bin";
                    File.Create(dat);
                    user = 1000000000000001;
                    account = 1000000000000001;
                    trans = 1000000000000001;
                    idTable = new Dictionary<String, Int64>();
                    saveNums();
                }

            } catch (IOException e) {
            }
        }

        public static void loadNums() {

            try{
                
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader w = new BinaryReader(fs);
            user = w.ReadInt64();
            account = w.ReadInt64();
            trans = w.ReadInt64();
            IFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            idTable = (Dictionary<String, Int64>)bf.Deserialize(fs);
            w.Close();
            fs.Close();

            } catch (IOException e) {

            }



        }
        public void setUserAccount(User _user) {
            userAccount = _user;
        }
        public User getUserAccount() {
            return userAccount;
        }
        public Dictionary<String, Int64> getTable() {
            return idTable;
        }
    }
}

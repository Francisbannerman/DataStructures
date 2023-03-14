using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DataStructures
{
    struct UserInfo
    {
        public int _userId;
        public string _userName;
        public UserInfo(int id, string name)
        {
            this._userId = id;
            this._userName = name;
        }
    }

    public static class HashTable
        //a collection of key-valued pairs stored in DictionaryEntry where the key is an indexer and the value
        //is accessed by using the key. Such that => Values = HashTable[key].

        ///
        /// WHY USE HASHTABLES => Near BigO of O(1) that is constant lookup times even a a massive scale.
        ///
    {
        static Hashtable userInfoHash;
        static List<UserInfo> userInfoList;
        static Stopwatch sw;

        public static void Test101()
        {
            userInfoHash = new Hashtable();
            userInfoList = new List<UserInfo>();
            sw = new Stopwatch();

            //Adding to a hash table
            for (int i = 0; i < 99999999; i++)
            {
                userInfoHash.Add(i, "user" + i);
                userInfoList.Add(new UserInfo(i, "user" + 1));
            }
            //Removing from a hash table
            if (userInfoHash.ContainsKey(0))
            {
                userInfoHash.Remove(0);
            }
            //Setting & Getting a value in hashtable. First u need to confirm if the key exist to confirm the value
            if (userInfoHash.ContainsKey(1))
            {
                userInfoHash[1] = "replacementName";
            }
            //Looping to get the key and value per each entry
            //foreach (DictionaryEntry entry in userInfoHash)
            //{
            //    Console.WriteLine("Key: " + entry.Key + " / Value: " + entry.Value);
            //}

            //Accessing with speed test of a stopwatch
            Random randomUserGen = new Random();
            int randomUser = -1;

            sw.Start();
            float startTime = 0;
            float endTime = 0;
            float deltaTime = 0;

            int cycles = 5;
            int cycle = 0;
            string userName = string.Empty;

            while (cycle < cycles)
            {
                randomUser = randomUserGen.Next(900000, 999999);

                startTime = sw.ElapsedMilliseconds;

                //access from list
                userName = GetUserFromList(randomUser);
                endTime = sw.ElapsedMilliseconds;
                deltaTime = endTime - startTime;
                Console.WriteLine($"Time taken to retreive {userName} from list took {string.Format("{0:0.##}", deltaTime)} ms");

                startTime = sw.ElapsedMilliseconds;

                //access from hash table
                userName = (string)userInfoHash[randomUser];
                endTime = sw.ElapsedMilliseconds;
                deltaTime = endTime - startTime;
                Console.WriteLine($"Time taken to retreive {userName} from hash took {string.Format("{0:0.##}", deltaTime)} ms\n");

                cycle++;

                //It took constant time when accessed from the hash table whilst it took a BigO of O(n) when accessed from the
                // list. Accessing from the hash table is much faster than from the list.
            }
        }
        static string GetUserFromList(int userId)
        {
            for (int i = 0; i < userInfoList.Count; i++)
            {
                if (userInfoList[i]._userId == userId)
                {
                    return userInfoList[i]._userName;
                }
            }
            return string.Empty;
        }
    }
}

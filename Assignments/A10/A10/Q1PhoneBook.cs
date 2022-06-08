using System;
using System.Linq;
using System.Collections.Generic;
using TestCommon;

namespace A10
{
    public class Contact
    {
        public string Name;
        public int Number;

        public Contact(string name, int number)
        {
            Name = name;
            Number = number;
        }
    }

    public class Q1PhoneBook : Processor
    {
        public Q1PhoneBook(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string[], string[]>)Solve);

        protected List<Contact> PhoneBookList;
        public static List<string> answer = new List<string>(); 
        // public static string[] contacts = new string[10000000];
        public static Dictionary<long,string> contacts = new Dictionary<long, string>();
        

        public string[] Solve(string [] commands)
        {
            contacts.Clear();
            answer.Clear();
            // Array.Clear(contacts,0,contacts.Length);
            string name = null;
            // Contact[] contacts = new Contact[9999999];
            foreach (var cmd in commands)
            {
                var toks = cmd.Split();
                var com = toks[0];
                int number = int.Parse(toks[1]);
                if (com == "add")
                {
                    name = toks[2];
                    add(name,number);
                }
                if (com =="del")
                {
                    del(number);
                    
                }
                if (com =="find")
                {
                    find(number);
                    
                }
                
            }
            return answer.ToArray();
        }

        private void find(int number)
        {
            if (!contacts.ContainsKey(number))
            {
                answer.Add("not found");
            }
            else
            {
                answer.Add(contacts[number]);
            }
        }

        private void del(int number)
        {
            contacts.Remove(number);
        }

        private void add(string name, int number)
        {
            if (!contacts.ContainsKey(number))
            {
                contacts.Add(number,name);
            }
            else
            {
                string tmp = contacts[number];
                contacts[number] = name;
            }
        }

        public void Add1(string name, int number)
        {
            for(int i=0; i<PhoneBookList.Count; i++)
            {
                if (PhoneBookList[i].Number == number)
                {
                    PhoneBookList[i].Name = name;
                    return;
                }
            }
            PhoneBookList.Add(new Contact(name, number));
        }

        public string Find1(int number)
        {
            for (int i = 0; i < PhoneBookList.Count; i++)
            {
                if (PhoneBookList[i].Number == number)
                    return PhoneBookList[i].Name;             
            }
            return "not found";
        }

        public void Delete1(int number)
        {
            for (int i = 0; i < PhoneBookList.Count; i++)
            {
                if (PhoneBookList[i].Number == number)
                {
                    PhoneBookList.RemoveAt(i);
                    return;
                }
            }
        }
    }
}


// PhoneBookList = new List<Contact>(commands.Length);
//             List<string> result = new List<string>();
//             foreach(var cmd in commands)
//             {
//                 var toks = cmd.Split();
//                 var cmdType = toks[0];
//                 var args = toks.Skip(1).ToArray();
//                 int number = int.Parse(args[0]);
//                 switch (cmdType)
//                 {
//                     case "add":
//                         Add(args[1], number);
//                         break;
//                     case "del":
//                         Delete(number);
//                         break;
//                     case "find":
//                         result.Add(Find(number));
//                         break;
//                 }
//             }
//             return result.ToArray();
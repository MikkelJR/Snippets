using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

// Mikkel Refsgaard 
// https://github.com/MikkelJR/

// TODO: Change Namespace
namespace Namespace
{
    public static class BankHandler
    {
        public static BankObject  GetBankBranch(int regNr)
        {
            // TODO: Change Path to json file
            using (var sr = new StreamReader("C:\\Banks.json"))
            {
                var list = new List<BankObject>();
                var jsonResponse = sr.ReadToEnd();

                dynamic jsonObject = JsonConvert.DeserializeObject(jsonResponse);

                foreach (var d in jsonObject.Bank)
                {
                    list.Add(new BankObject
                             {
                                 Branch = d.Branch,
                                 Name = d.Name,
                                 RegNr = d.RegNr
                             });
                }

                return (from a in list where a.RegNr == regNr select a).SingleOrDefault();
            }
        } 

        public class BankObject
        {
            public int RegNr { get; set; }

            public string Name { get; set; }

            public string Branch { get; set; }
        }
    }
}
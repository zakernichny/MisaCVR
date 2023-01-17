using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerList.Data
{
    internal class PlayerData
    {
        string _id;
        string _name;


        public string Name => _name;
        public string Id => _id;

        public PlayerData(string id, string name)
        {
            _id = id;
            _name = name;
        }
    }
}

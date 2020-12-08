using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturalAPI.Models.dataTransferModel
{
    public class GroupsName
    {
        public GroupsName()
        {

        }
        public GroupsName(GroupDB group)
        {
            id = group.id;
            name = group.numberOfGroup;
        }
        public Guid id { get; set; }
        public string name { get; set; }
    }
}

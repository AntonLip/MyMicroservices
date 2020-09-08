using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LecturalAPI.Models.dataBaseModel
{
    internal class wifes : iMan
    {
        [Key]
        public Guid id { get ; set ; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public DateTime birthDay { get; set; }
        public string pathPhotoSmall { get; set; }
        public string pathPhotoBig { get; set; }       
        public string info { get ; set; }

        internal Lectural Lectural { get; set; }
    }
    internal class children : iMan
    {
        [Key]
        public Guid id { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public DateTime birthDay { get; set; }
        public string pathPhotoSmall { get; set; }
        public string pathPhotoBig { get; set; }
        public string info { get; set; }

        internal Lectural Lectural { get; set; }

    }
}

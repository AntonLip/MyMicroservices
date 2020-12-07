using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturalAPI.Models.dataBaseModel
{
    public class File
    {
        public Guid id { get; set; }
        public string nameFile { get; set; }
        public IFormFile file { get; set; }
    }
}

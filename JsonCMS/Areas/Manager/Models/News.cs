using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace JsonCMS.Areas.Manager.Models
{
    public class News
    {
        [Required(ErrorMessage = "Verificare se è stato inserito l'id della news.")]
        public int id { get; set; }
        [Required(ErrorMessage = "Verificare se è stato inserito il titolo della news.")]
        public string title { get; set; }
        public string eyelet { get; set; }
        [AllowHtml]
        public string body { get; set; }
        public string author { get; set; }
        public dynamic date { get; set; }
        [DataType(DataType.Upload)]
        [Display(Name = "Upload File")]
        //[Required(ErrorMessage = "Please choose file to upload.")]
        public dynamic img { get; set; }
        public string link { get; set; }
        public string target { get; set; }
        public string macroarea { get; set; }
        public string category { get; set; }
        public string tags { get; set; }
        //public dynamic gallery { get; set; }
    }
}
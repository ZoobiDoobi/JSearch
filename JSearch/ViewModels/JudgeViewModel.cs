using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JSearch.ViewModels
{
    public class JudgeViewModel
    {

        public int JudgeId { get; set; }

        [Required]
        [DisplayName("Judge Name")]
        [StringLength(maximumLength:150,ErrorMessage ="Too Many Characters")]
        public string JudgeName { get; set; }
        [DisplayName("Remakrs")]
        public string JudgeRemarks { get; set; }
        [DisplayName("Status")]
        public int? JudgeStatus { get; set; }
    }
}
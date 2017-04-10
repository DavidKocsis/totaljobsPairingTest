using System.Collections.Generic;

namespace PairingTest.Web.Models
{
    public class QuestionnaireViewModel
    {
        public string QuestionnaireTitle { get; set; }

        public IList<string> QuestionsText { get; set; }

        public IList<string>Answers { get; set; }

        public ResponseStatus Status { get; set; }
    }
}
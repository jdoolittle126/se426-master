using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIRouting.Models;

namespace WebAPIRouting.Controllers
{
    public class TranscriptController : ApiController
    {

        public static readonly TranscriptModel transcript = new TranscriptModel()
        {
            StudentName = "Sam Smith",
            StudentId = "552211",
            Quarters = new []
            {
                new QuarterModel()
                {
                    Term = "Fall2021",
                    ClassName = "Web Services",
                    Grade = 95.0f
                },
                new QuarterModel()
                {
                    Term = "Summer2021",
                    ClassName = "Android",
                    Grade = 89.0f
                },
                new QuarterModel()
                {
                    Term = "Spring2021",
                    ClassName = "Java",
                    Grade = 95.0f
                }
            }
        };

        public TranscriptModel GetTranscript(string studentId)
        {
            return transcript;
        }

    }
}

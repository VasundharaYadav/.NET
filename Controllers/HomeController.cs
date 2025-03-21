using Microsoft.AspNetCore.Mvc; // Required for Controller and IActionResult
using PortfolioWebsite.Models; // Required for PortfolioModel
using System;
using System.Collections.Generic;
using System.IO;

namespace PortfolioWebsite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult TechSkills()
        {
            var model = new PortfolioModel
            {
                TechSkills = new Dictionary<string, List<string>>
                {
                    { "Programming Languages", new List<string> { "C#", "JavaScript", "Python" ,"Java" } },
                    { "Frameworks & Libraries", new List<string> { "ASP.NET MVC", "React", "Node" } },
                    { "Databases", new List<string> { "SQL Server", "PostgreSQL", "MongoDB" } },
                    { "Tools & Platforms", new List<string> { "Git", "GitHub", "LeetCode" } }
                }
            };
            return View(model);
        }

        public IActionResult Index()
        {
            var model = new PortfolioModel
            {
                Name = "Vasundhara Yadav",
                Overview = "A passionate developer with expertise in multiple technologies"
            };
            return View(model);
        }

        public IActionResult About()
        {
            var model = new PortfolioModel
            {
                Background = "I’m Vasundhara Yadav, a graduate of SPPU University with a Bachelor’s in Computer Science. My journey began with tinkering on my first computer as a teen, sparking a lifelong passion for tech.",
                Experience = "With over 3 years of experience as a software developer, I’ve worked on web applications, mobile tools, and backend systems at college in projects.",
                Goals = "My goal is to leverage my skills in full-stack development to build accessible, efficient solutions and contribute to open-source projects that benefit the community."
            };
            return View(model);
        }

        public IActionResult Download()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DownloadResume()
        {
            try
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", "vasundhara_resume.pdf");
                if (!System.IO.File.Exists(filePath))
                {
                    return NotFound("Resume file not found.");
                }
                var fileBytes = System.IO.File.ReadAllBytes(filePath);
                return File(fileBytes, "application/pdf", "vasundhara_Resume.pdf");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while downloading the file: {ex.Message}");
            }
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Project1.Data;
using Project1.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Project1.Data;
using Project1.Models.Dtos;


namespace Project1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Project1Controller : ControllerBase
    {
        private readonly Project1DbContext context;
        public Project1Controller(Project1DbContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public ActionResult getAllProjects()
        {
            var projects = context.projects.ToList();
            return Ok(projects);
        }

        [HttpPost]
        public ActionResult<Project> CreateProject(Project1Dto project1Dto)
        {
            var project = new Project()
            {
                Name = project1Dto.Name,
                Description = project1Dto.Description,
                Price = project1Dto.Price
            };
           
            var createdProject = context.Projects.Add(project);
            context.SaveChanges();
            return Ok(createdProject.Entity);
        }

         [HttpGet("{id}")]
        public ActionResult<Project> GetProjectById(int id)
        {
           var project = context.Projects.Find(id);
           if (project == null)
           {
               return NotFound();
           }
           return Ok(project);
        }

        [HttpPut("{id}")]
        public ActionResult<Project> UpdateProject(int id, Project1Dto project1Dto)
        {
            var existingProject = context.Projects.Find(id);
            if (existingProject == null)
            {
                return NotFound();
            }

            existingProject.Name = project1Dto.Name;
            existingProject.Description = project1Dto.Description;
            existingProject.Price = project1Dto.Price;

            context.SaveChanges();
            return Ok(existingProject);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProject(int id)
        {
            var existingProject = context.Projects.Find(id);
            if (existingProject == null)
            {
                return NotFound();
            }

            context.Projects.Remove(existingProject);
            context.SaveChanges();
            return NoContent();
        }


    }
}
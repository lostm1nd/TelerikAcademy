namespace BugLogger.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using BugLogger.Data;
    using BugLogger.Models;

    public class BugsController : ApiController
    {
        private IRepository<Bug> bugsRepo;

        public BugsController()
            : this(new BugsRepository(new BugLoggerDbContext()))
        {
        }

        public BugsController(IRepository<Bug> repo)
        {
            this.bugsRepo = repo;
        }

        public IQueryable<Bug> GetAllBugs()
        {
            var bugs = this.bugsRepo.All();

            return bugs;
        }

        public IQueryable<Bug> GetNumberOfBugs(int count)
        {
            return this.GetAllBugs().Take(count);
        }

        public HttpResponseMessage PostBug(Bug newBug)
        {
            if (string.IsNullOrEmpty(newBug.Content))
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, new ArgumentException("Content cannot be null or empty"));
            }

            newBug.LogDate = DateTime.Now;
            newBug.Status = BugStatus.Pending;

            this.bugsRepo.Add(newBug);
            this.bugsRepo.SaveChanges();

            var response = this.Request.CreateResponse(HttpStatusCode.Created, newBug);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = newBug.BugId }));

            return response;
        }
        public HttpResponseMessage PutBug(int id, Bug bug)
        {
            var bugFromDb = this.bugsRepo.All().FirstOrDefault(b => b.BugId == id);
            if (bugFromDb == null)
            {
                return this.Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, new ArgumentException("Bug with this id does not exist" + id));
            }

            if (!string.IsNullOrEmpty(bug.Content))
            {
                bugFromDb.Content = bug.Content;
            }

            bugFromDb.Status = bug.Status;
            this.bugsRepo.SaveChanges();

            var response = this.Request.CreateResponse(HttpStatusCode.OK, bugFromDb);
            return response;
        }

        public HttpResponseMessage DeleteBug(int id)
        {
            var bug = this.bugsRepo.All().FirstOrDefault(b => b.BugId == id);
            if (bug == null)
            {
                return this.Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, new ArgumentException("Bug with this id does not exist" + id));
            }

            this.bugsRepo.Delete(bug);
            this.bugsRepo.SaveChanges();

            var response = this.Request.CreateResponse(HttpStatusCode.OK, bug);
            return response;
        }
    }
}

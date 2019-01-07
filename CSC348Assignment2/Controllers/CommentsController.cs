using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CSC348Assignment2.Data;
using CSC348Assignment2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;

namespace CSC348Assignment2.Controllers
{
    [Authorize]
    public class CommentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private UserManager<ApplicationUser> _userManager;

        public CommentsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Comments/Create
        //Gets the form to create a new comment.
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["PostId"] = new SelectList(_context.Post, "Id", "Body");
            return View();
        }

        // POST: Comments/Create
        //Create a new comment on a post with id, including a text body.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, [Bind("Body")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                //Get the id of the user logged in.
                string userId = _userManager.GetUserId(User);

                //Add attributes to the comment that aren't given by the commenter.
                comment.ApplicationUserId = userId;
                comment.Commenter = await _userManager.FindByIdAsync(userId);
                comment.Date = DateTime.Now;
                comment.PostId = id;

                Post post = await _context.Post.FindAsync(id);
                comment.Post = post;
                //Add comment to posts list of comments.
                if (post.Comments == null)
                {
                    post.Comments = new List<Comment>();
                }
                post.Comments.Add(comment);

                _context.Update(post);
                _context.Add(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction("details", "Posts", new { Id = comment.PostId });
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", comment.ApplicationUserId);
            ViewData["PostId"] = new SelectList(_context.Post, "Id", "Body", comment.PostId);
            return View(comment);
        }

        // GET: Comments/Delete/5
        //Allows admins to view the delete view for comments.
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comment
                .Include(c => c.Commenter)
                .Include(c => c.Post)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // POST: Comments/Delete/5
        //Allows admins to delete comments.
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comment = await _context.Comment.FindAsync(id);
            _context.Comment.Remove(comment);
            await _context.SaveChangesAsync();

            return RedirectToAction("details", "Posts", new { Id = comment.PostId });
        }

        private bool CommentExists(int id)
        {
            return _context.Comment.Any(e => e.Id == id);
        }
    }
}

﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Net6API.Data;
using Net6API.Models;

namespace Net6API.Repository
{
    public interface IUserRepository
    {
        Task<ActionResult<List<User>>> AllUsers();
        Task<ActionResult<User>> Details(Guid? id);
    }

    public class UserRepository : ControllerBase, IUserRepository
    {
        private readonly Net6APIContext _context;
        private readonly IConfiguration _config;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(Net6APIContext context, IConfiguration config, ILogger<UserRepository> logger)
        {
            _context = context;
            _config = config;
            _logger = logger;
        }

        async Task<ActionResult<List<User>>> IUserRepository.AllUsers()
        {
            try
            {
               List<User> users = await _context.User.ToListAsync();

                if(users == null)
                {
                    return NotFound();
                }

                return users;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString());
                return StatusCode(500, ex.Message);
            }
        }
        // GET: Users/Details/5
        public async Task<ActionResult<User>> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        //// GET: Users/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Users/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Password,Email,ID,CreatedBy,CreatedOnDate,LastUpdatedBy,LastUpdatedOnDate")] User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        user.ID = Guid.NewGuid();
        //        _context.Add(user);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(user);
        //}

        //// GET: Users/Edit/5
        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var user = await _context.User.FindAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(user);
        //}

        //// POST: Users/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("Password,Email,ID,CreatedBy,CreatedOnDate,LastUpdatedBy,LastUpdatedOnDate")] User user)
        //{
        //    if (id != user.ID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(user);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UserExists(user.ID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(user);
        //}

        //// GET: Users/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var user = await _context.User
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(user);
        //}

        //// POST: Users/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    var user = await _context.User.FindAsync(id);
        //    _context.User.Remove(user);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool UserExists(Guid id)
        //{
        //    return _context.User.Any(e => e.ID == id);
        //}
    }
}

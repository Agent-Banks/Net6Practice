#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Net6API.Data;
using Net6API.Models;
using Net6API.Repository;

namespace Net6API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
[Produces("application/json")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepo;
    private readonly ILogger<UserController> _logger;

    public UserController(IUserRepository userRepo, ILogger<UserController> logger)
    {
        _userRepo = userRepo;
        _logger = logger;
    }

    //User/AllUsers
    [HttpGet]
    public async Task<ActionResult<List<User>>> AllUsers() => await _userRepo.AllUsers();

    //User/Details/5
    [HttpGet]
    public async Task<ActionResult<User>> Details(Guid? id) => await _userRepo.Details(id);

    //Users/Create   
    [HttpPost]
    //[ValidateAntiForgeryToken]
    public async Task<ActionResult<User>> Create([Bind("UserName,Password,Email")] User user) => await _userRepo.Create(user);

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
}
